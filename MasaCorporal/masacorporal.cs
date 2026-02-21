namespace ProyectoApi.Models
{
    public class ResultadoImcDto
    {
        public double PesoKg { get; set; }

        public double EstaturaM { get; set; }

        public double IndiceMasaCorporal { get; set; }

        public string Categoria { get; set; } = string.Empty;
    }
}