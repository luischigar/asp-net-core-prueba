using CrudPrueba.Models;
using CrudPrueba.Service.Dto;

namespace CrudPrueba.Service.Mapper
{
    public interface EmpleadoMapper
    {
        EmpleadoDto empleadoToEmpleadoDto(Empleado empleado);
    }
}
