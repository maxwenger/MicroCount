FROM nginx:alpine

RUN rm /etc/nginx/conf.d/*
COPY web.conf /etc/nginx/conf.d

COPY ./www /usr/share/nginx/html
