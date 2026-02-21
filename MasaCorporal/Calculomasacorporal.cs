using Microsoft.AspNetCore.Mvc;

namespace ProyectoApi.Controllers
{
    [ApiController]
    [Route("api/Indicadores")]
    public class IndicadoresController : ControllerBase
    {
        [HttpGet("calcular-imc")]
        public IActionResult ObtenerIndiceMasaCorporal([FromQuery] double pesoKg, [FromQuery] double estaturaM)
        {
            if (pesoKg <= 0 || estaturaM <= 0)
            {
                return BadRequest(new { mensaje = "El peso y la estatura deben ser valores mayores que cero." });
            }

            // Cálculo del IMC
            double indice = pesoKg / Math.Pow(estaturaM, 2);
            indice = Math.Round(indice, 2);

            string estadoNutricional;


            if (indice < 18.5)
            {
                estadoNutricional = "Peso inferior al recomendado";
            }
            else if (indice < 25)
            {
                estadoNutricional = "Peso adecuado";
            }
            else if (indice < 30)
            {
                estadoNutricional = "Nivel de sobrepeso";
            }
            else
            {
                estadoNutricional = "Obesidad - Se recomienda control médico";
            }


            var respuesta = new
            {
                Peso = pesoKg,
                Estatura = estaturaM,
                IMC = indice,
                Categoria = estadoNutricional
            };

            return Ok(respuesta);
        }
    }
}