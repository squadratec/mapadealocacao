namespace SQH.Entities.Models.Projeto
{
    public class ProjetoModel
    {
        public int IdProjeto { get; set; }

        public int? IdRecurso { get; set; }

        public string Nome { get; set; }

        public string Lider { get; set; }
    }
}