Autor: Daniel Skórczyński
Repo: https://dev.azure.com/pucaj/FizzBuzz

Instruction:
To run application click F5. If problem occurs read adnotation below.

ADNOTATION!
If local database is not working, then you must change server name in two files.

1. Change file "appsettings.json". Replace your local server name with "mssqllocaldb".
2. Change file "Pages/Index.cshtml.cs". Replace your local server name in variable "server" with "mssqllocaldb"

Migration is performed automatically, but if problems occurs write two lines in "package manager console":
1. Write Add-Migration
2. Then write Update-Database

IISExpress problem:
If you cannot run application with IISExpress selected, change run method to "FizzBuzz".