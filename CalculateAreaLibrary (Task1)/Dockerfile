FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /CalculateAreaLibrary

COPY CalculateAreaLibrary/CalculateAreaLibrary.csproj .
RUN dotnet restore

COPY /CalculateAreaLibrary .
RUN dotnet publish -c Release -r linux-x64 --no-self-contained -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /CalculateAreaLibrary
COPY --from=build /publish .
#ENTRYPOINT ["."]
