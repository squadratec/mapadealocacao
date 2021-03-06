﻿using SQH.Entities.Database;
using SQH.Entities.Response.TipoAlocacao;
using System.Collections.Generic;

namespace SQH.Business.Contract
{
    public interface ITipoAlocacaoService
    {
        /// <summary>
        /// Incluir novo tipo de alocação
        /// </summary>
        /// <param name="model">Type TipoAlocacaoModel</param>
        /// <returns></returns>
        bool Incluir(Entities.Models.TipoAlocacao.TipoAlocacaoModel model);
        /// <summary>
        /// Obtem o tipo de alocação por ID
        /// </summary>
        /// <param name="id">ID referente ao tipo de alocação</param>
        /// <returns></returns>
        tipo_alocacao ObterPorId(int id);
        IEnumerable<TipoAlocacaoResponse> ObtemTodos();
        /// <summary>
        /// Alterar o tipo de alocação
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Editar(Entities.Models.TipoAlocacao.TipoAlocacaoModel model);
        bool Deletar(int id);
    }
}
