set aimpFolder=C:\Users\aarek\Desktop\AIMP_4.60.2146_debug\
set pluginFolder=%aimpFolder%Plugins\AimpLyrics
mkdir %pluginFolder%
copy aimp_dotnet.dll %pluginFolder%\AimpLyrics.dll
copy AimpLyrics.dll %pluginFolder%\AimpLyricsPlugin.dll
copy AIMP.SDK.dll %pluginFolder%
