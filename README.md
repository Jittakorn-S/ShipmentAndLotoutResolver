# Shipment And Lotout Resolver

The Shipment And Lotout Resolver is a .NET Core web application designed to streamline the process of managing and modifying "lot" files by adding a `flow_chk.skp` file to a ZIP archive. This is particularly useful in manufacturing or shipment processes where a digital checkpoint or verification file needs to be added to a package of files. The application provides a simple user interface for users to log in, input a lot number, and have the system automatically handle the file manipulation.

## Features

  * **User Authentication**: Secure login system to ensure only authorized personnel can access the functionality.
  * **Simple Interface**: A clean and intuitive user interface for inputting lot numbers.
  * **Automated File Handling**: Automatically locates the relevant lot folder and ZIP file based on the input lot number.
  * **File Injection**: Adds a `flow_chk.skp` file to the specified ZIP archive.
  * **Error Handling and Logging**: Provides clear feedback to the user and logs errors for troubleshooting.
  * **Session Management**: Manages user sessions to keep users logged in.

## Technologies Used

  * **.NET Core**: The core framework for the web application.
  * **ASP.NET Core MVC**: For building the web application using the Model-View-Controller pattern.
  * **C\#**: The primary programming language.
  * **HTML/CSS**: For the front-end structure and styling.
  * **SweetAlert2**: For beautiful and responsive pop-up messages.
  * **NLog**: For logging application events and errors.
  * **SQL Server**: For the user authentication database.

## Project Structure

The project follows a standard ASP.NET Core MVC structure:

```
/
|-- Controllers/
|   |-- HomeController.cs       # Handles user requests and application logic
|-- Models/
|   |-- ErrorViewModel.cs
|   |-- FileRepository.cs       # Implements file handling logic
|   |-- IFileRepository.cs      # Interface for the file repository
|   |-- InterfaceUser.cs        # Interface for the user repository
|   |-- UserModel.cs
|   `-- UserRepository.cs       # Implements user authentication logic
|-- Views/
|   |-- Home/
|   |   |-- Index.cshtml
|   |   `-- ShipmentAndLotout.cshtml
|   `-- Shared/
|       |-- _Layout.cshtml
|       `-- _ValidationScriptsPartial.cshtml
|-- wwwroot/
|-- appsettings.json            # Configuration file for database connections and file paths
|-- nlog.config                 # Configuration for the NLog logging library
|-- Program.cs                  # Main entry point of the application
`-- README.md                   # This file
```

## Configuration

Before running the application, you need to configure the following in `appsettings.json`:

1.  **Database Connection String**: Update the `DBConnection` with your SQL Server details.

    ```json
    "ConnectionStrings": {
        "DBConnection": "Server=YOUR_SERVER;Database=YOUR_DB;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;"
    }
    ```

2.  **File Paths**: Set the correct paths for `LotPath` and `LogDataPath`.

    ```json
    "Paths": {
        "LotPath": "\\\\your_server\\path\\to\\lots\\",
        "LogDataPath": "C:\\path\\to\\your\\logs\\"
    }
    ```

## How to Run the Project

1.  **Clone the repository**:
    ```bash
    git clone https://github.com/your-username/ShipmentAndLotoutResolver.git
    ```
2.  **Open in Visual Studio**: Open the `.sln` file in Visual Studio.
3.  **Restore Dependencies**: Build the project to restore all the NuGet packages.
4.  **Update `appsettings.json`**: Configure your database connection and file paths as described above.
5.  **Run the application**: Press F5 or the "Run" button in Visual Studio.

## Dependencies

  * [sweetalert2](https://www.npmjs.com/package/sweetalert2) `^11.4.20`
