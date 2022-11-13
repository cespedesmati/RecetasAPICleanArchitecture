using Application.Services.Interfaces;
using Infraestructure.Data;
using Shared;

namespace Infraestructure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando Db si no existe..");
            DataContext db = new DataContext();
            db.Database.EnsureCreated();
            Console.WriteLine("OK!");
            Console.ReadKey();

        }
    }
}
