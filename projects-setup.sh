#!/bin/sh

dotnet new mvc -o BookTok
dotnet new webapi -o BookTokApi --no-https --use-controllers
