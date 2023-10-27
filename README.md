# Assesment - Izzah Shazwani

Creating a Web API using Visual Studio 2022, SQL Server 2019 and SSMS 2019

## Step 1: Installation

Setup and Download Environment

[Visual Studio Community 2022](https://visualstudio.microsoft.com/vs/), [SQL Server 2019](https://go.microsoft.com/fwlink/?linkid=866662), [SSMS](https://aka.ms/ssmsfullsetup)

## Step 2: Create a New ASP.NET Core Web API Project

1. Open Visual Studio 2019.
2. Click on "Create a new project."
3. Select ***ASP.NET Core Web API*** template.
4. Name your project and select a location for it.
5. Click "Create."

## Step 3: Define the User Model

1. Create 'Model' folder.
2. Right-click the 'Model' folder. Select **_Add -> Class_**, name it 'Users' and click **_Add_**.
3. Then, add the following properties to the class.

```c#
public int id { get; set; }

public string Username { get; set; }

public string Mail { get; set; }

public string PhoneNumber { get; set; }

public string Skillsets { get; set; }

public string Hobby { get; set; }
```
## Step 4: Installing Entity Framework

1. Right-click project and select **_Manage NuGet Packages…_**
2. Search for Microsoft.EntityFrameworkCore and download below packages
![entityframeworkcore](C:\Users\Acer\OneDrive\Desktop\entityframework.png)

## Step 5: Adding Database Context

1. Right-click 'Model' folder and select **_Add -> Class_**.
2. Name the class as ***UserDbContext*** and then click **_Add_**.
3. Add below codes in the class.

```c#
public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

    public DbSet<Users> User { get; set; } = null!;
}
```

## Step 6: Create API Controller and Methods

1. Right-click on **_Controller_** folder and select **_Add -> Controller_**.
2. Then, select **_API Controller - Empty_** as below.
![apicontroller]("C:\Users\Acer\Videos\Captures\apicontroller.png")
3. Click **_Add_** then name it **_UsersController_**.
4. Then add the CRUD (create, read, update, and delete) action methods following the below codes in the controller.
```c#
private readonly UserDbContext _context;

public UsersController(UserDbContext context) {
    _context = context;
}

//GET: api/Users
[HttpGet]
public ActionResult<IEnumerable<Users>> GetUsers()
{
    var users = _context.User.ToList();
    return users;
}

//POST: api/Users
[HttpPost]
public ActionResult<Users> CreateUser(Users user)
{
    _context.User.Add(user);
    _context.SaveChanges();
    return user;
}

//PUT: api/Users
[HttpPut("{id}")]
public ActionResult<Users> UpdateUser(int id, Users updatedUser)
{
    var user = _context.User.Find(id);
    if (user == null)
    {
        return NotFound();
    }

    // Update user attributes here

    _context.SaveChanges();
    return user;
}

//POST: api/Users
[HttpDelete("{id}")]
public ActionResult DeleteUser(int id)
{
    var user = _context.User.Find(id);
    if (user == null)
    {
        return NotFound();
    }

    _context.User.Remove(user);
    _context.SaveChanges();
    return NoContent();
}
```
5. Replace [controller] to the controller we created before which is ***UsersControllers***

## Step 7: Database Connection Configuration

1. Open ***SSMS***.
2. Connect to server.
3. In the server, create a database named ***Users***.
4. Then back to Visual Studio, open ***appsetting.json*** and add connection string like below and replace the server and database using your own.
```c#
"ConnectionStrings": {
    "DefaultConnection": "Server=YourServerName;Database=YourDatabaseName;Trusted_Connection=True;"
}
```

## Step 8: Apply Database Migration
1. Open ***Tools -> Package Manager Console***
2. Run the following command.
```bash
Add-Migration InitialCreate
Update-Database
```

## Step 9: Test API Methods
1. Go to the ***SQL Server Object Explorer*** and right-click the ***Users*** table and select View Data.
2. Add some users record manually to the table excluding the ID column.
3. Then test by running(CTRL+F5) the application.
4. Select the ***GET*** method and click ***Try it out -> Execute***. This shows all users record that have been input manually earlier.
5. After that, select ***POST*** method and click ***Try it out***, then input users information by replacing the string excluding the id field, then click ***Execute***.
6. The user information that been input earlier has been added in the database.
7. Then, select ***PUT*** method. Click ***Try it out*** then input id in the id field and update the users information and then click ***Execute***.
8. This method updated the users information.
9. Lastly, select ***DELETE*** method and click ***Try it out***. Input the id of the users information that we want to delete in the id field and click ***Execute***.
10. This method deleted the user information.
