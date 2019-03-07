using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SigmaWeb.Models;
using Google.Cloud.BigQuery.V2;
using Microsoft.AspNetCore.Http;

namespace SigmaWeb.Controllers
{
    public class HomeController : Controller
    {
        private const string ProjectId = "pivotal-cursor-231608";
        private const string NumObra = "O00900";
        private BigQueryClient GetBigqueryClient(){ return BigQueryClient.Create(ProjectId); }
        
        //Lleva a la página de registro
        public IActionResult Register()
        {
            return View();
        }

        //Obtiene los CM de una obra
        [Authorize]
        public IActionResult Index()
        {
            //Query para obtener ciertos datos del CM
            string getCMs = $@"SELECT Digitalizado, IDCM, cod_CM_Cliente, calleCM, numCM, situacion, IDTipoGobierno, IDTipoCaja, potenciaCM, entSal16, fechaAltaCM, fechaBajaCM from Valencia.CM where num_obra = '"+ NumObra +"' order by idcm asc;";
            
            //Almacenamos el resultado de la query en results para enviarlos a la vista
            ViewBag.results = GetBigqueryClient().ExecuteQuery(getCMs, parameters: null);
            
            return View();
        }

        //Crear un CM
        [Authorize]
        [HttpPost]
        public IActionResult CreateCm(IFormCollection collection)
        {
            string idcm = collection["IDCM"];
            string codCmCliente = collection["cod_CM_Cliente"];
            string calleCm = collection["calleCM"];
            var numCm = collection["numCM"];
            if (numCm == ""){numCm = "null";}
            string situacion = collection["situacion"];
            string idTipoGobierno = collection["IDTipoGobierno"];
            string idTipoCaja = collection["IDTipoCaja"];
            var potenciaCm = collection["potenciaCM"];
            if (potenciaCm == ""){potenciaCm = "null";}
            
            
            //Si las fechas llegan vacías, las cambiamos a "null" para que no haya conflicto en la BBDD
            string fechaAltaCm = collection["fechaAltaCM"];
            if (fechaAltaCm == ""){fechaAltaCm = "null";}else{fechaAltaCm = "\""+fechaAltaCm+"\"";}
            string fechaBajaCm = collection["fechaBajaCM"];
            if (fechaBajaCm == ""){fechaBajaCm = "null";}else{fechaBajaCm = "\""+fechaBajaCm+"\"";}
            
            //Creamos el nuevo CM
            string addCm = $@"INSERT into Valencia.CM (num_obra, IDCM, cod_CM_Cliente, calleCM, numCM, situacion, IDTipoGobierno, IDTipoCaja, potenciaCM, fechaAltaCM, fechaBajaCM) values ('" + NumObra + "', '" + idcm + "', '"+ codCmCliente + "', '" + calleCm + "', "+ numCm + ", '"+ situacion + "', '" + idTipoGobierno + "', '" + idTipoCaja + "', "+ potenciaCm + ", "+ fechaAltaCm + ","+ fechaBajaCm + ")";
            Console.WriteLine(addCm);
            GetBigqueryClient().ExecuteQuery(addCm, parameters: null);
            
            return RedirectToAction("Index");
        }
        
        //Actualizar un CM
        [Authorize]
        [HttpPost]
        public IActionResult EditCm(IFormCollection collection)
        {
            string idcm = collection["IDCM"];
            string codCmCliente = collection["cod_CM_Cliente"];
            string calleCm = collection["calleCM"];
            var numCm = collection["numCM"];
            if (numCm == ""){numCm = "null";}
            string situacion = collection["situacion"];
            string idTipoGobierno = collection["IDTipoGobierno"];
            string idTipoCaja = collection["IDTipoCaja"];
            var potenciaCm = collection["potenciaCM"];
            if (potenciaCm == ""){potenciaCm = "null";}
            string idcmOri = collection["idcmOri"];
            
            //Si las fechas llegan vacías, las cambiamos a "null" para que no haya conflicto en la BBDD
            string fechaAltaCm = collection["fechaAltaCM"];
            if (fechaAltaCm == ""){fechaAltaCm = "null";}else{fechaAltaCm = "\""+fechaAltaCm+"\"";}
            string fechaBajaCm = collection["fechaBajaCM"];
            if (fechaBajaCm == ""){fechaBajaCm = "null";}else{fechaBajaCm = "\""+fechaBajaCm+"\"";}
            
            
            //Query para actualizar el CM
            string updateCm = $@"UPDATE Valencia.CM set IDCM = '" + idcm + "', cod_CM_Cliente = '"+ codCmCliente +"', calleCM = '"+calleCm+"', numCM = "+numCm+", situacion = '"+situacion+"', IDTipoGobierno =  '"+idTipoGobierno+"', IDTipoCaja = '"+idTipoCaja+"', potenciaCM = "+potenciaCm+", fechaAltaCM = "+fechaAltaCm+", fechaBajaCM = "+fechaBajaCm+" where num_obra = '"+NumObra+"' and IDCM = '"+idcmOri+"'";
            //Actualizamos el nuevo CM
            GetBigqueryClient().ExecuteQuery(updateCm, parameters: null);

            return RedirectToAction("Index");
        }

        //Borrar un CM
        [Authorize]
        [HttpPost]
        public IActionResult DeleteCm(IFormCollection collection)
        {
            //Obtenemos el IDCM de la vista
            string idcm = collection["IDCM"];
            
            //Query para borrar el CM
            string deleteCm = $@"delete from Valencia.CM where idcm = '"+idcm+"'";
            GetBigqueryClient().ExecuteQuery(deleteCm, parameters: null);
            
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
