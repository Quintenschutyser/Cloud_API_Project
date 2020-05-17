# FROM node:10
# WORKDIR /usr/src/app
# COPY package*.json ./
# RUN npm install

# COPY . .
# EXPOSE 7999
# CMD [ "node", "server.js"]

FROM node:alpine AS websiteDocker
WORKDIR /app
COPY . .
RUN npm install 
RUN npm run build

FROM nginx:alpine
COPY --from=websiteDocker /app/dist/* /usr/share/nginx/html/
EXPOSE 7999