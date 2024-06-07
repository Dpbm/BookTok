#!/usr/bin/bash

dotnet aspnet-codegenerator controller -name BookController -m Book -dc BookTok.Data.BookTokContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlite
dotnet aspnet-codegenerator controller -name CostumerController -m Costumer -dc BookTok.Data.BookTokContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlite
dotnet aspnet-codegenerator controller -name SaleController -m Sale -dc BookTok.Data.BookTokContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlite