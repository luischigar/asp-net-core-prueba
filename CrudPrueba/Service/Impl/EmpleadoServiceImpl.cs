using CrudPrueba.Models;
using CrudPrueba.Service.Dto;
using CrudPrueba.Service.Mapper;
using Microsoft.EntityFrameworkCore;

namespace CrudPrueba.Service.Impl
{
    public class EmpleadoServiceImpl : EmpleadoService
    {
        private DbCrudCoreContext _dbCrudCoreContext;
        private EmpleadoMapper empleadoMapper;
        public EmpleadoServiceImpl(DbCrudCoreContext _dbCrudCoreContext, EmpleadoMapper empleadoMapper)
        {
            this._dbCrudCoreContext = _dbCrudCoreContext;
            this.empleadoMapper = empleadoMapper;
        }

        public void deleteEmpleado(int id)
        {
            Empleado oEmpleado = _dbCrudCoreContext.Empleados.Find(id);
            if (oEmpleado == null)
            {
                throw new System.Exception("Empleado no encontrado");
            }
            _dbCrudCoreContext.Empleados.Remove(oEmpleado);
            _dbCrudCoreContext.SaveChanges();
            
        }

        public async Task<Empleado> edictEmpleado(Empleado empleado)
        {
            Empleado oEmpleado = await _dbCrudCoreContext.Empleados.FindAsync(empleado.IdEmpleado);
            if (oEmpleado == null)
            {
                throw new System.Exception("Empleado no encontrado");
            }
            try
            {
                oEmpleado.NombreCompleto = empleado.NombreCompleto;
                oEmpleado.Correo = empleado.Correo;
                oEmpleado.Telefono = empleado.Telefono;
                oEmpleado.IdCargo = empleado.IdCargo;

                _dbCrudCoreContext.Empleados.Update(oEmpleado);
                await _dbCrudCoreContext.SaveChangesAsync();

                return oEmpleado;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Ocurrio un Error");
            }
        }

        public async Task<List<EmpleadoDto>> getAllEmpleado()
        {
            try
            {
                List<EmpleadoDto> empleadoDtos = new List<EmpleadoDto>();
                List<Empleado> empleados = await _dbCrudCoreContext.Empleados.ToListAsync();
                empleados.ForEach(e =>
                {
                    empleadoDtos.Add(empleadoMapper.empleadoToEmpleadoDto(e));
                });
                return empleadoDtos;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Ocurrio un error");
            }
        }

        public async Task<Empleado> getEmpleadoById(int id)
        {
            Empleado oEmpleados = await _dbCrudCoreContext.Empleados.FindAsync(id);
            if (oEmpleados == null)
            {
                throw new System.Exception("Empleado no encontrado");
            }

            try
            {
                return oEmpleados;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Ocurrio algo");
            }
        }

        public async Task<Empleado> saveEmpleado(Empleado empleado)
        {
            try
            {
                await _dbCrudCoreContext.Empleados.AddAsync(empleado);
                _dbCrudCoreContext.SaveChanges();
                return empleado;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Ocurrio algo");
            }
        }
    }
}
