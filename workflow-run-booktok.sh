#!/bin/sh

cd ./BookTok
chmod +x ./install-dependencies.sh
./install-dependencies.sh
dotnet build
