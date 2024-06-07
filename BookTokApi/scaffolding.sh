#!/usr/bin/bash

dotnet aspnet-codegenerator controller -name BooksController -async -api -m Book -dc BookContext -outDir Controllers
