# Basic Billing API

### How the API works
This API works as an interface between the client and server using HTTP protocol to make requests these requests will be pass through **ASP NET Core** middleware and be redirected to the correct controller. The Controller will communicate with the service and the service using **EntityFramework Core** will gather or insert information from SQLite Database.
### How to build
To build the app you need to run the next command on directory **BasicBilling.API**

```
dotnet restore
```

### How to test
To run tests you need to execute the next command in **BasicBilling.Tests**
```
dotnet restore
dotnet test
```
### Navigate using swagger
```
cd BasicBilling.API
dotnet run
```
Go to http://localhost:5206/swagger/index.html

### Future functionalities

#### Payment history
Due to lack of time this feature wasn't included.
#### Create a classlib
I need to do research to redesign the App.
