# Marketplace

P2P marketplace for selling and buying outdoor gear. Built on ASP.NET Core using clean architecture, MySQL, EF Core and Next.js with React and Typescript.

Made as a bachelor thesis at Faculty of Mathematics and Physics, Charles University, 2024/2025.  

# How to run

**WARNING** - there are .env files commited to this repository. This is for testing and/or illustrative purposes, what they should look like. You should not push .env files with important connection strings, passwords into repositories. 

You need to have installed [Docker](https://www.docker.com/).

Then you can configure connection strings and data in an .env file in this folder. 
Then run 

```
docker-compose build
```

and after the build to run the containers run 

```
docker-compose up
```

## How to run in developer mode

If you would like to run the application in developer mode outside of Docker, it needs more setup. 

You need to have installed and setup [MySQL](https://dev.mysql.com/doc/mysql-getting-started/en/) with an available user. You can do so in docker or directly on your computer.

Then you need to configure .env file in /Backend/WebApi to reflect connection to your database. 

The initial database will be empty and without tables. To create tables, you can either run

```
Update-Database
```

in Package Manager Console in Visual Studio in the Infrastructure project, or use
`/Database/01-init-schema.sql`.

If you want to seed the database with some initial data, you can use the rest of the .sql
scripts in the `/Database` folder

You also need to configure an .env.local file in /Frontend/src to reflect, where your
backend application is serving data. 
