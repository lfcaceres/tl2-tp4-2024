
using System.Data.Common;

public class Cadete
{
    private string? id;

    private string? nombre;

    private string? direccion;

    private string? telefono;
    //

    public Cadete()
    {
       
        //listaPedidos = new List<Pedido>();
    }
    public Cadete(string id,string nombre, string direccion, string telefono)
    {
        this.Id=id;
        this.Nombre = nombre;
        this.Direccion = direccion;
        this.Telefono = telefono;
        //listaPedidos = new List<Pedido>();
    }
   
    public string? Direccion { get => direccion; set => direccion = value; }
    public string? Telefono { get => telefono; set => telefono = value; }
    public string? Id { get => id; set => id = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    /*public void AgregarPedido(Pedido pedido)
{
this.listaPedidos.Add(pedido);
}*/
}