namespace SQH.Entities.SQHoras
{
    public class LoginRequisitor
    {
        public LoginRequisitor()
        {
            this.acao = "Entrar";
            this.origem = "";
            this.hidp = "";
            this.hidusuario = "";
            this.URL_DESTINO = "";
        }

        public LoginRequisitor(string user, string pass)
        {
            this.acao = "Entrar";
            this.origem = "";
            this.hidp = "";
            this.hidusuario = "";
            this.URL_DESTINO = "";
            this.usuario = user;
            this.senha = pass;
        }

        public string origem { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public string acao { get; set; }
        public string hidusuario { get; set; }
        public string hidp { get; set; }
        public string URL_DESTINO { get; set; }
    }
}
