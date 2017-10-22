FROM microsoft/dotnet:2.0-sdk

COPY . /app
WORKDIR /app

RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]

EXPOSE 8080/tcp
ENV ASPNETCORE_URLS http://*:8080

ENTRYPOINT ["dotnet", "run"]
