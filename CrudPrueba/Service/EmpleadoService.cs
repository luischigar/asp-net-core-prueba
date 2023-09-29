using CrudPrueba.Models;
using CrudPrueba.Service.Dto;

namespace CrudPrueba.Service
{
    public interface EmpleadoService
    {
        Task<List<EmpleadoDto>> getAllEmpleado();
        Task<Empleado> getEmpleadoById(int id);
        Task<Empleado> saveEmpleado(Empleado empleado);
        Task<Empleado> edictEmpleado(Empleado empleado);
        void deleteEmpleado(int id);
    }
}
