using dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using negocio;
using System.Data.SqlClient;

namespace discos_mvc.Controllers
{
    public class DiscosController : Controller
    {
        // GET: DiscosController
        public ActionResult Index()
        {
            DiscoNegocio discoNegocio = new DiscoNegocio();
            List<Disco> discos = discoNegocio.listar();
            foreach (var item in discos)
            {
                item.FechaLanzamiento = item.FechaLanzamiento.Date;
            }
            return View(discos);
        }

        // GET: DiscosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DiscosController/Create
        public ActionResult Create()
        {
            Disco disco = new Disco();
            EstiloNegocio estiloNegocio = new EstiloNegocio();
            TipoEdicionNegocio tipoEdicionNegocio = new TipoEdicionNegocio();

            ViewBag.Estilos = new SelectList(estiloNegocio.listar(), "Id", "Descripcion");
            ViewBag.TiposEdicion = new SelectList(tipoEdicionNegocio.listar(), "Id", "Descripcion");

            return View(disco);
        }

        // POST: DiscosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Disco disco)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrWhiteSpace(disco.UrlTapa))
                        disco.UrlTapa = "";
                    DiscoNegocio discoNegocio = new DiscoNegocio();
                    discoNegocio.agregar(disco);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Create));
            }
        }

        // GET: DiscosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DiscosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DiscosController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        DiscoNegocio discoNegocio = new DiscoNegocio();
        //        var disco = discoNegocio.listar().FirstOrDefault(d => d.Id == id);
        //        if (disco == null)
        //            return NotFound();
        //        return View(disco);
        //    }
        //    catch (Exception)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //}

        // POST: DiscosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                DiscoNegocio discoNegocio = new DiscoNegocio();
                discoNegocio.eliminar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
