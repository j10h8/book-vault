# BookVault

**Overview**

BookVault is a showcase/portfolio demo project, and is intended to be used for demonstration purposes only. The application is built as a Blazor Server project that integrates with a SQL database, and demonstrates comprehensive CRUD operations and sophisticated sort/filtering functionality. Dependency Injection and Repository Pattern is used, ensuring loose coupling and modularity, as well as abstraction over all database operations. The solution is deployed and readily accessible at [BookVault on Azure](https://blazor-deploy-1.azurewebsites.net/).

**Local Deployment Instructions**

To run the application locally, please follow these steps:

- Provide a Font Awesome Kit embed code in the **\<head\>** element in the **\_Host.cshtml** file

- Set up a local database:

  - Define a local connection string as a value for "Main" in the appsettings.json file (e.g. "Server=(localdb)\\MSSQLLocalDB;Database=MyLocalDb;Integrated Security=true;")
  - Generate a new migration, by running

    ```
    add-migration migrationName
    ```

    in the **Package Manager Console**.

- Execute the migration, by running

  ```
  update-database
  ```

  in the **Package Manager Console**.

By adhering to these steps, you can effortlessly deploy and run the BookVault application locally. Enjoy the convenience of managing your book collection with ease.
