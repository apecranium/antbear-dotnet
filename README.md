# antbear-dotnet

[![Build Status](https://travis-ci.org/apecranium/antbear-dotnet.svg?branch=master)](https://travis-ci.org/apecranium/antbear-dotnet)

simple app built with asp.net core and postgres

**install:**
```shell
dotnet restore
```

**database:**
```shell
docker-compose up -d
dotnet ef migrations add init
dotnet ef database update
```

**run:**
```shell
dotnet run
```
