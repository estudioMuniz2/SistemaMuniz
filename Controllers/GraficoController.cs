using System.IO;
using io=System.IO;
using System.Web.Mvc;

namespace Demo49.Controllers
{
    public class GraficoController : Controller
    {
        public ActionResult Paint()
        {
            return View();
        }

        public string grabarBytes(string nombre)
        {
            string rpta = "";
            if (!string.IsNullOrEmpty(nombre))
            {
                long n = Request.InputStream.Length;
                if (n > 0)
                {
                    Stream flujo = Request.InputStream;
                    byte[] buffer = new byte[(int)n];
                    flujo.Read(buffer, 0, (int)n);
                    string ruta = Server.MapPath("~/Files/");
                    string archivo = Path.Combine(ruta, nombre);
                    io.File.WriteAllBytes(archivo, buffer);
                    rpta = "Se creo el archivo " + nombre;
                }
                else rpta = "No se envio los bytes del archivo";
            }
            else rpta = "No se envio el nombre del archivo";
            return rpta;
        }
    }
}