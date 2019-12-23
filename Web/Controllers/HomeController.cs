
using System;
using System.Web.Mvc;
using Negocio.Clases;
using Datos.Entidades;
using System.Collections.Generic;
using Datos.Dto;

namespace Web.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult guardarDatosProductos()
        {

            Producto cnProducto = new Producto();
            DtoProducto objProducto = new DtoProducto();

            try
            {

                String Mensaje = "";
                decimal reslAccion = 0;

                objProducto.NombreProducto = Request["txtNombreProducto"];
                objProducto.DescripcionProducto = Request["txtDescripcionProducto"];
                objProducto.IdCompania = Convert.ToInt32(Request["slCompania"]);                

                reslAccion = cnProducto.crear(objProducto);

                if (reslAccion > 0)
                {
                    Mensaje = "Se registro exitosamente";
                }

                return Json(new { actionResponse = true, data = "", mensaje = Mensaje, typeAcc = 1 });

            }
            catch (Exception ex)
            {
                return Json(new { actionResponse = false, data = "", mensaje = ex.Message, typeAcc = 1 });
            }

        }

        [HttpPost]
        public ActionResult guardarDatosClientes()
        {

            Cliente cnCliente = new Cliente();
            DtoCliente objCliente = new DtoCliente();
            DtoProducto objProducto = new DtoProducto();

            try
            {

                String Mensaje = "";
                decimal reslAccion = 0;

                objCliente.Nombres = Request["txtNombres"];
                objCliente.Movil = Request["txtMovil"];
                objCliente.Direccion= Request["txtDireccion"];
                objCliente.Edad = Request["txtEdad"];
                objProducto.IdProducto = Convert.ToInt32(Request["slProducto"]);

                reslAccion = cnCliente.crear(objCliente, objProducto);

                if (reslAccion > 0)
                {
                    Mensaje = "Se registro exitosamente";
                }

                return Json(new { actionResponse = true, data = "", mensaje = Mensaje, typeAcc = 1 });

            }
            catch (Exception ex)
            {
                return Json(new { actionResponse = false, data = "", mensaje = ex.Message, typeAcc = 1 });
            }

        }

        [HttpPost]
        public ActionResult loadCompania()
        {
            try
            {
                bool reslAccion = false;
                Compania cnCompania = new Compania();
                List<DtoCompania> ltCompania = new List<DtoCompania>();
                DtoCompania dtoCompania = new DtoCompania();
                dtoCompania.IdCompania = 0;
                dtoCompania.NombreCompania = "Seleccionar...";

                ltCompania = cnCompania.cargarCompanias();

                if (ltCompania.Count > 0)
                {
                    ltCompania.Insert(0,dtoCompania);
                    reslAccion = true;
                }

                return Json(new { actionResponse = reslAccion, data = ltCompania, mensaje = "", typeAcc = 2 });

            }
            catch (Exception ex)
            {
                return Json(new { actionResponse = false, data = "", mensaje = ex.Message, typeAcc = 2 });
            }
        }

        [HttpPost]
        public ActionResult loadProductosCompania()
        {
            try
            {

                bool reslAccion = false;
                Producto cnProducto = new Producto();
                List<DtoProducto> ltProducto = new List<DtoProducto>();
                DtoProducto dtoProducto = new DtoProducto();

                dtoProducto.IdProducto = 0;
                dtoProducto.NombreProducto = "Seleccionar...";

                int idCompania = Convert.ToInt32(Request["slCompaniaUsr"]);

                ltProducto = cnProducto.obtenerProductosxCompania(idCompania);

                if (ltProducto.Count > 0)
                {
                    ltProducto.Insert(0, dtoProducto);
                    reslAccion = true;
                }

                return Json(new { actionResponse = reslAccion, data = ltProducto, mensaje = "", typeAcc = 3 });

            }
            catch (Exception ex)
            {
                return Json(new { actionResponse = false, data = "", mensaje = ex.Message, typeAcc = 3 });
            }
        }

    }
}