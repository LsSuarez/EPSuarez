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
    public class JugadorController : Controller
    {
        private readonly ILogger<JugadorController> _logger;
        private readonly ApplicationDbContext _context;

        public JugadorController(ILogger<JugadorController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        
        }
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(Jugadores jugador)
        {
            if (ModelState.IsValid)
            {
                _context.DbSetJugadores.Add(jugador); // Guarda el jugador en la base de datos
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Equipos = _context.DbSetEquipos.ToList(); // Recarga la lista de equipos si hay errores
            return View("Crear", jugador);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}