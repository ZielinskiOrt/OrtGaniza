namespace OrtganizaPresentacion.Models
{
    public class ProyectoModel
    {
        public string Nombre { get; set; }
        public string Descripcion {  get; set; }
        public Guid PropietarioUserId { get; set; }
        public string PropietarioNombre{ get; set; }
        public int CantidadMiembros { get; set; }
        public bool LoginEsPropietario { get; set; }
        public List<Guid> MiembrosIds { get; set; } = new List<Guid>();
    }
}
