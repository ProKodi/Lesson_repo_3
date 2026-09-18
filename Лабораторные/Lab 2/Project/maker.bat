



dotnet new sln -n Project


:: Для Code
mkdir Code
cd Code
dotnet new web
dotnet add package Autofac
cd ..

dotnet sln add Code/Code.csproj





:: Для Test
mkdir Test
cd Test
dotnet new xunit
dotnet add reference ../Code/Code.csproj
cd ..
dotnet sln add Test/Test.csproj