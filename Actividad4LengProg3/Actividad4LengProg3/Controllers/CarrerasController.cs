using Actividad4LengProg3.Models;
using Microsoft.AspNetCore.Mvc;
namespace Actividad4LengProg3.Controllers
{
    public class CarrerasController : Controller
    {
        private static List<CarreraViewModel> carreras = new List<CarreraViewModel>();

        public IActionResult Lista()
        {
            return View(carreras);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(CarreraViewModel carrera)
        {
            if (ModelState.IsValid)
            {
                carreras.Add(carrera);
                return RedirectToAction("Lista");
            }
            return View(carrera);
        }

        public IActionResult Editar(string codigo)
        {
            var carrera = carreras.FirstOrDefault(c => c.Codigo == codigo);
            if (carrera == null) return NotFound();
            return View(carrera);
        }

        [HttpPost]
        public IActionResult Editar(CarreraViewModel carrera)
        {
            if (!ModelState.IsValid) return View(carrera);

            var existente = carreras.FirstOrDefault(c => c.Codigo == carrera.Codigo);
            if (existente == null) return NotFound();

            existente.Nombre = carrera.Nombre;
            existente.CantidadCreditos = carrera.CantidadCreditos;
            existente.CantidadMaterias = carrera.CantidadMaterias;

            return RedirectToAction("Lista");
        }

        public IActionResult Eliminar(string codigo)
        {
            var carrera = carreras.FirstOrDefault(c => c.Codigo == codigo);
            if (carrera != null)
            {
                carreras.Remove(carrera);
            }
            return RedirectToAction("Lista");
        }
    }
}
