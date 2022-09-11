using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabajadoresPrueba.Data.Context;
using TrabajadoresPrueba.Data.Models;
using TrabajadoresPrueba.Models;

namespace TrabajadoresPrueba.Controllers
{
    public class TrabajadoresController : Controller
    {
        private readonly PruebaContext _context;

        private List<SelectListItem> _depItems;
        private List<SelectListItem> _provitem;
        private List<SelectListItem> _disitem; 

        public TrabajadoresController(PruebaContext context)
        {
            _context = context;
        }

        // GET: Trabajadores
        public async Task<IActionResult> Index()
        {
            var pruebaContext = _context.Trabajadores.Include(t => t.IdDepartamentoNavigation).Include(t => t.IdDistritoNavigation).Include(t => t.IdProvinciaNavigation);
            //ViewBag.trabajadores = _context.Trabajadores.FromSqlRaw("sp_listarTrabajadores");
            //return View();
            return View(pruebaContext.ToList());
        }

        // GET: Trabajadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trabajadores == null)
            {
                return NotFound();
            }

            var trabajadore = await _context.Trabajadores
                .Include(t => t.IdDepartamentoNavigation)
                .Include(t => t.IdDistritoNavigation)
                .Include(t => t.IdProvinciaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (trabajadore == null)
            {
                return NotFound();
            }

            return View(trabajadore);
        }

