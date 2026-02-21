namespace ProyectoApi.DTOs
{
    public class PasswordInputDto
    {
        public string Clave { get; set; } = string.Empty;
    }

    public class PasswordValidationDetail
    {
        public bool CumpleLongitudMinima { get; set; }
        public bool IncluyeMayuscula { get; set; }
        public bool IncluyeMinuscula { get; set; }
        public bool IncluyeNumero { get; set; }
        public bool IncluyeCaracterEspecial { get; set; }
    }

    public class PasswordValidationResponse
    {
        public bool EsValida { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public PasswordValidationDetail Detalles { get; set; } = new();
    }
}