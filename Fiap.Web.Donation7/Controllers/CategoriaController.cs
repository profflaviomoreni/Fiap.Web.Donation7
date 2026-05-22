
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fiap.Web.Donation7.Models;
using Fiap.Web.Donation7.Data;

public class CategoriaController : Controller
{
    private readonly DataContext _context;

    public CategoriaController(DataContext context)
    {
        _context = context;
    }

    // GET: CATEGORIAMODELS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Categorias.ToListAsync());
    }

    // GET: CATEGORIAMODELS/Details/5
    public async Task<IActionResult> Details(int? categoriaid)
    {
        if (categoriaid == null)
        {
            return NotFound();
        }

        var categoriamodel = await _context.Categorias
            .FirstOrDefaultAsync(m => m.CategoriaId == categoriaid);
        if (categoriamodel == null)
        {
            return NotFound();
        }

        return View(categoriamodel);
    }

    // GET: CATEGORIAMODELS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CATEGORIAMODELS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CategoriaId,NomeCategoria,Token")] CategoriaModel categoriamodel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(categoriamodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(categoriamodel);
    }

    // GET: CATEGORIAMODELS/Edit/5
    public async Task<IActionResult> Edit(int? categoriaid)
    {
        if (categoriaid == null)
        {
            return NotFound();
        }

        var categoriamodel = await _context.Categorias.FindAsync(categoriaid);
        if (categoriamodel == null)
        {
            return NotFound();
        }
        return View(categoriamodel);
    }

    // POST: CATEGORIAMODELS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? categoriaid, [Bind("CategoriaId,NomeCategoria,Token")] CategoriaModel categoriamodel)
    {
        if (categoriaid != categoriamodel.CategoriaId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(categoriamodel);
                await _context.SaveChangesAsync();
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

    // GET: CATEGORIAMODELS/Delete/5
    public async Task<IActionResult> Delete(int? categoriaid)
    {
        if (categoriaid == null)
        {
            return NotFound();
        }

        var categoriamodel = await _context.Categorias
            .FirstOrDefaultAsync(m => m.CategoriaId == categoriaid);
        if (categoriamodel == null)
        {
            return NotFound();
        }

        return View(categoriamodel);
    }

    // POST: CATEGORIAMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? categoriaid)
    {
        var categoriamodel = await _context.Categorias.FindAsync(categoriaid);
        if (categoriamodel != null)
        {
            _context.Categorias.Remove(categoriamodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CategoriaModelExists(int? categoriaid)
    {
        return _context.Categorias.Any(e => e.CategoriaId == categoriaid);
    }
}
