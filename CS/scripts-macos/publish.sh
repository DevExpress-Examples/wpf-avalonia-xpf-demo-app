#!/bin/bash

publish-core() {
    # $1 - architecture (x64 or arm64)
    CSPROJ="./../AvaloniaXpfDemo/AvaloniaXpfDemo.Xpf.csproj"
    APP_NAME="./../publish/macos-$1/AvaloniaXpfDemo.app"
    PUBLISH_ROOT_DIR="./../publish/macos-$1"
    PUBLISH_OUTPUT_DIR="./../publish/macos-$1/bin/."
    INFO_PLIST="./Info.plist"
    ICON_FILE_NAME="AppIcon.icns"
    ICON_FILE="./../publish/macos-$1/AppIcon.icns"
    ICON_SET="./../icon.iconset"
    ICON_SET_RES="./../icon.icns"

    echo "Publishing $APP_NAME"

    rm -rf $PUBLISH_ROOT_DIR
    mkdir -p $PUBLISH_ROOT_DIR

    iconutil -c icns $ICON_SET
    mv $ICON_SET_RES $ICON_FILE

    dotnet publish -c Release --self-contained true -r osx-$1 $CSPROJ --output $PUBLISH_OUTPUT_DIR

    if [ -d "$APP_NAME" ]
    then
        rm -rf "$APP_NAME"
    fi

    mkdir "$APP_NAME"
    mkdir "$APP_NAME/Contents"
    mkdir "$APP_NAME/Contents/MacOS"
    mkdir "$APP_NAME/Contents/Resources"

    cp "$INFO_PLIST" "$APP_NAME/Contents/Info.plist"
    cp "$ICON_FILE" "$APP_NAME/Contents/Resources/$ICON_FILE_NAME"
    cp -a "$PUBLISH_OUTPUT_DIR" "$APP_NAME/Contents/MacOS"
}

publish-core "x64"
publish-core "arm64"
