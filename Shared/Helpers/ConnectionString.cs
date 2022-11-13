using Microsoft.Extensions.Configuration;
namespace Shared.Helpers
{
    public static class ConnectionString
    {
        public static string GetConnectionString() => "Data Source=DESKTOP-L5SA0GV;Initial Catalog=RecipesBorrador;Integrated Security=True";
    }
}
