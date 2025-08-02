using Microsoft.EntityFrameworkCore;
using PaymentDemo.Infra.DataBase;
using PaymentDemo.Interfaces.UserStorys;
using PaymentDemo.Models.requests;

namespace PaymentDemo.UserStorys
{
    public class processDataLake : IprocessDataLake
    {
        public async Task<string> GetHeading()
        {

            Log("Inicia Inicializador se secuencia 10 segundos");
            await Task.Delay(1000);

            return "Heading Done !";

        }

        public async Task<List<productsResquest>> getProductsAsync()
        {
            AppDbContext dbContext = new AppDbContext();

            Log("Inicia Lectura de Productos");

            var result = await dbContext.Products.Select(item => new productsResquest
            {
                Name = item.Name,

            }).ToListAsync().ConfigureAwait(false);

            return result;

        }

        static void Log(string mensaje)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff} - {mensaje}");
        }

    }
}
