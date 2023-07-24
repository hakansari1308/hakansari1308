using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.Sqlite;
using GoldenDaisyWebUI.Models;
using GoldenDaisyWebUI.Helpers;


namespace GoldenDaisyWebUI.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly string _connectionString = "Data Source=gdbeauty.db";

        private string HashPassword(string password)
        {
            return PasswordHasher.HashPassword(password, out string salt);
        }

       
        
       
        public IActionResult login()
        {
            return View();
        }
        public IActionResult Profil()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(KullaniciModel model)
        {
            if (ModelState.IsValid)
            {
                string username = model.username;
                string sifre = model.sifre;

                // Kullanıcının kimlik bilgilerini doğrula
                bool isValidUser = CheckCredentials(username, sifre);

                if (isValidUser)
                {
                    // Kullanıcı giriş işlemi başarılı
                    // Giriş yapılacak sayfaya yönlendirme yapabilirsiniz
                    return RedirectToAction("Profil");
                }
                else
                {
                    // Kullanıcı giriş işlemi başarısız, hatalı giriş bilgileri
                    // Kullanıcıyı tekrar login sayfasına yönlendirebilirsiniz
                    return View("Register");
                }
            }
            else
            {
                // ModelState.IsValid false ise, hatalı girişler var demektir.
                // Kullanıcıyı aynı sayfada hata mesajlarıyla birlikte tekrar yönlendirebilirsiniz.
                return View();
            }
        }

        // Diğer metodlar...

        private bool CheckCredentials(string username, string sifre)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                using (SqliteCommand command = new SqliteCommand("SELECT sifre, salt FROM musteri WHERE username = @username", connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hashedPassword = reader.GetString(0);
                            string salt = reader.GetString(1);

                            // Kullanıcının girdiği şifreyi veritabanındaki salt ile birleştirerek hashleyelim
                            string hashedInputPassword = PasswordHasher.HashPassword(sifre,out salt);

                            // Hashlenmiş şifrelerin eşleşip eşleşmediğini kontrol edelim
                            if (hashedPassword == hashedInputPassword)
                            {
                                return true;
                            }
                        }
                    }
                }

                connection.Close();
            }

            return false;
        }


        public IActionResult Register()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult Register(KullaniciModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.sifre != model.sifre2)
                {
                    ModelState.AddModelError("sifre2", "Şifreler eşleşmiyor.");
                    return View();
                }
                // Şifreyi hashleyelim
                string hashedPassword = HashPassword(model.sifre);

                using (SqliteConnection connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    using (SqliteCommand command = new SqliteCommand("INSERT INTO musteri (username, Adı, Soyadı, Telno, sifre) VALUES (@username, @Adı, @Soyadı, @Telno, @sifre)", connection))
                    {
                        command.Parameters.AddWithValue("@username", model.username);
                        command.Parameters.AddWithValue("@Adı", model.Adı);
                        command.Parameters.AddWithValue("@Soyadı", model.Soyadı);
                        command.Parameters.AddWithValue("@Telno", model.Telno);
                        command.Parameters.AddWithValue("@sifre", hashedPassword);

                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }

                return RedirectToAction("login"); // Kayıt başarılıysa login sayfasına yönlendir
            }

            // ModelState.IsValid false ise, hatalı girişler var demektir.
            // Kullanıcıyı aynı sayfada hata mesajlarıyla birlikte tekrar yönlendirebilirsiniz.
            return View();
        }





    }
}
