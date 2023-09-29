using CrudPrueba.Models;
using CrudPrueba.Service.Dto;

namespace CrudPrueba.Service.Mapper.Impl
{
    public class EmpleadoMapperImpl : EmpleadoMapper
    {
        public EmpleadoDto empleadoToEmpleadoDto(Empleado empleado)
        {
            return new EmpleadoDto(empleado.IdEmpleado,
                empleado.NombreCompleto,
                empleado.Correo,
                empleado.Telefono,
                empleado.IdCargo
                );
        }
    }
}
