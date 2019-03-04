using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using TesteWebmotors.Domain.Interfaces.Services;
using TesteWebmotors.Domain.Models;

namespace TesteWebmotors.Domain.Services
{
    public class ConsultaAPIService : IConsultaAPIService
    {
        private const string API_MARCA = "http://desafioonline.webmotors.com.br/api/OnlineChallenge/Make";
        private const string API_MODELO = "http://desafioonline.webmotors.com.br/api/OnlineChallenge/Model";
        private const string API_VERSAO = "http://desafioonline.webmotors.com.br/api/OnlineChallenge/Version";


        public IEnumerable<Marca> ConsultarMarcas()
        {
            Dictionary<string, string> parametros = new Dictionary<string, string>();

            IEnumerable<Marca> marcas = ConsultarAPI<Marca>(API_MARCA);

            for (int m = 0; m < marcas?.Count(); m++)
            {
                parametros.Clear();
                parametros.Add("MakeID", marcas.ElementAt(m).Id.ToString());

                marcas.ElementAt(m).CarModels = ConsultarAPI<Modelo>(API_MODELO, parametros);

                for (int v = 0; v < marcas.ElementAt(m).CarModels?.Count(); v++)
                {
                    parametros.Clear();
                    parametros.Add("ModelID", marcas.ElementAt(m).CarModels.ElementAt(v).Id.ToString());

                    marcas.ElementAt(m).CarModels.ElementAt(v).CarVersions = ConsultarAPI<Versao>(API_VERSAO, parametros);
                }
            }

            return marcas;
        }

        public IEnumerable<Veiculo> ConsultarVeiculos()
        {
            List<Veiculo> veiculos = new List<Veiculo>();
            bool fimVeiculos = false;
            int pagina = 1;
            Dictionary<string, string> parametros = new Dictionary<string, string>();            

            while (!fimVeiculos)
            {
                parametros.Clear();
                parametros.Add("Page", pagina.ToString());

                var v = ConsultarAPI<Veiculo>(API_VEICULO, parametros);

                if (v?.Count() > 0)
                {
                    veiculos.AddRange(v);
                    pagina++;
                }
                else
                    fimVeiculos = true;
            }

            return veiculos;
        }


        private IEnumerable<TEntity> ConsultarAPI<TEntity>(string url, Dictionary<string, string> parametros = null)
            where TEntity : class
        {
            List<TEntity> objLista = new List<TEntity>();

            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;

                if (parametros != null)
                    foreach (var pair in parametros)
                        client.QueryString.Add(pair.Key, pair.Value);

                int tentativasMax = 5;
                int tentativaAtual = 1;

                while (tentativaAtual <= tentativasMax)
                {
                    try
                    {
                        var result = client.DownloadString(url);
                        objLista = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TEntity>>(result);
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (tentativaAtual == tentativasMax)
                            throw new Exception($"Erro ao consultar '{typeof(TEntity).Name}': {ex.Message}");
                        else
                            tentativaAtual++;
                    }
                }
            }

            return objLista;
        }
    }
}
