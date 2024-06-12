#!/bin/sh

echo "Installing system dependencies..."
sudo apt update && sudo apt upgrade -y
sudo apt install -y dotnet-sdk-8.0 \
                    aspnetcore-runtime-8.0 \
                    dotnet-runtime-8.0 \
                    ca-certificates \
                    libc6 \
                    libgcc-s1 \
                    libgssapi-krb5-2 \
                    libicu70 \
                    liblttng-ust1 \
                    libssl3 \
                    libstdc++6 \
                    libunwind8 \
                    zlib1g
sudo apt autoremove

