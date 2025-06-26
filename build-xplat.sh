#!/bin/bash
set -e

APP_NAME="CalculateAreaLibrary.csproj"  # Replace with your actual .csproj file
OUTPUT_DIR="bin"

echo "::group::Testing..."
dotnet test
echo "::endgroup::"

mkdir -p $OUTPUT_DIR

platforms=("win-x64" "linux-x64" "osx-x64")
for rid in "${platforms[@]}"
do
    output_name="$OUTPUT_DIR/$rid"

    echo "::group::Publishing for $rid..."
    dotnet publish $APP_NAME \
        -c Release \
        -r $rid \
        --self-contained true \
        --output $output_path \
        /p:PublishSingleFile=true \
        /p:PublishTrimmed=true
    echo "::endgroup::"

done

echo "::group::tree..."
tree $OUTPUT_DIR
echo "::endgroup::"