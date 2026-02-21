using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ProyectoApi.DTOs;

namespace ProyectoApi.Controllers
{
    [ApiController]
    [Route("api/seguridad")]
    public class SeguridadController : ControllerBase
    {
        [HttpPost("validar-password")]
        public IActionResult ValidarPassword([FromBody] PasswordInputDto modelo)
        {
            if (modelo == null || string.IsNullOrWhiteSpace(modelo.Clave))
            {
                return BadRequest(new
                {
                    EsValida = false,
                    Mensaje = "Debe proporcionar una contraseña en el body."
                });
            }

            string texto = modelo.Clave;

            var validaciones = new PasswordValidationDetail
            {
                CumpleLongitudMinima = texto.Length >= 8,
                IncluyeMayuscula = texto.Any(char.IsUpper),
                IncluyeMinuscula = texto.Any(char.IsLower),
                IncluyeNumero = texto.Any(char.IsDigit),
                IncluyeCaracterEspecial = texto.Any(c => "@#$%&*".Contains(c))
            };

            bool resultadoFinal =
                validaciones.CumpleLongitudMinima &&
                validaciones.IncluyeMayuscula &&
                validaciones.IncluyeMinuscula &&
                validaciones.IncluyeNumero &&
                validaciones.IncluyeCaracterEspecial;

            var respuesta = new PasswordValidationResponse
            {
                EsValida = resultadoFinal,
                Mensaje = resultadoFinal
                    ? "La contraseña cumple con todos los criterios de seguridad."
                    : "La contraseña no cumple con los requisitos establecidos.",
                Detalles = validaciones
            };

            return Ok(respuesta);
        }
    }
}