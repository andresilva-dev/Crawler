using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Negocio
{
    [Table("TB_PROCESSO")]
    public class Processo
    {
        private string _numeroDoProcesso;
        private string _numeroDeOrigemProcesso;
        public Processo()
        {
            Movimentacoes = new List<Movimentacao>();
        }

        [Key]
        [Column("PROCID")]
        public int Id { get; set; }

        [Column("PROCNUMERO")]
        public string NumeroDoProcesso 
        {
            get => _numeroDoProcesso;
            set 
            {
                var numeros = UtilidadeDeFormatacao.ObtenhaSomenteParteNumerica(value);
                if (numeros.Length != 20)
                {
                    throw new Exception("O número informado para o processo é inválido");
                }
                _numeroDoProcesso = value;
            } 
        }
        [Column("PROCCLASSE")]
        public string Classe { get; set; }
        [Column("PROCAREA")]
        public string Area { get; set; }
        [Column("PROCASSUNTO")]
        public string Assunto { get; set; }
        [Column("PROCORIGEM")]
        public string Origem { get; set; }
        [Column("PROCNUMEROORIGEM")]
        public string NumeroDeOrigem
        {
            get => _numeroDeOrigemProcesso;
            set
            {
                var numeros = UtilidadeDeFormatacao.ObtenhaSomenteParteNumerica(value);
                if (numeros.Length != 20)
                {
                    throw new Exception("O número de origem informado para o processo é inválido");
                }
                _numeroDeOrigemProcesso = value;
            }
        }
        [Column("PROCDISTRIBUICAO")]
        public string Distribuicao { get; set; }
        [Column("PROCRELATOR")]
        public string Relator { get; set; }
        public List<Movimentacao> Movimentacoes { get; set; }

        public override bool Equals(object obj)
        {
            return (obj is Processo processo) && processo.NumeroDoProcesso == NumeroDoProcesso;
        }

        public override string ToString()
        {
            return $"Processo número: {NumeroDoProcesso}";
        }

        public override int GetHashCode()
        {
            return NumeroDoProcesso.GetHashCode();
        }
    }
}
