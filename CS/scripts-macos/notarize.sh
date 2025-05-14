#!/bin/bash

# To use notarytool, you first need to store a notarytool credentials profile
# xcrun notarytool store-credentials --apple-id <UserName> --team-id <TeamId> --password <Password> 

notarize-core() {
    # $1 - architecture (x64 or arm64)
    APP_NAME="./../publish/macos-$1/AvaloniaXpfDemo.app"
    ZIP_NAME="./../publish/macos-$1/AvaloniaXpfDemo-$1.zip"
    NOTARY_PROFILE="notarytool-profile"

    echo ""
    echo "Pack the application into a ZIP archive before sending it for notarization"
    ditto -c -k --sequesterRsrc --keepParent $APP_NAME $ZIP_NAME

    echo "Notarizing"
    xcrun notarytool submit $ZIP_NAME --keychain-profile $NOTARY_PROFILE --wait
    
    echo "Stapling"
    xcrun stapler staple $APP_NAME
    xcrun stapler validate $APP_NAME

    echo "Pack the application into the resulting ZIP archive"
    rm $ZIP_NAME
    ditto -c -k --sequesterRsrc --keepParent $APP_NAME $ZIP_NAME
}

notarize-core "x64"
notarize-core "arm64"