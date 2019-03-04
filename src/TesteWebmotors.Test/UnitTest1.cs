using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteWebmotors.UI.IoC;
using SimpleInjector;
using TesteWebmotors.Domain.Models;
using System.Collections.Generic;
using TesteWebmotors.Domain.Interfaces.Services;
using System.Linq;

namespace TesteWebmotors.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConsultaMarcas()
        {
            Container container = IoC.Registrar();
            IConsultaAPIService service = container.GetInstance<IConsultaAPIService>();

            IEnumerable<Marca> marcas =  service.ConsultarMarcas();

            Assert.IsNotNull(marcas);
        }



        [TestMethod]
        public void OperacoesDbAnuncio()
        {
            Container container = IoC.Registrar();
            IAnuncioService service = container.GetInstance<IAnuncioService>();

            Anuncio anuncio = new Anuncio()
            {
                Ano = 2018,
                Marca = "Honda",
                Modelo = "Fit",
                Quilometragem = 0,
                Versao = "1.4 LXL 16V FLEX 4P AUTOMÁTICO",
                Observacao = ""
            };
            service.Inserir(anuncio);
            Assert.IsTrue(anuncio.Id > 0);

            anuncio.Observacao = "Nova Observacao";
            service.Atualizar(anuncio);

            Anuncio anuncioId = service.RetornarPorId(anuncio.Id);
            Assert.IsNotNull(anuncioId);

            List<Anuncio> anunciosFiltro = service.RetornarPorFiltro(a => a.Modelo.Equals("Fit")).ToList();
            Assert.IsNotNull(anunciosFiltro);

            List<Anuncio> anunciosTodos = service.RetornarTodos().ToList();
            Assert.IsNotNull(anunciosTodos);

            service.Remover(anuncio);
            anuncioId = service.RetornarPorId(anuncio.Id);
            Assert.IsNull(anuncioId);
        }
    }
}
