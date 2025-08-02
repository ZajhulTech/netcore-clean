dotnet new sln -o PaymentDemo
dotnet new webapi -n PaymentDemo.WebApi --use-controllers -o PaymentDemo.WebApi -f net8.0
dotnet new classlib -o PaymentDemo.Infra -f net8.0
dotnet new classlib -o PaymentDemo.Models -f net8.0
dotnet new classlib -o PaymentDemo.UserStorys -f net8.0
dotnet new classlib -o PaymentDemo.Interfaces -f net8.0

dotnet sln PaymentDemo.sln add PaymentDemo.WebApi/PaymentDemo.WebApi.csproj
dotnet sln PaymentDemo.sln add PaymentDemo.Infra/PaymentDemo.Infra.csproj
dotnet sln PaymentDemo.sln add PaymentDemo.Models/PaymentDemo.Models.csproj
dotnet sln PaymentDemo.sln add PaymentDemo.UserStorys/PaymentDemo.UserStorys.csproj
dotnet sln PaymentDemo.sln add PaymentDemo.Interfaces/PaymentDemo.Interfaces.csproj

// dependencies
dotnet add PaymentDemo.Infra/PaymentDemo.Infra.csproj reference PaymentDemo.Models/PaymentDemo.Models.csproj
dotnet add PaymentDemo.WebApi/PaymentDemo.WebApi.csproj reference PaymentDemo.Infra/PaymentDemo.Infra.csproj
dotnet add PaymentDemo.WebApi/PaymentDemo.WebApi.csproj reference PaymentDemo.UserStorys/PaymentDemo.UserStorys.csproj

dotnet add PaymentDemo.UserStorys/PaymentDemo.UserStorys.csproj reference PaymentDemo.Models/PaymentDemo.Models.csproj
dotnet add PaymentDemo.UserStorys/PaymentDemo.UserStorys.csproj reference PaymentDemo.Interfaces/PaymentDemo.Interfaces.csproj
dotnet add PaymentDemo.Infra/PaymentDemo.Infra.csproj reference PaymentDemo.Interfaces/PaymentDemo.Interfaces.csproj


// ef core
// cadena ejemplo  APP_DB=Server=demo_control.mssql.somee.com;Database=demo_control;User Id=SaulDuenas_SQLLogin_1;pwd=elmasmejor;TrustServerCertificate=true;

cd PaymentDemo.Infra
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design


dotnet ef dbcontext scaffold "Server=localhost;Database=TuDB;User Id=usuario;Password=clave;" \
Microsoft.EntityFrameworkCore.SqlServer \
--project Infrastructure \
--output-dir Persistence\Models \
--context-dir Persistence \
--context TuDbContext \
--use-database-names \
--no-onconfiguring \
--force

dotnet ef dbcontext scaffold "Server=demo_control.mssql.somee.com;Database=demo_control;User Id=SaulDuenas_SQLLogin_1;pwd=elmasmejor;TrustServerCertificate=true;" --context AppDbContext --project ./PaymentDemo.Infra/PaymentDemo.Infra.csproj Microsoft.EntityFrameworkCore.SqlServer --output-dir DataBase