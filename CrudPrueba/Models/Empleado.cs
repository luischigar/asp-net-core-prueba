using System;
using System.Collections.Generic;

namespace CrudPrueba.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public int IdCargo { get; set; }

    public virtual Cargo objCargo { get; set; } = null!;
}
