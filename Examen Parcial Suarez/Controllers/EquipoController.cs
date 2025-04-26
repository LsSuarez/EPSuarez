using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Parcial_.Data;
using Parcial_.Models;

namespace Parcial_.Controllers
{
    [Route("[controller]")]
    public class EquipoController : Controller
    {
        private readonly ILogger<EquipoController> _logger;
        private readonly ApplicationDbContext _context;

        public EquipoController(ILogger<EquipoController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
         [HttpPost]
        public IActionResult Guardar(Equipos equipo)
        {
            if (ModelState.IsValid)
            {
                _context.DbSetEquipos.Add(equipo); // Agrega el equipo a la base de datos
                _context.SaveChanges();
                return RedirectToAction("Index"); // Redirige a una vista de índice (puedes personalizar esto)
            }

            return View("Crear", equipo); // Si hay errores, vuelve al formulario
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}