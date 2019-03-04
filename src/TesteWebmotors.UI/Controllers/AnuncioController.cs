using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteWebmotors.Domain.Interfaces.Services;
using TesteWebmotors.Domain.Models;
using Newtonsoft.Json;

namespace TesteWebmotors.UI.Controllers
{
    public class AnuncioController : Controller
    {
        private IAnuncioService _anuncioService;
        private IConsultaAPIService _apiService;

        public AnuncioController()
        {
            _anuncioService = IoC.IoC.Container.GetInstance<IAnuncioService>();
            _apiService = IoC.IoC.Container.GetInstance<IConsultaAPIService>();
        }
        
        public ActionResult Index()
        {
            IEnumerable<Anuncio> anuncios = _anuncioService.RetornarTodos();
            return View(anuncios);
        }
                
        public ActionResult Details(int id)
        {
            Anuncio anuncio = _anuncioService.RetornarPorId(id);
            return View(anuncio);
        }
        
        public ActionResult Create()
        {
            IEnumerable<Marca> marcas = _apiService.ConsultarMarcas();
            IEnumerable<Veiculo> veiculos = _apiService.ConsultarVeiculos();
            ViewBag.Marcas = JsonConvert.SerializeObject(marcas);
            ViewBag.Veiculos = JsonConvert.SerializeObject(veiculos);
            return View();
        }

        // POST: Anuncio/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Anuncio/Edit/5
        public ActionResult Edit(int id)
        {
            Anuncio anuncio = _anuncioService.RetornarPorId(id);
            return View(anuncio);
        }

        // POST: Anuncio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Anuncio/Delete/5
        public ActionResult Delete(int id)
        {
            Anuncio anuncio = _anuncioService.RetornarPorId(id);
            return View(anuncio);
        }

        // POST: Anuncio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Anuncio anuncio = _anuncioService.RetornarPorId(id);
                _anuncioService.Remover(anuncio);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
