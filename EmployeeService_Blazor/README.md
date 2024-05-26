
**Project Name:** Employee Management Blazor Web App

**Description**

This Blazor web application provides a user-friendly interface for managing employee data and their associated countries. It leverages a RESTful API for data persistence and communication.
![image](https://github.com/AhmedAboraya99/DotNet_Projects/assets/54743198/4eda10cb-0098-4715-844e-5ac5c4391a0b)
![image](https://github.com/AhmedAboraya99/DotNet_Projects/assets/54743198/18d933db-dc63-4cc3-a2af-4a9929221e7d)
![image](https://github.com/AhmedAboraya99/DotNet_Projects/assets/54743198/3dac9cce-1ef9-4d9f-a916-8957b7fa0b6b)
![image](https://github.com/AhmedAboraya99/DotNet_Projects/assets/54743198/20106de7-ff18-48b7-a41f-93034fecff1d)

**Key Features**

- **Employee Management:**
    - Create, read, update, and delete (CRUD) employee records.
    - View employee details, including their associated country.
- **Country Management:**
    - View a list of available countries. (Optional: CRUD operations for countries can be added here if needed)
- **RESTful API:**
    - Exposes CRUD endpoints for employees and potentially countries (if implemented).
    - Follows RESTful design principles for consistency and predictability.

**Function APIs**

The API provides the following function APIs for managing employee data:
![image](https://github.com/AhmedAboraya99/DotNet_Projects/assets/54743198/4feaf29b-5b41-4ac2-82ea-577b575f3bb8)

* **GET /api/Employee** - Retrieves a list of all employees.
* **GET /api/Employee/{id}** - Retrieves a specific employee by ID.
* **POST /api/Employee** - Creates a new employee.
* **PUT /api/Employee/{id}** - Updates an existing employee.
* **DELETE /api/Employee/{id}** - Deletes an employee.

** Function APIs for Country Management**
![image](https://github.com/AhmedAboraya99/DotNet_Projects/assets/54743198/9a0c31bb-afe9-4fbf-a378-f720f0988061)

* **GET /api/Country** - Retrieves a list of all countries.
* **GET /api/Country/{id}** - Retrieves a specific country by ID. (if applicable)
* **POST /api/Country** - Creates a new country. (if applicable)
* **PUT /api/Country/{id}** - Updates an existing country. (if applicable)
* **DELETE /api/Country/{id}** - Deletes a country. (if applicable)

**Prerequisites**

- .NET SDK (refer to [https://dotnet.microsoft.com/en-us/download](https://dotnet.microsoft.com/en-us/download) for installation instructions)
- Visual Studio or a preferred code editor

**Running the Application**

1. Clone this repository.
2. Open the solution file (`.sln`) in Visual Studio or your code editor.
3. Ensure the project references the correct NuGet packages for Blazor and API development.
4. Configure connection strings and any other necessary settings in the appropriate configuration files.
5. Run the application (typically by pressing F5 in Visual Studio).
