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
            ViewBag.Marcas = JsonConvert.SerializeObject(marcas);
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            IEnumerable<Marca> marcas = _apiService.ConsultarMarcas();

            try
            {
                Anuncio model = new Anuncio();

                UpdateModel<Anuncio>(model, collection);

                Marca marca = marcas.FirstOrDefault(m => m.Id == Int32.Parse(model.Marca));
                Modelo modelo = marca.CarModels.FirstOrDefault(m => m.Id == Int32.Parse(model.Modelo));
                Versao versao = modelo.CarVersions.FirstOrDefault(m => m.Id == Int32.Parse(model.Versao));

                model.Marca = marca.Name;
                model.Modelo = modelo.Name;
                model.Versao = versao.Name;

                if (ModelState.IsValid)
                {
                    _anuncioService.Inserir(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Marcas = JsonConvert.SerializeObject(marcas);
                    return View(model);
                }
            }
            catch(Exception ex)
            {
                ViewBag.Marcas = JsonConvert.SerializeObject(marcas);
                return View();
            }
        }
        
        public ActionResult Edit(int id)
        {
            IEnumerable<Marca> marcas = _apiService.ConsultarMarcas();
            ViewBag.Marcas = JsonConvert.SerializeObject(marcas);
            Anuncio anuncio = _anuncioService.RetornarPorId(id);
            return View(anuncio);
        }
        
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            IEnumerable<Marca> marcas = _apiService.ConsultarMarcas();

            try
            {
                Anuncio model = new Anuncio();

                UpdateModel<Anuncio>(model, collection);

                Marca marca = marcas.FirstOrDefault(m => m.Id == Int32.Parse(model.Marca));
                Modelo modelo = marca.CarModels.FirstOrDefault(m => m.Id == Int32.Parse(model.Modelo));
                Versao versao = modelo.CarVersions.FirstOrDefault(m => m.Id == Int32.Parse(model.Versao));

                model.Marca = marca.Name;
                model.Modelo = modelo.Name;
                model.Versao = versao.Name;

                if (ModelState.IsValid)
                {
                    _anuncioService.Atualizar(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Marcas = JsonConvert.SerializeObject(marcas);
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Marcas = JsonConvert.SerializeObject(marcas);
                return View();
            }
        }
        
        public ActionResult Delete(int id)
        {
            Anuncio anuncio = _anuncioService.RetornarPorId(id);
            return View(anuncio);
        }
        
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Anuncio anuncio = _anuncioService.RetornarPorId(id);
                _anuncioService.Remover(anuncio);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
