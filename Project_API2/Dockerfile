FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime

WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "core-api.dll"]

# FROM node:12.7-alpine AS websiteAPI
# WORKDIR /app
# COPY package.json ./
# RUN npm install
# RUN npm run build --prod

# FROM nginx:alpine
# COPY --from=websiteAPI /app/dist/* usr/share/nginx/html

#COPY --from=my-app-build /dist/* /usr/share/nginx/html

# #krijg de basis van Microsoft
# FROM mcr.Microsoft.com/dotnet/core/sdk:2.2 AS build-env
# WORKDIR /app

# #copy the CSPROJ file nad restore any dependecies (via NUGET)
# COPY *.csproj ./
# RUN dotnet restore

# #Add NPM commands
# FROM node:alpine AS websiteDocker
# WORKDIR /app
# COPY . .
# RUN npm install 
# RUN npm run build

# #copy the project files and build our release
# COPY . ./
# RUN dotnet publish -c Release -o out

# #generate runtime image
# FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
# WORKDIR /app
# EXPOSE 80
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "Project_API2.dll"]