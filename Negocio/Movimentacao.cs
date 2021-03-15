using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Negocio
{
    [Table("TB_MOVIMENTACAO")]
    public class Movimentacao
    {
        [Key]
        [Column("MOVID")]
        public int Id { get; set; }
        [Column("MOVDATA")]
        public string Data { get; set; }
        [Column("MOVCONTEUDO")]
        public string Conteudo { get; set; }
        [ForeignKey("PROCID")]
        [Column("MOVPROCESSOID")]
        public int ProcessoId { get; set; }
    }
}
