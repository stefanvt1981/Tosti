FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["TostiFrontEnd/TostiFrontEnd.csproj", "TostiFrontEnd/"]
RUN dotnet restore "TostiFrontEnd/TostiFrontEnd.csproj"
COPY . .
WORKDIR "/src/TostiFrontEnd"
RUN dotnet build "TostiFrontEnd.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TostiFrontEnd.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TostiFrontEnd.dll"]