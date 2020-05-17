# FROM node:10
# WORKDIR /usr/src/app
# COPY package*.json ./
# RUN npm install

# COPY . .
# EXPOSE 7999
# CMD [ "node", "server.js"]

# stage 1

FROM node:alpine AS websiteDocker
WORKDIR /src/app
COPY . .
RUN npm install && npm run build

# stage 2

FROM nginx:alpine
COPY --from=websiteDocker /app/dist/* /usr/share/nginx/html
EXPOSE 7999