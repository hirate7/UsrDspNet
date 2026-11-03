Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.Script.Serialization

''' <summary>
''' 1つの変更項目の変更前後の状態
''' </summary>
Public Class UsrRrkChange
    Public Property Field As String = ""
    Public Property Before As String = ""
    Public Property After As String = ""

    Public Sub New()
    End Sub

    Public Sub New(ByVal fld As String, ByVal bfr As String, ByVal aft As String)
        Field = fld
        Before = bfr
        After = aft
    End Sub
End Class

''' <summary>
''' 1回の修正記録エントリ
''' </summary>
Public Class UsrRrkEntry
    Public Property Timestamp As String = ""
    Public Property SyainCode As String = ""
    Public Property SyainName As String = ""
    Public Property PcName As String = ""
    Public Property Changes As New List(Of UsrRrkChange)()

    Public Sub New()
    End Sub
End Class

''' <summary>
''' 社員コンボボックス用の表示アイテム
''' </summary>
Public Class SyainComboItem
    Public Property Code As String = ""
    Public Property Name As String = ""

    Public Sub New()
    End Sub

    Public Sub New(ByVal cd As String, ByVal nm As String)
        Code = cd
        Name = nm
    End Sub

    Public Overrides Function ToString() As String
        Return If(String.IsNullOrWhiteSpace(Code), Name, $"{Code}: {Name}")
    End Function
End Class

Public Module MdlUsrRrk

    Private ReadOnly jsonSerializer As New JavaScriptSerializer()

    ''' <summary>
    ''' ユーザーデータテーブルに「履歴」メモ型カラムが存在することを確認・無ければ自動追加
    ''' </summary>
    Public Sub EnsureRrkColumn(ByVal cn As OleDbConnection)
        If cn Is Nothing Then Return
        Try
            If cn.State <> ConnectionState.Open Then cn.Open()
            Dim dt As New DataTable()
            Using da As New OleDbDataAdapter("SELECT TOP 1 * FROM ユーザーデータ", cn)
                da.Fill(dt)
            End Using
            If Not dt.Columns.Contains("履歴") Then
                Using cmd As New OleDbCommand("ALTER TABLE ユーザーデータ ADD COLUMN 履歴 MEMO", cn)
                    cmd.ExecuteNonQuery()
                End Using
            End If
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' JSON文字列を履歴エントリのリストに変換
    ''' </summary>
    Public Function DeserializeHistory(ByVal json As String) As List(Of UsrRrkEntry)
        If String.IsNullOrWhiteSpace(json) Then
            Return New List(Of UsrRrkEntry)()
        End If
        Try
            Dim list = jsonSerializer.Deserialize(Of List(Of UsrRrkEntry))(json)
            If list IsNot Nothing Then
                Return list
            End If
        Catch
        End Try
        Return New List(Of UsrRrkEntry)()
    End Function

    ''' <summary>
    ''' 履歴エントリのリストをJSON文字列に変換
    ''' </summary>
    Public Function SerializeHistory(ByVal list As List(Of UsrRrkEntry)) As String
        If list Is Nothing OrElse list.Count = 0 Then
            Return ""
        End If
        Try
            Return jsonSerializer.Serialize(list)
        Catch
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' 指定ユーザーの現在の「履歴」JSON文字列を取得
    ''' </summary>
    Public Function GetUserHistoryJson(ByVal code As String, ByVal cn As OleDbConnection) As String
        If cn Is Nothing OrElse String.IsNullOrWhiteSpace(code) Then Return ""
        Try
            If cn.State <> ConnectionState.Open Then cn.Open()
            EnsureRrkColumn(cn)
            Dim cdSql As String = GetUcdSql(code)
            Dim dt As DataTable = QueryDataTable("SELECT [履歴] FROM ユーザーデータ WHERE [コード] = " & cdSql, cn)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return NulCut(dt.Rows(0)("履歴"))
            End If
        Catch
        End Try
        Return ""
    End Function

    ''' <summary>
    ''' 変更差分がある場合に新しい履歴エントリを作成して既存履歴の先頭に追加したJSONを返す
    ''' </summary>
    Public Function AppendHistoryJson(ByVal existingJson As String,
                                      ByVal syainCode As String,
                                      ByVal syainName As String,
                                      ByVal changes As List(Of UsrRrkChange)) As String
        If changes Is Nothing OrElse changes.Count = 0 Then
            Return existingJson
        End If

        Dim list As List(Of UsrRrkEntry) = DeserializeHistory(existingJson)
        If list Is Nothing Then list = New List(Of UsrRrkEntry)()

        Dim entry As New UsrRrkEntry() With {
            .Timestamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
            .SyainCode = syainCode,
            .SyainName = syainName,
            .PcName = Environment.MachineName,
            .Changes = changes
        }

        ' 最新の修正が先頭になるように追加
        list.Insert(0, entry)

        Return SerializeHistory(list)
    End Function

    ''' <summary>
    ''' 変更前の値と変更後の値を比較し、異なっていれば UsrRrkChange としてリストに追加
    ''' </summary>
    Public Sub AddChangeIfDifferent(ByVal list As List(Of UsrRrkChange), ByVal fieldName As String, ByVal oldVal As String, ByVal newVal As String)
        If oldVal <> newVal Then
            list.Add(New UsrRrkChange(fieldName, oldVal, newVal))
        End If
    End Sub

    ''' <summary>
    ''' 指定ユーザーの「ユーザーデータ」テーブルの「履歴」列に差分エントリを追記・保存する
    ''' （接続モードに応じてネットワーク原本とローカルを更新）
    ''' </summary>
    Public Sub SaveUserHistoryChanges(ByVal code As String, ByVal changes As List(Of UsrRrkChange))
        If String.IsNullOrWhiteSpace(code) OrElse changes Is Nothing OrElse changes.Count = 0 Then Return

        Dim cdClean As String = GetNumAlp(code)
        If String.IsNullOrWhiteSpace(cdClean) Then Return

        ' 1. 現在の履歴JSONを取得
        Dim existingJson As String = ""
        Try
            If ModeDbLocation = CnModeNet AndAlso CheckNetworkFileExists(OptionNtMplMdb, 1500) Then
                Using cnNt As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionNtMplMdb & "';")
                    cnNt.Open()
                    existingJson = GetUserHistoryJson(cdClean, cnNt)
                End Using
            Else
                existingJson = GetUserHistoryJson(cdClean, CnMplMdb)
            End If
        Catch
        End Try

        ' 2. 新しい履歴JSONを作成
        Dim newHistoryJson As String = AppendHistoryJson(existingJson, OptionDefaultSyainCode, OptionDefaultSyainName, changes)

        ' 3. ユーザーデータテーブルの「履歴」を更新
        Dim sqlUpd As String = "UPDATE ユーザーデータ SET [履歴] = ? WHERE [コード] = ?"
        If ModeDbLocation = CnModeNet AndAlso CheckNetworkFileExists(OptionNtMplMdb, 1500) Then
            Try
                Using cnNt As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionNtMplMdb & "';")
                    cnNt.Open()
                    EnsureRrkColumn(cnNt)
                    Using cmd As New OleDbCommand(sqlUpd, cnNt)
                        cmd.Parameters.Add("rrk", OleDbType.LongVarWChar).Value = ToDbStr(newHistoryJson)
                        cmd.Parameters.Add("cd", OleDbType.VarWChar).Value = cdClean
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            Catch
            End Try
        End If

        Try
            EnsureRrkColumn(CnMplMdb)
            Using cmd As New OleDbCommand(sqlUpd, CnMplMdb)
                cmd.Parameters.Add("rrk", OleDbType.LongVarWChar).Value = ToDbStr(newHistoryJson)
                cmd.Parameters.Add("cd", OleDbType.VarWChar).Value = cdClean
                cmd.ExecuteNonQuery()
            End Using
        Catch
        End Try
    End Sub

End Module
