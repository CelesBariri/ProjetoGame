using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoGame.Models;

namespace ProjetoGame.Controllers
{
    public class DescricaoController : Controller
    {
        private readonly Contexto _context;

        public DescricaoController(Contexto context)
        {
            _context = context;
        }

        // GET: Descricao
        public async Task<IActionResult> Index(string pesquisa)
        {
            {
                if (pesquisa == null)
                {
                    return _context.Descricao.Include(x => x.Cadastro)
                        .Include(x => x.Nota) != null ?
                         View(await _context.Descricao.Include(x => x.Cadastro)
                        .Include(x => x.Nota).ToListAsync()) :
                         Problem("Entity set 'Contexto.Descricao' is null.");
                }
                else
                {
                    var Descricao = _context.Descricao
                        .Include(x => x.Cadastro)
                        .Include(x=> x.Nota)
                        .Where(x => x.Cadastro.CadastroNome.Contains(pesquisa))
                        .OrderBy(x => x.DescricaoJogo);

                    return View(Descricao);
                }
            }
        }

        // GET: Descricao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Descricao == null)
            {
                return NotFound();
            }

            var descricao = await _context.Descricao
                .Include(d => d.Cadastro)
                .Include(d => d.Nota)
                .FirstOrDefaultAsync(m => m.DescricaoId == id);
            if (descricao == null)
            {
                return NotFound();
            }

            return View(descricao);
        }

        // GET: Descricao/Create
        public IActionResult Create()
        {
            ViewData["CadastroId"] = new SelectList(_context.Set<Cadastro>(), "CadastroId", "CadastroNome");
            ViewData["NotaId"] = new SelectList(_context.Set<Nota>(), "Id", "NotaValor");
            return View();
        }

        // POST: Descricao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DescricaoId,NotaId,CadastroId,DescricaoJogo")] Descricao descricao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(descricao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CadastroId"] = new SelectList(_context.Set<Cadastro>(), "CadastroId", "CadastroNome", descricao.CadastroId);
            ViewData["NotaId"] = new SelectList(_context.Set<Nota>(), "Id", "NotaValor", descricao.NotaId);
            return View(descricao);
        }

        // GET: Descricao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Descricao == null)
            {
                return NotFound();
            }

            var descricao = await _context.Descricao.FindAsync(id);
            if (descricao == null)
            {
                return NotFound();
            }
            ViewData["CadastroId"] = new SelectList(_context.Set<Cadastro>(), "CadastroId", "CadastroNome", descricao.CadastroId);
            ViewData["NotaId"] = new SelectList(_context.Set<Nota>(), "Id", "NotaValor", descricao.NotaId);
            return View(descricao);
        }

        // POST: Descricao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DescricaoId,NotaId,CadastroId,DescricaoJogo")] Descricao descricao)
        {
            if (id != descricao.DescricaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(descricao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DescricaoExists(descricao.DescricaoId))
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
            ViewData["CadastroId"] = new SelectList(_context.Set<Cadastro>(), "CadastroId", "CadastroNome", descricao.CadastroId);
            ViewData["NotaId"] = new SelectList(_context.Set<Nota>(), "Id", "NotaValor", descricao.NotaId);
            return View(descricao);
        }

        // GET: Descricao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Descricao == null)
            {
                return NotFound();
            }

            var descricao = await _context.Descricao
                .Include(d => d.Cadastro)
                .Include(d => d.Nota)
                .FirstOrDefaultAsync(m => m.DescricaoId == id);
            if (descricao == null)
            {
                return NotFound();
            }

            return View(descricao);
        }

        // POST: Descricao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Descricao == null)
            {
                return Problem("Entity set 'Contexto.Descricao'  is null.");
            }
            var descricao = await _context.Descricao.FindAsync(id);
            if (descricao != null)
            {
                _context.Descricao.Remove(descricao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DescricaoExists(int id)
        {
          return (_context.Descricao?.Any(e => e.DescricaoId == id)).GetValueOrDefault();
        }
    }
}
