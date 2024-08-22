using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using library_1100.Models;
using Microsoft.AspNetCore.Mvc;

namespace library_1100.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Auth/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Auth/Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Verificamos si el usuario es válido
            var user = VerifyUser(username, password);

            if (user != null)
            {
                // Generar el token (aquí es un token simple basado en una combinación de datos)
                var token = GenerateToken(user);

                // Devolver el token al cliente
                return Json(new { success = true, token });
            }
            else
            {
                // En caso de que el usuario no sea válido
                return Json(new { success = false, message = "Invalid username or password." });
            }
        }

        private User VerifyUser(string username, string password)
        {
            // Busca al usuario en la base de datos
            var user = _context.Users.FirstOrDefault(u => u.Name == username);

            if (user != null)
            {
                // Verificamos la contraseña (asumimos que está encriptada con SHA256)
                var hashedPassword = HashPassword(password);

                if (user.Password == hashedPassword)
                {
                    return user;
                }
            }

            return null;
        }

        private string GenerateToken(User user)
        {
            // Generar un token simple (puedes reemplazar esto con JWT u otra forma de token)
            var token = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{user.Id}:{DateTime.UtcNow}"));
            return token;
        }

        private string HashPassword(string password)
        {
            // Método para encriptar la contraseña usando SHA256
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        // GET: /Auth/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetDocumentTypes()
        {
            var documentTypes = _context.DocumentTypes.Select(dt => new { dt.Id, dt.Name }).ToList();
            return Json(documentTypes);
        }

        //[HttpPost]
        // public IActionResult Register(UserRegisterViewModel model)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         var user = new User
        //         {
        //             Name = model.Name,
        //             Password = model.Password, // Deberías encriptar la contraseña
        //             Address = model.Address,
        //             DocumentTypeId = model.DocumentType_Id,
        //             DocumentNumber = model.DocumentNumber,
        //             PhoneNumber = model.PhoneNumber,
        //             RoleId = 3 // Role "user" por defecto
        //         };

        //         _context.Users.Add(user);
        //         _context.SaveChanges();
        //         return RedirectToAction("Login");
        //     }

        //     return View(model);
        // }
    }
}