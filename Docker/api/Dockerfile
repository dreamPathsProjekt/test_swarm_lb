# escape=`
FROM microsoft/dotnet:2.0.3-sdk-2.1.2-stretch AS builder

WORKDIR /src
COPY src/App.Api/App.Api.csproj .
RUN dotnet restore

COPY src/App.Api .
RUN dotnet publish

# app image
FROM microsoft/aspnetcore:2.0.3-stretch

EXPOSE 5001
CMD ["dotnet", "App.Api.dll"]

#HEALTHCHECK --interval=12s --start-period=30s --retries=5 `
# CMD curl --fail --max-time 10 http://localhost/health/check || exit 1

WORKDIR /dotnetapp
COPY --from=builder /src/bin/Debug/netcoreapp2.0/publish .