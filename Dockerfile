# Imagem base para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia arquivos de solução e projeto e faz restore
COPY shortenUrl.sln ./
COPY shortenUrl.csproj ./
RUN dotnet restore

# Copia todo o restante do código e publica (build + publish)
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Imagem base para runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "shortenUrl.dll"]