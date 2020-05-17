FROM node:alpine AS websiteDocker
WORKDIR /app
COPY . .
RUN npm install 
RUN npm run build

FROM nginx:alpine
COPY --from=websiteDocker /app/dist/* /usr/share/nginx/html/