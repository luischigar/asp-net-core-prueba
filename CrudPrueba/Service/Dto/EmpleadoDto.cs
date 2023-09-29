namespace CrudPrueba.Service.Dto
{
    public class EmpleadoDto
    {
        public int IdEmpleado { get; set; }

        public string NombreCompleto { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public int IdCargo { get; set; }
        public EmpleadoDto (int IIdEmpleado, string NombreCompleto, string Correo, string Telefono, int IdCargo)
        {
            this.IdEmpleado = IIdEmpleado;
            this.NombreCompleto = NombreCompleto;
            this.Correo = Correo;
            this.Telefono = Telefono;
            this.IdCargo = IdCargo;
        }
    }
}
