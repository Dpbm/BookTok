#!/bin/sh

dotnet aspnet-codegenerator controller -name ReviewsController -async -api -m Review -dc ReviewContext -outDir Controllers
