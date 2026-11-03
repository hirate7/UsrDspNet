# UsrDspNet プロジェクト仕様・開発ガイドライン

## 1. プロジェクト概要
- **ソリューション**: `UsrDspNet.sln`
- **対象フレームワーク**: .NET Framework 4.7.2 (VB.NET, Windows Forms)
- **ビルドアーキテクチャ**: **x86 必須**（Microsoft.Jet.OLEDB.4.0 32bit ドライバを利用するため Any CPU / x64 は不可）
- **主要な目的**: VB6版顧客管理アプリ（UsrDsp）の VB.NET への移行・機能拡張・保守

## 2. データベース構成 & モード
- **Mpl.mdb**: ユーザーデータ・拡張データ
- **Mnt.mdb**: メンテナンス記録
- **Prt.mdb**: 印刷リスト
- **ネットワークパス**: `\\nas001\ud4data\Mpl.mdb`, `\\nas001\ud4data\Mnt.mdb`
- **ローカルパス**: `C:\Users\hirat\Documents\UsrDspData\`（または `C:\UsrDsp\` フォールバック）
- **接続モード**:
  - `CnModeNet (0)`: ネットワーク接続モード（Mnt.mdb はネットワーク上の実データを直接更新）
  - `CnModeLocal (1)`: ローカルモード（ローカルの Mnt.mdb を参照・更新）
  - 起動時に `CheckNetworkFileExistsWithRetry` で自動リトライ（最大3回・約10秒）を行い、PC起動直後のSMB接続待ちに対応。接続失敗時は再試行/キャンセルのダイアログを表示。

## 3. 主要な仕様と実装詳細
- **閲覧履歴 (rrk.txt)**:
  - 起動時に `LoadRrkHistory()` で履歴最後のユーザーコードを取得し、初期表示（`DspFirst(initialCode)`）。
  - 詳細表示後、6秒（`tmrRrk.Interval = 6000`）経過すると `tmrRrk_Tick` で履歴に自動追記。
  - 履歴コンボボックス（`cmbRrk`）から選択した場合も `SelectUserByCode` が呼ばれ、6秒タイマーが再起動される。
- **Google マップ連携**:
  - `btnGoogleMap`: 住所欄（`txtAdd`）の文字列から検索URLを生成して開く。
  - `btnGmapLink1`〜`3`（「1」「2」「3」ボタン）: `拡張データ` テーブルの `GMapLink1`〜`GMapLink3` に登録されたダイレクトURLを開く。未登録時は非表示。
- **メンテナンス記録編集 (FrmMntEdit)**:
  - 開いた際に内容テキスト（`txtSagyou`）が全選択状態にならないよう制御済み（カーソルを末尾に配置）。

## 4. ビルド・デプロイ手順 (PowerShell)
```powershell
# 1. 実行中プロセスの停止
Stop-Process -Name 'UsrDspNet', 'UsrDsp' -Force -ErrorAction SilentlyContinue

# 2. MSBuild でビルド (x86 必須)
& 'C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe' 'C:\Users\hirat\source\repos\UsrDspNet\UsrDspNet.sln' /p:Configuration=Debug /p:Platform=x86 /v:minimal

# 3. デスクトップの実行ファイルへ反映
Copy-Item 'C:\Users\hirat\source\repos\UsrDspNet\UsrDspNet\bin\Debug\UsrDspNet.exe' 'C:\Users\hirat\Desktop\UsrDspNet.exe' -Force
Copy-Item 'C:\Users\hirat\source\repos\UsrDspNet\UsrDspNet\bin\Debug\UsrDspNet.exe' 'C:\Users\hirat\Desktop\UsrDsp.exe' -Force
```
