using Microsoft.AspNetCore.Mvc;


[Route("[controller]")]
[ApiController]
public class CadeteriaController : ControllerBase
{
    private static Cadeteria? cadeteria;


    public static Cadeteria? InstanciarCadeteria(string ruta)
    {
        if(cadeteria != null)
        {
            cadeteria = new Cadeteria(ruta);
        }
        return cadeteria;
    }

    [HttpGet("pedidos")]
    public IActionResult GetPedido()
    {
        return Ok(cadeteria.listarPedido());
    }

   [HttpGet("cadetes")]
    public IActionResult GetCadete()
    {
        return Ok(cadeteria.listarCadete());
    }

    [HttpPost("pedidos")]
    public ActionResult CrearPedido(int numeroPedido, string observacionPedido, string nombreCliente, string direccionCliente, string telefonoCliente, string datosReferenciaDireccionCliente)
    {
            cadeteria.AgregarPedido(numeroPedido, observacionPedido, nombreCliente, direccionCliente, telefonoCliente, datosReferenciaDireccionCliente);
            return Ok();
    }

    [HttpPost("pedidosV2")]
    public ActionResult CrearPedido1([FromBody] Pedido pedido)
    {
            cadeteria.AgregarPedido(pedido);
            return Created("Cadeteria/Pedido", pedido);
    }

    [HttpPut("CambiarEstado")]
    public ActionResult CambiarEstado(int idPedido)
    {
        
        return Ok(cadeteria.CambiarPedidoaEntregado(idPedido));
    }
}