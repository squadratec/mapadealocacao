using SQH.DataAccess.Contract;
using SQH.Entities.Database;
using SQH.Entities.Sharepoint;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SQH.DataAccess.Service
{
    public class SharepointRepository : ISharepointRepository
    {
        private readonly IRecursoRepository recursoRepository;
       // private readonly IProjetoRepository projetoRepository;

        public SharepointRepository(IRecursoRepository _recursoRepository)
        {
            recursoRepository = _recursoRepository;
            //projetoRepository = _projetoRepository;
        }

        public async void AtualizarProjetos()
        {
            using (var client = InstanciaClient())
            {
                Feed feed = await ConverteXML(client, @"http://sharepoint.go2wings.com.br/_api/web/lists/getbytitle('projetos')/items");

                foreach (var entry in feed.entry)
                {
                    var user = entry.content.properties;

                    Recurso rec = recursoRepository.FindByID(user.idUsuario);

                    if (rec == null)
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

        public async void AtualizarRecursos()
        {
            using (var client = InstanciaClient())
            {
                Feed feed = await ConverteXML(client, @"http://sharepoint.go2wings.com.br/_api/Web/SiteUsers");

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
    }
}
