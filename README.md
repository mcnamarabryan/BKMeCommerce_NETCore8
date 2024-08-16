# BKMeCommerce

BKMeCommerce is an e-commerce web application built with .NET Core 8. It provides a foundation for managing products, categories, and customer orders.

## Features

- **Product Management:** Add, update, and remove products with ease.
- **Category Management:** Organize products into categories.
- **User Authentication:** Secure user authentication using ASP.NET Identity.
- **Role Management:** Assign roles to users, such as Admin, Customer, and Company.

## Technologies Used

- .NET Core 8
- Entity Framework Core
- ASP.NET Identity
- Bootstrap 5

## Getting Started

1. **Clone the repository:**

   ```sh
   git clone https://github.com/mcnamarabryan/BKMeCommerce_NETCore8.git
   cd BKMeCommerce_NETCore8
2. Build and run the application:

	Open the solution in Visual Studio.

	Restore the NuGet packages and build the project.
  
	Update the database:

	```sh
	dotnet ef database update
	Run the application.

3. Docker Support:

	The project includes Docker support. Use the provided docker-compose.yml to set up the required services.
	```sh
	docker-compose up -d

## License
This project is licensed under the MIT License.