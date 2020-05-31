# #https://www.youtube.com/watch?v=f0lMGPB10bM
# #krijg de basis van Microsoft
# FROM mcr.Microsoft.com/dotnet/core/sdk:2.2 AS build-env
# WORKDIR /app

# #copy the CSPROJ file nad restore any dependecies (via NUGET)
# COPY *.csproj ./
# RUN dotnet restore

# #Install node
# FROM node:alpine AS websiteDocker
# WORKDIR /app
# COPY . .
# RUN npm install 

# #intall .net
# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

# #copy the project files and build our release
# COPY . ./
# RUN dotnet publish -c Release -o out

# #generate runtime image
# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
# WORKDIR /app
# EXPOSE 80
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "Project_API2.dll"]

# https://medium.com/better-programming/how-to-create-an-angular-dockerfile-75c059e7f8e8
# stage 1
FROM node:12.7-alpine AS build
WORKDIR /app
COPY . .
RUN npm install 
RUN npm run build

# stage 2
FROM nginx:alpine
COPY --from=build /app/dist/* /usr/share/nginx/html
EXPOSE 80