REf> https://github.com/ZeBobo5/Vlc.DotNet

############Windows########
 dotnet add package VideoLAN.LibVLC.Windows

############Linux##########

#1 - instalando mono
https://www.mono-project.com/download/stable/#download-lin

#2 - Instalando libvlc (https://code.videolan.org/videolan/LibVLCSharp/blob/master/docs/linux-setup.md)
apt-get install libvlc-dev

#3 - instalando GtSharp
apt-get install gtk-sharp2

#4 - instalando Vlc.DotNet.Core
dotnet add package Vlc.DotNet.Core --version 2.2.1