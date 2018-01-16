using SQH.DataAccess.Contract;
using SQH.Entities.Database;
using SQH.Entities.Sharepoint;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SQH.DataAccess.Service
{
    public class SharepointRepository : ISharepointRepository
    {
        private readonly IRecursoRepository recursoRepository;
        private readonly IProjetoRepository projetoRepository;

        public SharepointRepository(IRecursoRepository _recursoRepository, IProjetoRepository _projetoRepository)
        {
            recursoRepository = _recursoRepository;
            projetoRepository = _projetoRepository;
        }

        public void AtualizarProjetos()
        {
            using (var client = InstanciaClient())
            {
                Feed feed = ConverteXML(client, @"http://sharepoint.go2wings.com.br/_api/web/lists/getbytitle('projetos')/items").Result;

                foreach (var entry in feed.entry)
                {
                    var proj = entry.content.properties;

                    Projeto projeto = projetoRepository.FindByID(proj.ID);

                    if (projeto == null)
                    {
                        projeto = new Projeto();
                        projeto.DataCadastro = DateTime.Now;
                        projeto.IdProjeto = proj.ID;

                        if (String.IsNullOrEmpty(proj.LiderId))
                            projeto.IdRecurso = null;
                        else
                            Convert.ToInt32(proj.LiderId);
                        projeto.Nome = proj.Title;

                        projetoRepository.Add(projeto);
                    }
                }
            }
        }

        public void AtualizarRecursos()
        {
            using (var client = InstanciaClient())
            {
                Feed feed = ConverteXML(client, @"http://sharepoint.go2wings.com.br/_api/Web/SiteUsers").Result;

                foreach(var entry in feed.entry)
                {
                    var user = entry.content.properties;

                    Recurso rec = recursoRepository.FindByID(user.idUsuario);

                    if(rec == null)
                    {
                        rec = new Recurso();
                        rec.Nome = user.Title;
                        rec.Email = user.Email;
                        rec.IdRecurso = user.ID;
                        rec.DataCadastro = DateTime.Now;

                        recursoRepository.Add(rec);
                    }
                }
            }
        }

        #region Métodos Privados
        private HttpClient InstanciaClient()
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();

            string httpUserName = "bruno.polito", httpPassword = "squadra@2017";
            httpClientHandler.Credentials = new NetworkCredential(httpUserName, httpPassword);

            return new HttpClient(httpClientHandler);
        }

        private async Task<Feed> ConverteXML(HttpClient client, String url)
        {
            Feed retorno = new Feed();
            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            using (HttpContent content = response.Content)
            {
                string xml = await response.Content.ReadAsStringAsync();

                XmlSerializer serializer = new XmlSerializer(typeof(Feed));
                retorno = (Feed)serializer.Deserialize(new StringReader(xml));
            }
            return retorno;
        }
        #endregion
    }
}
