namespace SQH.Shared.Enums
{
    public static class Parametros
    {
        public const string ArraySolicitacao = "{0}|{1}|{2}|{3}|{4}";

        public const string Agente =
            @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.99 Safari/537.36";

        public const string TipoDeContetudoPOST =
            @"application/x-www-form-urlencoded";

        public const string TipoDeConteudoGET =
            @"text/html; charset=iso-8859-1; encoding=utf-8";

        public const string CaminhoDoServidorSqHoras =
            @"//www.squadra.com.br/sqhoras";

        public const string ExtremidadeDeAutenticacao =
            @"/default.asp";

        public const string ExtremidadeDeEncerramento =
            @"/logout.asp";

        public const string ExtremidadeDeSolicitacaoDeAlteracaoDeHoras =
            @"/solicitarAlteracao.asp";

        public const string ExtremidadeDeCarregamentoSubProjetosEPapeis =
            @"/solicitarAlteracaoAJAX.asp";

        public const string ExtremidadeDeCarregamentoDeDisciplinaTarefa =
            @"/DisciplinaTarefaAJAX.asp";

        public const string ExtremidadeDeGravacaoDeSolicitacao =
            @"/gravarsolicitacao.asp";

        public const string FiltroSeletorDeProjetos =
            @"//select[@id='projeto']/option";

        public const string FiltroSeletorDeSubProjetos =
            @"//select[@id='subprojeto']/option";

        public const string FiltroSeletorDePapeis =
            @"//select[@id='vaga']/option";

        public const string FiltroSeletorDeMotivos =
            @"//select[@id='motivo']/option";

        public const string FiltroSeletorDeDisciplinas =
            @"//select[@id='disciplina']/option";

        public const string FiltroSeletorDeTarefas =
            @"//select[@id='tarefa']/option";

        public const string FiltroSeletorIdDoColaborador =
            @"//input[@name='colaborador']";

        public const string FiltroErroRespostaApontamento =
            @"//input[@name='ERRO']";

        public const string FiltroMensagemRespostaApontamento =
            @"//input[@name='MSG']";
    }
}