        // GET: Trabajadores/Create
        public IActionResult Create()
        {
            List<SelectListItem> documentList = new List<SelectListItem>() {
            new SelectListItem {
                Text = "-Seleccione tipo-", Value = String.Empty
            },
            new SelectListItem {
                Text = "DNI", Value = "DNI"
            },
            new SelectListItem {
                Text = "CARNET EXTRANJERIA", Value = "CXE"
            },
            new SelectListItem {
                Text = "RUC", Value = "RUC"
            },
            new SelectListItem {
                Text = "PASAPORTE", Value = "PAS"
            } };    

            ViewBag.documentos= documentList;

            //ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "Id", "NombreDepartamento");
            //ViewData["IdDistrito"] = new SelectList(_context.Distritos, "Id", "NombreDistrito");
            //ViewData["IdProvincia"] = new SelectList(_context.Provincia, "Id", "NombreProvincia");

            var departamentos = _context.Departamentos.ToList();
            _depItems = new List<SelectListItem>();
            _depItems.Add(new SelectListItem
            {
                Text = "-Seleccione Departamento-",
                Value = "0"
            });
            foreach (var item in departamentos)
            {
                _depItems.Add(new SelectListItem
                {
                    Text = item.NombreDepartamento,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.depItems = _depItems;

            _provitem = new List<SelectListItem>();
            _provitem.Add(new SelectListItem
            {
                Text = "-Primero seleccione Departamento-",
                Value = "0"
            });

            ViewBag.provItems = _provitem;

            _disitem = new List<SelectListItem>();
            _disitem.Add(new SelectListItem
            {
                Text = "-Primero seleccione Provincia-",
                Value = "0"
            });

            ViewBag.disitem = _disitem;



            return View();
        }

        //Json's para llamarlos de Ajax
        public JsonResult GetProvinciaList(int IdDepartamento)
        {            
                var provincias = _context.Provincia.Where(x => x.IdDepartamento == IdDepartamento).ToList();
                return Json(provincias);
            
        }

        public JsonResult GetDistritoList(int IdProvincia)
        {
            var distritos = _context.Distritos.Where(x => x.IdProvincia == IdProvincia).ToList();
            return Json(distritos);

        }

        // POST: Trabajadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoDocumento,NumeroDocumento,Nombres,Sexo,IdDepartamento,IdProvincia,IdDistrito")] Trabajadore trabajadore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trabajadore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "Id", "NombreDepartamento", trabajadore.IdDepartamento);
            ViewData["IdDistrito"] = new SelectList(_context.Distritos, "Id", "NombreDistrito", trabajadore.IdDistrito);
            ViewData["IdProvincia"] = new SelectList(_context.Provincia, "Id", "NombreProvincia", trabajadore.IdProvincia);
            return View(trabajadore);
        }

        // GET: Trabajadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trabajadores == null)
            {
                return NotFound();
            }

            var trabajadore = await _context.Trabajadores.FindAsync(id);
            if (trabajadore == null)
            {
                return NotFound();
            }
            List<SelectListItem> documentList = new List<SelectListItem>() {
            new SelectListItem {
                Text = "DNI", Value = "DNI"
            },
            new SelectListItem {
                Text = "CARNET EXTRANJERIA", Value = "CXE"
            },
            new SelectListItem {
                Text = "RUC", Value = "RUC"
            },
            new SelectListItem {
                Text = "PASAPORTE", Value = "PAS"
            } };

            ViewBag.documentos = documentList;

            //ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "Id", "NombreDepartamento", trabajadore.IdDepartamento);
            //ViewData["IdDistrito"] = new SelectList(_context.Distritos, "Id", "NombreDistrito", trabajadore.IdDistrito);
            //ViewData["IdProvincia"] = new SelectList(_context.Provincia, "Id", "NombreProvincia", trabajadore.IdProvincia);

            var departamentos = _context.Departamentos.ToList();
            _depItems = new List<SelectListItem>();
            _depItems.Add(new SelectListItem
            {
                Text = "-Seleccione Departamento-",
                Value = "0"
            });
            foreach (var item in departamentos)
            {
                _depItems.Add(new SelectListItem
                {
                    Text = item.NombreDepartamento,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.depItems = _depItems;


            var provincias = _context.Provincia.Where(x => x.IdDepartamento == trabajadore.IdDepartamento).ToList();
            _provitem = new List<SelectListItem>();
            _provitem.Add(new SelectListItem
            {
                Text = "-Seleccione Provincia-",
                Value = "0"
            });
            foreach (var item in provincias)
            {
                _provitem.Add(new SelectListItem
                {
                    Text = item.NombreProvincia,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.provitem = _provitem;

            var distritos = _context.Distritos.Where(x => x.IdProvincia == trabajadore.IdProvincia).ToList();
            _disitem = new List<SelectListItem>();
            _disitem.Add(new SelectListItem
            {
                Text = "-Seleccione Distrito-",
                Value = "0"
            });
            foreach (var item in distritos)
            {
                _disitem.Add(new SelectListItem
                {
                    Text = item.NombreDistrito,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.disitem = _disitem;


            return View(trabajadore);
        }

        // POST: Trabajadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoDocumento,NumeroDocumento,Nombres,Sexo,IdDepartamento,IdProvincia,IdDistrito")] Trabajadore trabajadore)
        {
            if (id != trabajadore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trabajadore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrabajadoreExists(trabajadore.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "Id", "Id", trabajadore.IdDepartamento);
            ViewData["IdDistrito"] = new SelectList(_context.Distritos, "Id", "Id", trabajadore.IdDistrito);
            ViewData["IdProvincia"] = new SelectList(_context.Provincia, "Id", "Id", trabajadore.IdProvincia);
            return View(trabajadore);
        }

        //GET: Trabajadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trabajadores == null)
            {
                return NotFound();
            }

            var trabajadore = await _context.Trabajadores
                .Include(t => t.IdDepartamentoNavigation)
                .Include(t => t.IdDistritoNavigation)
                .Include(t => t.IdProvinciaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trabajadore == null)
            {
                return NotFound();
            }

            return View(trabajadore);
        }

        // POST: Trabajadores/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trabajadores == null)
            {
                return Problem("Entity set 'PruebaContext.Trabajadores'  is null.");
            }
            var trabajadore = await _context.Trabajadores.FindAsync(id);
            if (trabajadore != null)
            {
                _context.Trabajadores.Remove(trabajadore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        private bool TrabajadoreExists(int id)
        {
          return (_context.Trabajadores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
