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
  [Route("api/usuario")]

  public class UsuarioController : ControllerBase
  { 
    private readonly DataContext _context;
    public  UsuarioController(DataContext context)
    {
      _context = context;
    }
    // POST: api/usuario
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateAsync([FromBody] Usuario usuario)
    {
      await _context.Usuarios.AddAsync(usuario);
      await _context.SaveChangesAsync(); 
      return Created("", usuario);
    }

    [HttpGet]
    [Route("list")]
    public async Task<IActionResult> ListAsync()
    {
      return Ok(await _context.Usuarios.ToListAsync());
    }

    //GET: getById
    [HttpGet]
    [Route("getById/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id) 
    {
      Usuario usuario = await _context.Usuarios.FindAsync(id); 
      if (usuario != null) return Ok(usuario);
      return NotFound();
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
      Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id == id);
      _context.Usuarios.Remove(usuario);
      await _context.SaveChangesAsync();
      return Ok(usuario);
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateAsync([FromBody] Usuario usuario)
    {
      Usuario user = await _context.Usuarios.FirstOrDefaultAsync(user => user.Id == usuario.Id);
      user.Nome = usuario.Nome;
      _context.Usuarios.Update(user);
      await _context.SaveChangesAsync();
      return Ok(user);
    }
  }
}