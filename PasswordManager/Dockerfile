#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["PasswordManager/PasswordManager.csproj", "PasswordManager/"]
RUN dotnet restore "./PasswordManager/PasswordManager.csproj"
COPY . .
WORKDIR "/src/PasswordManager"
RUN dotnet build "./PasswordManager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./PasswordManager.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PasswordManager.dll"]