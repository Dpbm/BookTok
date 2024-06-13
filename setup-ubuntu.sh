#!/bin/sh

echo "Installing system dependencies..."

sudo apt update && sudo apt upgrade -y
sudo apt install -y wget software-properties-common

wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
sudo apt update

sudo apt install -y dotnet-sdk-8.0 \
                    aspnetcore-runtime-8.0 \
                    dotnet-runtime-8.0 \
                    ca-certificates \
                    libc6 \
                    libgcc-s1 \
                    libgssapi-krb5-2 \
                    libicu-dev \
                    icu-devtools \
                    liblttng-ust-dev \
                    openssl \
                    libssl-dev \
                    libstdc++6 \
                    libunwind8 \
                    zlib1g \
                    curl \
                    jq \
                    liblttng-ust1 \
                    libssl3 \
                    libicu70 
sudo apt autoremove -y

