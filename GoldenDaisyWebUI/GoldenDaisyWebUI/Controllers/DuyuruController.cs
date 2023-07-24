using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using GoldenDaisyWebUI.Models;

namespace GoldenDaisyWebUI.Controllers
{
    public class DuyuruController : Controller
    {
        public IActionResult Duyuru()
        {
            // Veritabanı bağlantı dizesi
            string connectionString = "Data Source=gdbeauty.db";

            // Duyuruları tutacak liste
            List<DuyuruModel> duyurular = new List<DuyuruModel>();

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                using (SqliteCommand command = new SqliteCommand("SELECT duyuru FROM duyuru", connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Her satırı okuyarak duyuru modeline ekleyin
                            DuyuruModel duyuru = new DuyuruModel
                            {
                                duyuru = reader.GetString(0)
                            };
                            duyurular.Add(duyuru);
                        }
                    }
                }

                connection.Close();
            }

            return View(duyurular);
        }

        // Diğer action methodları...
    }
}
