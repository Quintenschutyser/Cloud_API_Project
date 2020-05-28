FROM node:alpine AS websiteExam
WORKDIR /app
COPY . .
RUN npm install 
RUN npm run build

# stage 2

FROM nginx:alpine
COPY --from=websiteExam /app/dist/app-to-run-inside-docker /usr/share/nginx/html
EXPOSE 80

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