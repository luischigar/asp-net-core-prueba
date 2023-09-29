using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CrudPrueba.Models;

public partial class Cargo
{
    public int IdCargo { get; set; }

    public string Descripcion { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
