
@echo off 
set /p version="Enter Version: " %=%
:set /p host="Enter Host: " %=%
:set  mage="C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\mage.exe"
set rootpath="C:\Users\Administrator\Desktop\ComicDL\Release\"
set hostprovider="http://comicdownloader.vv.si/updates/ComicDownloader.application"

DEL /F /Q /S %version%\*.*

md %version%

xcopy  %rootpath%*.* %version% /exclude:excludedfileslist.txt /e /i /y

mage -New Application -Processor x86 -ToFile %version%\ComicDownloader.exe.manifest -name "Comic Downloader" -Version %version% -FromDirectory %version% 
MageEx.exe -icon Resources\1364394623_37693.ico %version%\ComicDownloader.exe.manifest

mage -Sign %version%\ComicDownloader.exe.manifest -CertFile ComicDownloader.pfx

mage -New Deployment -Processor x86 -Install true -Version %version% -Publisher "samuraitruong@hotmail.com" -ProviderUrl %hostprovider% -AppManifest %version%\ComicDownloader.exe.manifest -ToFile ComicDownloader.application

mage -Sign ComicDownloader.application -CertFile ComicDownloader.pfx

