#Pulling node image
FROM node:11 as node

#Setting work directory
WORKDIR /app

#Copying application files
COPY ./Frontend .

#Compiling code
RUN npm ci

#Setting up environment
ARG NG_ENV=production

#Preparing build
RUN npm run ng build -- --configuration=$NG_ENV


#Creating run time environment
FROM nginx:alpine

#Copy build files
COPY ./Frontend/nginx.conf /etc/nginx/nginx.conf
COPY --from=node /app/dist/weatherManApp /usr/share/nginx/html
