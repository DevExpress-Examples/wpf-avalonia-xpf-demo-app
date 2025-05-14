#!/bin/bash

PUBLISH_ROOT_DIR="./../publish/linux"
PUBLISH_OUTPUT_DIR="./../publish/linux/bin/."
CSPROJ="./../AvaloniaXpfDemo/AvaloniaXpfDemo.Xpf.csproj"
STAGING_FOLDER="./../publish/linux/staging_folder"
ICON_SET="./../icon.iconset"

rm -rf $PUBLISH_ROOT_DIR

# hicolor
mkdir -p $STAGING_FOLDER/usr/share/icons/hicolor/16x16/apps
mkdir -p $STAGING_FOLDER/usr/share/icons/hicolor/32x32/apps
mkdir -p $STAGING_FOLDER/usr/share/icons/hicolor/64x64/apps
mkdir -p $STAGING_FOLDER/usr/share/icons/hicolor/128x128/apps
mkdir -p $STAGING_FOLDER/usr/share/icons/hicolor/256x256/apps
mkdir -p $STAGING_FOLDER/usr/share/icons/hicolor/512x512/apps

cp $ICON_SET/icon_16x16.png $STAGING_FOLDER/usr/share/icons/hicolor/16x16/apps/AvaloniaXpfDemo.png
cp $ICON_SET/icon_32x32.png $STAGING_FOLDER/usr/share/icons/hicolor/32x32/apps/AvaloniaXpfDemo.png
cp $ICON_SET/icon_32x32@2x.png $STAGING_FOLDER/usr/share/icons/hicolor/64x64/apps/AvaloniaXpfDemo.png
cp $ICON_SET/icon_128x128.png $STAGING_FOLDER/usr/share/icons/hicolor/128x128/apps/AvaloniaXpfDemo.png
cp $ICON_SET/icon_256x256.png $STAGING_FOLDER/usr/share/icons/hicolor/256x256/apps/AvaloniaXpfDemo.png
cp $ICON_SET/icon_512x512.png $STAGING_FOLDER/usr/share/icons/hicolor/512x512/apps/AvaloniaXpfDemo.png


# pixmaps
mkdir -p $STAGING_FOLDER/usr/share/pixmaps
cp $ICON_SET/icon_512x512@2x.png $STAGING_FOLDER/usr/share/pixmaps/AvaloniaXpfDemo.png


# .NET publish
dotnet publish $CSPROJ \
  --verbosity quiet \
  --nologo \
  --configuration Release \
  --self-contained true \
  --runtime linux-x64 \
  --output $PUBLISH_OUTPUT_DIR
  
  
# Debian control file
mkdir -p $STAGING_FOLDER/DEBIAN
cp ./control $STAGING_FOLDER/DEBIAN

# Starter script
mkdir -p $STAGING_FOLDER/usr/bin
cp ./AvaloniaXpfDemo.sh $STAGING_FOLDER/usr/bin/AvaloniaXpfDemo
chmod +x $STAGING_FOLDER/usr/bin/AvaloniaXpfDemo


# Other files
mkdir -p $STAGING_FOLDER/usr/lib/AvaloniaXpfDemo
cp -f -a $PUBLISH_OUTPUT_DIR $STAGING_FOLDER/usr/lib/AvaloniaXpfDemo/
chmod -R a+rX $STAGING_FOLDER/usr/lib/AvaloniaXpfDemo/
chmod +x $STAGING_FOLDER/usr/lib/AvaloniaXpfDemo/AvaloniaXpfDemo
  

# Desktop shortcut
mkdir -p $STAGING_FOLDER/usr/share/applications
cp ./AvaloniaXpfDemo.desktop $STAGING_FOLDER/usr/share/applications/AvaloniaXpfDemo.desktop


# Make .deb file
dpkg-deb --root-owner-group --build $STAGING_FOLDER "$PUBLISH_ROOT_DIR/AvaloniaXpfDemo_1.0.0_amd64.deb"