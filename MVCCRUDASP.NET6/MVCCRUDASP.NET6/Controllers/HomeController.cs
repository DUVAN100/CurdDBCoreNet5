using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCCRUDASP.NET6.Datos;
using MVCCRUDASP.NET6.Models;
using System.Diagnostics;

namespace MVCCRUDASP.NET6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContexxt _contexto;

        public HomeController(ApplicationDbContexxt contexto)
        {
            _contexto = contexto;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Usuaio.ToListAsync());
        }
        //metodo que retorna la vista
        [HttpGet]
        public  IActionResult Crear()
        {
            return View();
        }
        //metodo que hace la insercion a la base de datos 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _contexto.Usuaio.Add(usuario);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        //metodo de actualizar el usuario

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = _contexto.Usuaio.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _contexto.Update(usuario);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        //metodo de detalle  
        [HttpGet]
        public IActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = _contexto.Usuaio.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }
        //mtodo  para eliminar

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = _contexto.Usuaio.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarUsuario(int? id)
        {
            var usuario = await _contexto.Usuaio.FindAsync(id);
            if (usuario == null)
            {
                return View();
            }

            _contexto.Usuaio.Remove(usuario);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}