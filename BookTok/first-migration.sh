#!/usr/bin/bash

dotnet ef migrations add InitialCreate
dotnet ef database update