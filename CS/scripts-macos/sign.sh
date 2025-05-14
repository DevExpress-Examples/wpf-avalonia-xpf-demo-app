#!/bin/bash

sign-core() {
    APP_NAME=$1
    ENTITLEMENTS="./AvaloniaXpfDemo.entitlements"
    SIGNING_IDENTITY="<Developer ID Application: CompanyName (TeamId)>"

    echo ""
    echo "Signing $APP_NAME"

    find "$APP_NAME/Contents/MacOS/"|while read fname; do
        if [[ -f $fname ]]; then
            codesign --force --timestamp --options=runtime --entitlements "$ENTITLEMENTS" --sign "$SIGNING_IDENTITY" "$fname"
        fi
    done

    codesign --force --timestamp --options=runtime --entitlements "$ENTITLEMENTS" --sign "$SIGNING_IDENTITY" "$APP_NAME"
    codesign --verify --verbose $APP_NAME
}

sign-core "./../publish/macos-x64/AvaloniaXpfDemo.app"
sign-core "./../publish/macos-arm64/AvaloniaXpfDemo.app"