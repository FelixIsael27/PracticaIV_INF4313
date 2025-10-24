using Actividad4LengProg3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad4LengProg3.Controllers
{
    public class RecintosController : Controller
    {
        private static List<RecintoViewModel> recintos = new List<RecintoViewModel>();

        public IActionResult Lista()
        {
            return View(recintos);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(RecintoViewModel recinto)
        {
            if (ModelState.IsValid)
            {
                recintos.Add(recinto);
                return RedirectToAction("Lista");
            }
            return View(recinto);
        }

        public IActionResult Editar(string codigo)
        {
            var recinto = recintos.FirstOrDefault(r => r.Codigo == codigo);
            if (recinto == null) return NotFound();
            return View(recinto);
        }

        [HttpPost]
        public IActionResult Editar(RecintoViewModel recinto)
        {
            if (!ModelState.IsValid) return View(recinto);

            var existente = recintos.FirstOrDefault(r => r.Codigo == recinto.Codigo);
            if (existente == null) return NotFound();

            existente.Nombre = recinto.Nombre;
            existente.Direccion = recinto.Direccion;

            return RedirectToAction("Lista");
        }

        public IActionResult Eliminar(string codigo)
        {
            var recinto = recintos.FirstOrDefault(r => r.Codigo == codigo);
            if (recinto != null)
            {
                recintos.Remove(recinto);
            }
            return RedirectToAction("Lista");
        }
    }
}
