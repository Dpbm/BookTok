#!/bin/sh

dotnet ef migrations add UpdateSale
dotnet ef database update