# escape=`
FROM microsoft/aspnetcore-build:2.0.3-2.1.2 AS builder

WORKDIR /src
COPY src/App.Web/App.Web.csproj .
RUN dotnet restore

COPY src/App.Web/package.json .
RUN npm install

COPY src/App.Web .
RUN dotnet publish

# app image
FROM microsoft/aspnetcore:2.0.3-stretch

ENV APIURL='http://localhost:5001'
CMD ["dotnet", "App.Web.dll"]

#HEALTHCHECK --interval=12s --start-period=30s --retries=5 `
# CMD curl --fail --max-time 10 http://localhost/health/check || exit 1

WORKDIR /dotnetapp
COPY --from=builder /src/bin/Debug/netcoreapp2.0/publish .