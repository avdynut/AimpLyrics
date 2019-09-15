set pluginFolder=D:\Programs\AIMP\Plugins\AimpLyrics
copy ..\..\..\..\packages\AimpSDK.4.60.2144.1\lib\net462\aimp_dotnet.dll %pluginFolder%\AimpLyrics.dll
copy AimpLyrics.dll %pluginFolder%\AimpLyricsPlugin.dll
copy AIMP.SDK.dll %pluginFolder%
