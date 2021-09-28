using System;

namespace API.Models
{
  public class Usuario 
  {
    public Usuario() => CriadoEm = DateTime.Now;

    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime CriadoEm { get; set; }

    public override string ToString() =>
      $"Nome: {Nome} | Id: {Id} | CriadoEm: {CriadoEm}";    
  }
}