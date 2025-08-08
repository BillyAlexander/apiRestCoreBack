# apiRestCoreBack
This is an app to ilustrate net core back
# 🧾 Backend (ASP.NET Core + Entity Framework)

## 🔧 Create a new project Asp Net Core Web Api
```
dotnet new webapi -n ProductApi
```
Maybe graphically it is easier than with commands

Add dependencies by Nuget (Projects > Admin Packs Nuget)
```
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.SQLServer
```

## 📁 Add Models Folder	

##	🔧 Config DbContext & conn to db

In View > other windows > Console Pack Admin
```
Scaffold-DbContext "Data Source=.\SQLEXPRESS;Database=db_name;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models_Folder -Tables tb_name –Force
```

With credentials (MySql)
```
Scaffold-DbContext "server=servername;port=portnumber;user=username;password=pass;database=databasename" MySql.EntityFrameworkCore -OutputDir Entities –f
```
```
Scaffold-DbContext "Data Source=192.168.3.4,4321;Initial Catalog=db_name;User ID=mi_usuario;Password=mi_contraseña;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models_Folder -Tables tb_name -Force
```

In `appsettings.js` Add conn (& delete in `DbFacturaContext` method)


```
"ConnectionStrings": {
        "myCnn": "Data Source=.\\SQLEXPRESS;Database=db_factura;Trusted_Connection=True;TrustServerCertificate=True;"
    },
```

In  `program.cs`

Add a service
```
builder.Services.AddDbContext<DbFacturaContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("myCnn")
    ));
```
## 📁	Create Repos folder

Add a new interface
```
    IEnumerable<Factura> facturas();

    Factura finFacturaById(int id);

    Task<Factura> createFacturaAsync(Factura factura);

    Task<Factura> updateFacturaAsync(Factura factura);

    Task<bool> deleteFacturaAsync(Factura factura);
```        

Add Class Implementacion 
```
private readonly DbFacturaContext _facturaContext;

public FacturaRepoImpl(DbFacturaContext facturaContext)=> _facturaContext = facturaContext;
```

In `program.cs`
```
builder.Services.AddTransient<FacturaRepo, FacturaRepoImpl>();
```

## 🧩 	Create controller with endpoints CRUD
```
[Route("api/[controller]")]
[ApiController]
```
```
private readonly  FacturaRepo _facturaRepo;

public FacturaController(FacturaRepo facturaRepo) => _facturaRepo = facturaRepo;
```

If there is an CORS error, in  `program.cs` add (next to `AddTransient`)

 ```
 builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_myAllowSpecificOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
```
And next to `app.UseHttpsRedirection();`

```
app.UseCors("_myAllowSpecificOrigins");
```
