FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY TostiBackEnd/TostiBackEnd.csproj TostiBackEnd/
COPY TostiBusinessEntities/TostiBusinessEntities.csproj TostiBusinessEntities/
RUN dotnet restore TostiBackEnd/TostiBackEnd.csproj
COPY . .
WORKDIR /src/TostiBackEnd
RUN dotnet build TostiBackEnd.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish TostiBackEnd.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TostiBackEnd.dll"]
