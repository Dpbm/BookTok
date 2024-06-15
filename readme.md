# BookTok


![Build-Test](https://github.com/Dpbm/BookTok/actions/workflows/build-test.yml/badge.svg)
![Docker Hub](https://github.com/Dpbm/BookTok/actions/workflows/dockerhub.yml/badge.svg)
![GHRC](https://github.com/Dpbm/BookTok/actions/workflows/ghrc.yml/badge.svg)

A simple bookstore application to our systems development class final assignment.

## How does it works

The project is made of an api and a mvc core. The former is a webapi .net application running at the port `3000`. This the part committed to handle the books reviews data storing them into a in memory database provided by the microsoft Entity framework. The latter, is a monolitic mvc app created to handle all the remaining data, such as costumers, books and sales, following the default architecture provided by the .net framework.\
To join them together, we're are using http requests pointing to our api, so every time that a review related action is required by the cliente, a request is send and then the json response is treated by the client.   

## Requirements

- [donet8.0](https://learn.microsoft.com/en-us/dotnet/core/install/)


## How to run


### using pure dotnet

First, you need to install all the required dependencies for each part. In each part's directory,there's a `install-dependencies.sh` script to automate this process for linux, however, for windows users, it's a nice idea to look inside the script and run line by line in your terminal (remeber to get into the correct directory) to ensure the correct installation.


```bash
# Linux installation

cd ./BookTok
chmod +x install-dependencies.sh && ./install-dependencies.sh

cd ..

cd ./BookTokApi
chmod +x install-dependencies.sh && ./install-dependencies.sh
```

After that, is spected to have a `.env` file inside [BookTok directory](./BookTok/), this file is used to kept track the api uri. So, after installing all, go to this directory and do the following:

```bash
# for linux
cd ./BookTok
echo 'API_BASE_URL=http://localhost:3000/api/' >> .env
```

In case you are running the api in a different port or location, just change the `http://localhost:3000/` to point to your uri.
 

After that, you can run the project itself. To do that, you may run at the same time both api and core applications in different terminal instances.


```bash

# instance 1
cd ./BookTok
dotnet run

# instance 2
cd ./BookTokApi
dotnet run
```

If you prefer, you can use [concurrently](https://www.npmjs.com/package/concurrently) to run them in the same instance, but for this you must have [nodejs](https://nodejs.org/en) installed.

```bash
# intall concurrently
npm install

npm run dotnet:dev # run the application with hot-reload
#or
npm run dotnet:start
```

### using docker

There're docker images available to quickly run the application:
```bash

# from dockerhub
docker run -d -p 3000:3000 dpbm32/booktokapi
docker run -d -p 8080:8080 -e API_BASE_URL="http://localhost:3000/api/" dpbm32/booktok

# or from ghrc
docker run -d -p 3000:3000 ghcr.io/dpbm/booktok:api
docker run -d -p 8080:8080 -e API_BASE_URL="http://localhost:3000/api/" ghcr.io/dpbm/booktok:mvc
```

If you prefer, a docker compose file is available as well:

```bash
docker compose up -d
```


## Group

The members of the group are:\
    - [Alexandre](https://github.com/Dpbm)(me)\
    - [Gabriela](https://github.com/Gsr13)\
    - Hugo