FROM node:lts-alpine as build

RUN export http_proxy=http://proxy-dmz.intel.com:912 && \
    export https_proxy=http://proxy-dmz.intel.com:912 && \
    export no_proxy=localhost,127.0.0.0/8,10.0.0.0/8,.intel.com && \
    npm config set proxy=http://proxy-dmz.intel.com:912

WORKDIR /app
COPY package.json ./
RUN npm install
COPY . .
RUN npm run build

# Stage 2: Serve the application with Nginx
FROM nginx:alpine
COPY --from=build /app/dist /usr/share/nginx/html
EXPOSE 3000
ENTRYPOINT ["nginx", "-g", "daemon off;"]