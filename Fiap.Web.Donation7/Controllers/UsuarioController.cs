
using Fiap.Web.Donation7.Controllers;
using Fiap.Web.Donation7.Controllers.Filters;
using Fiap.Web.Donation7.Data;
using Fiap.Web.Donation7.Models;
using Fiap.Web.Donation7.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Auth]
public class UsuarioController : BaseController
{
    private readonly UsuarioRepository _usuarioRepository;

    public UsuarioController(DataContext dataContext)
    {
        _usuarioRepository = new UsuarioRepository(dataContext);
    }

    public IActionResult Index()
    {
        return View(_usuarioRepository.FindAll());
    }

    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var usuariomodel = _usuarioRepository.FindById(id.Value);
        if (usuariomodel == null)
        {
            return NotFound();
        }

        return View(usuariomodel);
    }

 
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("UsuarioId,Nome,Email,Senha,Regra")] UsuarioModel usuariomodel)
    {
        if (ModelState.IsValid)
        {
            _usuarioRepository.Insert(usuariomodel);
            return RedirectToAction(nameof(Index));
        }
        return View(usuariomodel);
    }

    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var usuariomodel = _usuarioRepository.FindById(id.Value);
        if (usuariomodel == null)
        {
            return NotFound();
        }
        return View(usuariomodel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int? id, [Bind("UsuarioId,Nome,Email,Senha,Regra")] UsuarioModel usuariomodel)
    {
        if (id != usuariomodel.UsuarioId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _usuarioRepository.Update(usuariomodel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioModelExists(usuariomodel.UsuarioId))
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
        return View(usuariomodel);
    }

    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var usuariomodel = _usuarioRepository.FindById(id.Value);
        if (usuariomodel == null)
        {
            return NotFound();
        }

        return View(usuariomodel);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var usuariomodel = _usuarioRepository.FindById(id.Value);
        if (usuariomodel != null)
        {
            _usuarioRepository.Delete(id.Value);
        }

        return RedirectToAction(nameof(Index));
    }

    private bool UsuarioModelExists(int? id)
    {
        if (id == null) return false;
        return _usuarioRepository.FindById(id.Value) != null;
    }
}
