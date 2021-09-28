using System;

namespace API.Models
{
  public class Filme 
  {
    public Filme() => CriadoEm = DateTime.Now;

    public int Id { get; set; }
    public string Titulo { get; set; }
    public int Duracao { get; set; }
    public string Genero { get; set; }
    public string Diretor { get; set; }
    public string Status { get; set; }
    public int Ano { get; set; } 
    public DateTime CriadoEm { get; set; }
    
    public override string ToString() =>
      $"Titulo: {Titulo} | Genero: {Genero} | Status {Status} | Duração {Duracao} | Diretor {Diretor} | Ano de lançamento {Ano}";    
  }
}