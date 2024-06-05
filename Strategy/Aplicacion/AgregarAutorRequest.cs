namespace Api.Microservice.Autor.Aplicacion
{
    public class AgregarAutorRequest
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}
