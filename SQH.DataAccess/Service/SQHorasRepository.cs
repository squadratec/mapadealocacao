using SQH.DataAccess.Contract;
using SQH.Entities.SQHoras;
using SQH.Shared.Enums;
using SQH.Shared.Extensions;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace SQH.DataAccess.Service
{
    public class SQHorasRepository : ISQHorasRepository
    {
        public bool ValidaLoginUsuario(LoginRequisitor requisitor)
        {
            HttpWebRequest _requisitor = null;
            String result = Post(Parametros.ExtremidadeDeAutenticacao, requisitor.ToSerializeBytes(), out _requisitor);

            return (result.Contains("timesheetColaborador"));
        }


        #region Métodos Privados
        private string Post(string uri, byte[] formdata, CookieContainer container = null)
        {
            String result = String.Empty;
            var _requisitor = CreateWebRequest(uri, "POST", formdata, container);

            using (var resposta = (HttpWebResponse)_requisitor.GetResponse())
            {
                using (var leitor = new StreamReader(resposta.GetResponseStream(), Encoding.GetEncoding("iso-8859-1")))
                    result = leitor.ReadToEnd();
            }
            return result;
        }

        private string Post(string uri, byte[] formdata, out HttpWebRequest request)
        {
            String result = String.Empty;
            request = CreateWebRequest(uri, "POST", formdata, null);

            using (var resposta = (HttpWebResponse)request.GetResponse())
            {
                using (var leitor = new StreamReader(resposta.GetResponseStream(), Encoding.GetEncoding("iso-8859-1")))
                    result = leitor.ReadToEnd();
            }
            return result;
        }

        private HttpWebRequest CreateWebRequest(string extremidade, string metodo = "GET", byte[] dadosDePostagem = null, CookieContainer container = null)
        {
            var url = string.Concat("http:", Parametros.CaminhoDoServidorSqHoras, extremidade);

            HttpWebRequest _requisitor = WebRequest.Create(url) as HttpWebRequest;
            _requisitor.UserAgent = Parametros.Agente;
            _requisitor.CookieContainer = container == null ? new CookieContainer() : container;
            _requisitor.Method = metodo.ToUpper();
            _requisitor.ContentType = _requisitor.Method.Equals("GET") ? Parametros.TipoDeConteudoGET : Parametros.TipoDeContetudoPOST;

            if (_requisitor.Method.Equals("POST"))
            {
                _requisitor.ContentLength = dadosDePostagem.Length;

                using (var escritor = _requisitor.GetRequestStream())
                    escritor.Write(dadosDePostagem, 0, dadosDePostagem.Length);
            }

            return _requisitor;
        }
        #endregion
    }
}
