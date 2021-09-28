using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
  public class Locacao 
  {
    [ForeignKey("Filme")]
    public int FilmeId { get; set; }
    public Filme Filme { get; set; }
    [ForeignKey("Usuario")]
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    public Locacao() => CriadoEm = DateTime.Now;

    public int Id { get; set; }
    public DateTime CriadoEm { get; set; }

  }
}