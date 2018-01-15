using SQH.Shared.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SQH.Entities.Database
{
    public class tipo_alocacao
    {
        public tipo_alocacao(Entities.Models.TipoAlocacao.TipoAlocacaoModel TipoAlocacao)
        {
            DataCadastro = DateTime.Now;
            Nome = TipoAlocacao.Nome;
            Cor = TipoAlocacao.Cor;
            Sigla = TipoAlocacao.Sigla;
            IdTipoAlocacao = TipoAlocacao.IdTipoAlocacao;
        }

        public tipo_alocacao()
        { }

        [PrimaryKey]
        public int IdTipoAlocacao { get; set; }
        public DateTime DataCadastro { get; set; }
        public String Nome { get; set; }
        public String Cor { get; set; }
        public String Sigla { get; set; }
    }
}
