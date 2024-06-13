#!/bin/sh

echo "Installing system dependencies..."

apt update && apt upgrade -y
apt install -y wget software-properties-common

wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
apt update

apt install -y dotnet-sdk-8.0 \
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
                    jq
apt autoremove

