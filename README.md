# Project name: Webshop API

## The project is in a early stage.

## Project description
#### This is a ASP.Net Core WEB API server, what will provide data to a webshop application.
#### It contains the business logic layer and the database.
#### The frontend project is still in the planning phase.

## Features and aims of the whole project (frontend + backend)
#### In this application you will be able to:
- Register, modify and delete the own registration.
- Find, filter and sort the products.
- Add the products to your cart, and also delet from it.
- Create / add new products, if you have permissions for it.

## Used technologies
- .Net C#
- ASP.Net Core
- Microsoft Entity Framework Core
- Microsoft SQL server

## How to launch while it is not deployed
1. Download the project
2. Open it with an IDE (for example with Visual Studio 2019)
3. Generate the database by the migration file (you can find it in the Migrations folder)
   - With Visual Studio 2019 you can do this with the following steps:
     - Open the Package Manager Console (Tools --> NuGet Package Manager)
     - Type Update-Database, and press Enter
4. Start the application with F5
5. And while the frontend project is not done, you can test the endponts with a 3th party applicatin, for example with Postman.
