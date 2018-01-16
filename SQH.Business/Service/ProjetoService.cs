using SQH.Business.Contract;
using System.Collections.Generic;
using SQH.DataAccess.Contract;
using System.Linq;
using SQH.Entities.Response.Projeto;
using SQH.Entities.Database;

namespace SQH.Business.Service
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IRecursoRepository _recursoRepository;

        public ProjetoService(IProjetoRepository projetoRepository, IRecursoRepository recursoRepository)
        {
            _projetoRepository = projetoRepository;
            _recursoRepository = recursoRepository;
        }

        public IEnumerable<ProjetoResponse> ObtemTodos()
        {
            var projetos = _projetoRepository.FindAll().OrderBy(x => x.DataCadastro);

            var retorno = new List<ProjetoResponse>();

            projetos.ToList().ForEach(x => retorno.Add(new ProjetoResponse()
            {
                IdProjeto = x.IdProjeto,
                IdRecurso = x.IdRecurso,
                Nome = x.Nome,
                Lider = x.IdRecurso.HasValue ? ObtemLiderProjeto(x.IdRecurso.Value).Nome : ""
            }));

            return retorno;
        }

        private Recurso ObtemLiderProjeto(int id)
        {
            var recurso = _recursoRepository.FindByID(id);

            return recurso;
        }
    }
}