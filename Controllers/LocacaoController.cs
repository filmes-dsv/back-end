using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers 
{
  [ApiController]
  [Route("api/locacao")]

  public class LocacaoController : ControllerBase
  { 
    private readonly DataContext _context;
    public  LocacaoController(DataContext context)
    {
      _context = context;
    }
    // POST: api/locacao
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateAsync([FromBody] Locacao locacao)
    {
     
      Filme filme = await _context.Filmes.FindAsync(locacao.FilmeId); 
      if (filme == null) {
        return Ok("Filme não encontrado");
      }

      Usuario user = await _context.Usuarios.FindAsync(locacao.UsuarioId); 
      if (user == null) {
        return Ok("Usuário não encontrado");
      }

      Locacao locacaoReturn = await _context.Locacoes.FirstOrDefaultAsync(loc => loc.FilmeId == locacao.FilmeId && loc.UsuarioId == locacao.UsuarioId);
      if (locacaoReturn != null) {
        return Ok("Locação ja realizada pelo sistema");
      }

      await _context.Locacoes.AddAsync(locacao);
      await _context.SaveChangesAsync(); 
      return Created("", locacao);
    }

    [HttpGet]
    [Route("list")]
    public async Task<IActionResult> ListAsync()
    {
      return Ok(await _context.Locacoes.ToListAsync());
    }

    //GET: getById
    [HttpGet]
    [Route("getById/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id) 
    {
      Locacao locacao = await _context.Locacoes.FindAsync(id);
      
      if (locacao != null) return Ok(locacao);
      return NotFound();
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
      Locacao locacao = await _context.Locacoes.FirstOrDefaultAsync(locacao => locacao.Id == id);
      _context.Locacoes.Remove(locacao);
      await _context.SaveChangesAsync();
      return Ok(locacao);
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateAsync([FromBody] Locacao locacao)
    {
      Filme filme = await _context.Filmes.FindAsync(locacao.FilmeId); 
      if (filme == null) {
        return Ok("Filme não encontrado");
      }

      Usuario user = await _context.Usuarios.FindAsync(locacao.UsuarioId); 
      if (user == null) {
        return Ok("Usuário não encontrado");
      }

      Locacao movie = await _context.Locacoes.FirstOrDefaultAsync(movie => movie.Id == locacao.Id);
      movie.FilmeId = locacao.FilmeId;
      movie.UsuarioId = locacao.UsuarioId;
      _context.Locacoes.Update(movie);
      await _context.SaveChangesAsync();
      return Ok(movie);
    }
  }
}