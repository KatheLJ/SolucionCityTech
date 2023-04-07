using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CapaDatos;
using CapaDatos.Entidades;

namespace LagarMVC.Controllers
{

    
    public class ProductoController : Controller
    {

        GestionBD objGestionBD;
        // GET: Producto
        public async Task<ActionResult> Index()
        {
            objGestionBD = new GestionBD();
            List<Producto> Listado = await objGestionBD.ObtenerProductosAsync();
            
            return View(Listado);
        }

        // GET: Producto/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            objGestionBD = new GestionBD();
            Producto auxProducto = await objGestionBD.ObtenerProductoAsync(id);
            if (auxProducto == null)
            {
                return HttpNotFound();
            }


            return View(auxProducto);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                objGestionBD = new GestionBD();
                Producto oProducto = new Producto();
                oProducto.NomProducto = collection["NomProducto"];
                oProducto.MarcaProducto = Convert.ToInt32(collection["MarcaProducto"]);
                oProducto.CostoProducto = Convert.ToDecimal(collection["CostoProducto"]);                
                int resulta = await objGestionBD.RegistrarProductoAsync(oProducto);   
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            objGestionBD = new GestionBD();
            Producto obj = new Producto();
            obj = await objGestionBD.ObtenerProductoAsync(id);
            return View(obj);

        }

        // POST: Producto/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                objGestionBD = new GestionBD();
                Producto auxProducto = new Producto();
                auxProducto.NomProducto = collection["NomProducto"];
                auxProducto.MarcaProducto = Convert.ToInt32(collection["MarcaProducto"]);
                auxProducto.CostoProducto = Convert.ToDecimal(collection["CostoProducto"]);
                int resulta= await objGestionBD.ActualizarProductoAsync(auxProducto, id);
                return RedirectToAction("Index");

            }
            catch
            {
                
                return View();
            }
        }

        // GET: Producto/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            objGestionBD = new GestionBD();
            Producto auxProducto = await objGestionBD.ObtenerProductoAsync(id);
            if (auxProducto == null)
            {
                return HttpNotFound();
            }


            return View(auxProducto);
        }

        // POST: Producto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAplicar(int id)
        {
            try
            {
                objGestionBD = new GestionBD();
                await objGestionBD.EliminarProductoAsyn(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
