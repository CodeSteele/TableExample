namespace TableExample.App.Controllers
{
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; }

        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeModel();
            var sql = "SELECT TOP 10 * FROM [Table]";
            using (var sqlConnection = new SqlConnection(Configuration.GetConnectionString("Database")))
            using (var sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                var sqlReader = sqlCommand.ExecuteReader();
                while (await sqlReader.ReadAsync())
                {
                    model.Rows.Add(new HomeModel.Row
                    {
                        Value1 = (string)sqlReader["Value1"],
                        Value2 = (string)sqlReader["Value2"]
                    });
                }
            }

            return View(model);
        }
    }
}
