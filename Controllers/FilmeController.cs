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
  [Route("api/filme")]

  public class FilmeController : ControllerBase
  { 
    private readonly DataContext _context;
    public  FilmeController(DataContext context)
    {
      _context = context;
    }
    // POST: api/filme
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateAsync([FromBody] Filme filme)
    {
      await _context.Filmes.AddAsync(filme);
      await _context.SaveChangesAsync(); 
      return Created("", filme);
    }

    [HttpGet]
    [Route("list")]
    public async Task<IActionResult> ListAsync()
    {
      return Ok(await _context.Filmes.ToListAsync());
    }

    //GET: getById
    [HttpGet]
    [Route("getById/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id) 
    {
      Filme filme = await _context.Filmes.FindAsync(id); 
      if (filme != null) return Ok(filme);
      return NotFound();
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
      Filme filme = await _context.Filmes.FirstOrDefaultAsync(filme => filme.Id == id);
      _context.Filmes.Remove(filme);
      await _context.SaveChangesAsync();
      return Ok(filme);
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateAsync([FromBody] Filme filme)
    {
      Filme movie = await _context.Filmes.FirstOrDefaultAsync(movie => movie.Id == filme.Id);
      movie.Titulo = filme.Titulo;
      movie.Diretor = filme.Diretor;
      movie.Ano = filme.Ano;
      movie.Status = filme.Status;
      movie.Genero = filme.Genero;
      movie.Duracao = filme.Duracao;
      _context.Filmes.Update(movie);
      await _context.SaveChangesAsync();
      return Ok(movie);
    }
  }
}