set pluginFolder=D:\Programs\AIMP\Plugins\AimpLyrics
:: copy aimp_dotnet.dll %pluginFolder%\AimpLyrics.dll
del %pluginFolder%\log.txt
copy AimpLyrics.dll %pluginFolder%\AimpLyricsPlugin.dll
copy AIMP.SDK.dll %pluginFolder%
