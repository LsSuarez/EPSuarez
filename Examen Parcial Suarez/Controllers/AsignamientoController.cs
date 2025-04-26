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
    
    public class AsignamientoController : Controller
    {
        private readonly ILogger<AsignamientoController> _logger;
        private readonly ApplicationDbContext _context;

        public AsignamientoController(ILogger<AsignamientoController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
         [HttpPost]
        public IActionResult Create(Asignamiento asignamiento)
        {
            // Validar si el jugador ya está asignado al mismo equipo
            bool exists = _context.DbSetAsignamiento
                .Any(a => a.Equipo.Id == asignamiento.Equipo.Id && a.Jugador.Id == asignamiento.Jugador.Id);

            if (exists)
            {
                ModelState.AddModelError("", "El jugador ya está asignado a este equipo.");
                return View(asignamiento); // Retorna la vista con el mensaje de error
            }

            // Guardar la asignación si pasa la validación
            _context.DbSetAsignamiento.Add(asignamiento);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}