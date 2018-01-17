using SQH.Entities.Models.Alocacao;
using System.Collections.Generic;

namespace SQH.Entities.Models.Projeto
{
    public class ProjetoModel
    {
        public ProjetoModel()
        {
            Alocacoes = new List<AlocacaoProjetoModel>();
        }

        public int Id { get; set; }

        public int IdRecurso { get; set; }

        public IList<AlocacaoProjetoModel> Alocacoes { get; set; }
    }
}