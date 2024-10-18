# memo


ytabuchi memo

[Android \(Hyper\-V と AEHD\) エミュレーターのハードウェア アクセラレーションを有効にする \- \.NET MAUI \| Microsoft Learn](https://learn.microsoft.com/ja-jp/dotnet/maui/android/emulator/hardware-acceleration?view=net-maui-8.0)

Windows Home で Hyper-V が利用できない場合は「AEHD を使用した高速化」のセクションを参照してください。

ダウンロードされた AEHD のインストーラーは「ツール＞オプション＞Xamarin＞Android 設定」ダイアログの「Android SDK の場所」に示されているフォルダ（通常のインストールでは `C:\Program Files (x86)\Android\android-sdk` のはずです。）配下の次のフォルダにあります。

`C:\Program Files (x86)\Android\android-sdk\extras\google\Android_Emulator_Hypervisor_Driver`

このフォルダの `silent_install.bat` を実行したら

```
[SC] StartService はエラー 4294967201 により失敗しました。
```

とのエラー

GitHub で最新の 2.2 をダウンロードしても同じ。

[Android Emulator のハードウェア アクセラレーションを設定する  \|  Android Studio  \|  Android Developers](https://developer.android.com/studio/run/emulator-acceleration?hl=ja#accel-check)

で `emulator-check accel` を実行すると、以下のエラー

```
accel:
0
Please disable Hyper-V before using the Android Emulator.  Start a command prompt as Administrator, run 'bcdedit /set hypervisorlaunchtype off', reboot.WHPX (10.0.22631) is installed and usable.
accel
```

Windows の機能 で Hyper-V はオフ（Windows Home なので項目がそもそもない）だけど、上記設定をして再起動をしてみる。




