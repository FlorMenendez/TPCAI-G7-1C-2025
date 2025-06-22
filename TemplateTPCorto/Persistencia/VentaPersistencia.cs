using Datos.Ventas;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Persistencia.WebService.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Persistencia
{
    public class VentaPersistencia
    {
        private Guid idUsuario = new Guid("784c07f2-2b26-4973-9235-4064e94832b5");

        public string agregarVenta(CargaVenta cargaVenta)
        {
            cargaVenta.IdUsuario = idUsuario;

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };
            var jsonRequest = JsonConvert.SerializeObject(cargaVenta, settings);

            System.Diagnostics.Debug.WriteLine("JSON enviado:\n" + jsonRequest);

            HttpResponseMessage response = WebHelper.Post("/api/Venta/AgregarVenta", jsonRequest);
            string contenidoRespuesta = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                return "ERROR\n" + contenidoRespuesta + "\n\nJSON enviado:\n" + jsonRequest;
            }

            return contenidoRespuesta; // incluso si es 200
        }
    }
}
