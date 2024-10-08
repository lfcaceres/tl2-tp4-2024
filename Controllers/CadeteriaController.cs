using Microsoft.AspNetCore.Mvc;

using MiAplicacion;

[Route("[controller]")]
[ApiController]
public class CadeteriaController : ControllerBase
{
    private Cadeteria cadeteria;
    private AccesoDatosCadeteria ADCadeteria;
    private accesoDatosCadetes ADCadetes;
    private accesoDatosPedidos ADPedidos;
public CadeteriaController()
{
ADCadeteria= new AccesoDatosCadeteria();
ADCadetes= new accesoDatosCadetes();
ADPedidos= new accesoDatosPedidos();
cadeteria= ADCadeteria.Obtener("datosCadeteria.csv");
cadeteria.AgregarListaCadetes(ADCadetes.Obtener("datosCadetes.csv"));
cadeteria.AgregarListaPedidos(ADPedidos.Obtener("datosPedidos.csv"));
}
    

    [HttpGet("Cadeteria")]
    public IActionResult GetCadeteria()
    {
        return Ok(cadeteria.Nombre);
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
            ADPedidos.Guardar(cadeteria.listarPedido(),"datosPedidos.csv");
            return Created();
    }

    [HttpPost("pedidosV2")]
    public ActionResult CrearPedido1([FromBody] Pedido pedido)
    {
            cadeteria.AgregarPedido(pedido);
            ADPedidos.Guardar(cadeteria.listarPedido(),"datosPedidos.csv");
            return Created();
    }

    [HttpPut("CambiarEstado")]
    public ActionResult CambiarEstado(int idPedido)
    {
        cadeteria.CambiarPedidoaEntregado(idPedido);
        ADPedidos.Guardar(cadeteria.listarPedido(),"datosPedidos.csv");
        return Ok();
    }
}