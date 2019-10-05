set aimpFolder=C:\Users\aarek\Desktop\AIMP_4.60.2146_debug\
set pluginFolder=%aimpFolder%Plugins\AimpLyrics
mkdir %pluginFolder%
copy ..\..\..\..\packages\AimpSDK.4.60.2144.1\lib\net462\aimp_dotnet.dll %pluginFolder%\AimpLyrics.dll
copy AimpLyrics.dll %pluginFolder%\AimpLyricsPlugin.dll
copy AIMP.SDK.dll %pluginFolder%
