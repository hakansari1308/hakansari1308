using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.Sqlite; // SQLite bağlantısı için bu using eklendi
using GoldenDaisyWebUI.Models;

namespace GoldenDaisyWebUI.Controllers
{
    public class RandevuController : Controller
    {
        private readonly IConfiguration _configuration;

        public RandevuController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
       public IActionResult Randevu()
        {
            return View();
        }
    
        [HttpPost]
        public IActionResult RandevuFormSubmit(RandevuModel model)
        {
            if (ModelState.IsValid)
            {
                string connectionString = "Data Source=gdbeauty.db"; // Veritabanı bağlantı dizesi

                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    using (SqliteCommand command = new SqliteCommand("INSERT INTO randevu (Adı, Telno, Randevudate, Randevusaat) VALUES (@Adı, @Telno, @Randevudate, @Randevusaat)", connection))
                    {
                        command.Parameters.AddWithValue("@Adı", model.Adı);
                        command.Parameters.AddWithValue("@Telno", model.Telno);
                        command.Parameters.AddWithValue("@Randevudate", model.Randevudate);
                        command.Parameters.AddWithValue("@Randevusaat", model.Randevusaat);

                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }

               
            }
            ViewData["OnayMesaji"] = "Randevu onaylandı.";

            // Başarılı bir şekilde ekledikten sonra, teşekkür sayfasına yönlendirilir
            return View("Randevuonayi");
        }
        
        
    }
}
