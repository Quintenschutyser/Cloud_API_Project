#krijg de basis van Microsoft
FROM mcr.Microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

#copy the CSPROJ file nad restore any dependecies (via NUGET)
COPY *.csproj ./
RUN dotnet restore

#Install node
FROM node:alpine AS websiteDocker
WORKDIR /app
COPY . .
RUN npm install 

#intall .net
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

#copy the project files and build our release
COPY . ./
RUN dotnet publish -c Release -o out

#generate runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Project_API2.dll"]

# FROM mcr.microsoft.com/dotnet/core/aspnet3.0 AS base
# WORKDIR /app
# EXPOSE 80

# FROM mcr.microsoft.com/dotnet/core/aspnet3.0 AS build
# WORKDIR /src
# COPY ["Project_API2.csproj", "./"]
# RUN dotnet restore "./Project_API2.csproj"
# COPY . .
# WORKDIR "/src/."
# RUN dotnet build "Project_API2.csproj" -c Release -o /app

# FROM build AS publish
# RUN dotnet publish "Project_API2.csproj" -c Release -o /app

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app .
# ENTRYPOINT ["dotnet", "Project_API2.dll"]