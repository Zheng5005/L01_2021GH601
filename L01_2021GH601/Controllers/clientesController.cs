using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2021GH601.Models;
using Microsoft.EntityFrameworkCore;

namespace L01_2021GH601.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class restuaranteDBController : ControllerBase
    {
        private readonly restuaranteDBContext _restuaranteDBContext;
        public restuaranteDBController(restuaranteDBContext restuaranteDBContext)
        {
            _restuaranteDBContext = restuaranteDBContext;
        }

        [HttpGet]
        [Route("GetAllCliente")]
        public IActionResult GetCli()
        {
            List<clientes> listadoClientes = (from e in _restuaranteDBContext.clientes
                                           select e).ToList();
            if (listadoClientes.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoClientes);
        }

        [HttpGet]
        [Route("GetAllMotorista")]
        public IActionResult GetMoto()
        {
            List<motorista> listadomoto = (from e in _restuaranteDBContext.motorista
                                              select e).ToList();
            if (listadomoto.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadomoto);
        }

        [HttpGet]
        [Route("GetAllPedido")]
        public IActionResult GetPed()
        {
            List<pedidos> listadoPedidos = (from e in _restuaranteDBContext.pedidos
                                              select e).ToList();
            if (listadoPedidos.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoPedidos);
        }

        [HttpGet]
        [Route("GetAllPlatos")]
        public IActionResult GetPla()
        {
            List<platos> listadoplatos = (from e in _restuaranteDBContext.platos
                                              select e).ToList();
            if (listadoplatos.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoplatos);
        }

        [HttpPost]
        [Route("AddCli")]
        public IActionResult GuardarEquipo([FromBody] clientes Clientes)
        {
            try
            {
                _restuaranteDBContext.clientes.Add(Clientes);
                _restuaranteDBContext.SaveChanges();
                return Ok(Clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddMoto")]
        public IActionResult Guardarmoto([FromBody] motorista Moto)
        {
            try
            {
                _restuaranteDBContext.motorista.Add(Moto);
                _restuaranteDBContext.SaveChanges();
                return Ok(Moto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddPed")]
        public IActionResult GuardarPed([FromBody] pedidos Pedido)
        {
            try
            {
                _restuaranteDBContext.pedidos.Add(Pedido);
                _restuaranteDBContext.SaveChanges();
                return Ok(Pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddPlato")]
        public IActionResult GuardarPlato([FromBody] platos Plato)
        {
            try
            {
                _restuaranteDBContext.platos.Add(Plato);
                _restuaranteDBContext.SaveChanges();
                return Ok(Plato);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("actualizar/{id}")]
        public IActionResult ActualizarEquipo(int id, [FromBody] clientes ClinetesMOD)
        {
            clientes? clientes = (from e in _restuaranteDBContext.clientes
                                  where e.clienteId == id
                                  select e).FirstOrDefault();
            if (clientes == null)
            {
                return NotFound();
            }

            clientes.nombreCliente = ClinetesMOD.nombreCliente;
            clientes.direccion = ClinetesMOD.direccion;

            _restuaranteDBContext.Entry(clientes).State = EntityState.Modified;
            _restuaranteDBContext.SaveChanges();

            return Ok(ClinetesMOD);
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public IActionResult EliminarEquipo(int id)
        {
            clientes? Equipo = (from e in _restuaranteDBContext.clientes
                               where e.clienteId == id
                               select e).FirstOrDefault();
            if (Equipo == null)
            {
                return NotFound();
            }

            _restuaranteDBContext.clientes.Attach(Equipo);
            _restuaranteDBContext.clientes.Remove(Equipo);
            _restuaranteDBContext.SaveChanges();

            return Ok(Equipo);
        }

    }

}
