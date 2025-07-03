FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ./EmployeeService.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -r linux-x64 --no-self-contained -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /src

ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 80

COPY --from=build /publish .
ENTRYPOINT ["dotnet", "EmployeeService.dll"]
