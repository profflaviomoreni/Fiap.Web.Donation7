
using Fiap.Web.Donation7.Controllers;
using Fiap.Web.Donation7.Controllers.Filters;
using Fiap.Web.Donation7.Data;
using Fiap.Web.Donation7.Models;
using Fiap.Web.Donation7.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Auth]
public class CategoriaController : BaseController
{

    private readonly CategoriaRepository _categoriaRepository;

    public CategoriaController(DataContext context)
    {
        _categoriaRepository = new CategoriaRepository(context);
    }


    public async Task<IActionResult> Index()    
    {
        return View(_categoriaRepository.FindAll());
    }


    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var categoriamodel = _categoriaRepository.FindById(id.Value);
        if (categoriamodel == null)
        {
            return NotFound();
        }

        return View(categoriamodel);
    }

    
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CategoriaId,NomeCategoria,Token")] CategoriaModel categoriamodel)
    {
        if (ModelState.IsValid)
        {
            _categoriaRepository.Insert(categoriamodel);
            return RedirectToAction(nameof(Index));
        }
        return View(categoriamodel);
    }

    
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var categoriamodel = _categoriaRepository.FindById(id.Value);
        if (categoriamodel == null)
        {
            return NotFound();
        }
        return View(categoriamodel);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("CategoriaId,NomeCategoria,Token")] CategoriaModel categoriamodel)
    {
        if (id != categoriamodel.CategoriaId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _categoriaRepository.Update(categoriamodel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaModelExists(categoriamodel.CategoriaId))
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
        return View(categoriamodel);
    }

    
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var categoriamodel = _categoriaRepository.FindById(id.Value);
        if (categoriamodel == null)
        {
            return NotFound();
        }

        return View(categoriamodel);
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        _categoriaRepository.Delete(id.Value);
        return RedirectToAction(nameof(Index));
    }

    private bool CategoriaModelExists(int? id)
    {
        return _categoriaRepository.FindById(id.Value) != null;
    }
}
