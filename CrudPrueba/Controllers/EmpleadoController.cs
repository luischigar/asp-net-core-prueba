using CrudPrueba.Models;
using CrudPrueba.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudPrueba.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private EmpleadoService empleadoService;
        public EmpleadoController(EmpleadoService empleadoService)
        {
            this.empleadoService = empleadoService;
        }
        [HttpGet]
        [Route("empleados")]
        public async Task<IActionResult> getEmpleado()
        {
            return StatusCode(StatusCodes.Status200OK, await empleadoService.getAllEmpleado());
        }
        [HttpGet]
        [Route("empleados/{id:int}")]
        public async Task<IActionResult> getEmpleadoById(int id)
        {
            return StatusCode(StatusCodes.Status200OK,await empleadoService.getEmpleadoById(id));
        }
        [HttpPost]
        [Route("empleados")]
        public async Task<IActionResult> saveEmpleado([FromBody] Empleado empleado)
        {
            return StatusCode(StatusCodes.Status201Created, await empleadoService.saveEmpleado(empleado));
        }
        [HttpPut]
        [Route("empleados")]
        public async Task<IActionResult> edictEmpleado([FromBody] Empleado empleado)
        {
            return StatusCode(StatusCodes.Status200OK, await empleadoService.edictEmpleado(empleado));
        }
        [HttpDelete]
        [Route("empleados/{id:int}")]
        public IActionResult deleteEmpleado(int id)
        {
            empleadoService.deleteEmpleado(id);
            return StatusCode(StatusCodes.Status200OK, new { mensaje = "Eliminado" });
        }
    }
}
