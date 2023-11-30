using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Avaliacao.Domain.Entities
{
    //[Table("membros")]
    public class Membro : Servidor
    {
        //[Key]
        //public int Id { get; set; }
        public Enum? Cargo { get; set; }
    }
   // public enum CargoEnum { Presidente, Membro, Substituto }

}

