using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ProyectoApi.Controllers
{
    [ApiController]
    [Route("api/operaciones")]
    public class OperacionesController : ControllerBase
    {
        [HttpGet("multiplicacion/{valor}")]
        public IActionResult ObtenerTablaMultiplicar(int valor, [FromQuery] int limite = 10)
        {
            if (limite <= 0)
            {
                return BadRequest(new
                {
                    mensaje = "El límite debe ser mayor que cero."
                });
            }

            var resultados = new List<string>();

            for (int contador = 1; contador <= limite; contador++)
            {
                int producto = valor * contador;
                resultados.Add($"{valor} x {contador} = {producto}");
            }

            return Ok(new
            {
                numeroBase = valor,
                rango = limite,
                resultadoTabla = resultados
            });
        }
    }
}