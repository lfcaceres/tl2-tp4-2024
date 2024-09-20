using System.Dynamic;
using System.Linq;

public class Cadeteria
{
    private string? nombre;
    private string? telefono;
    private List<Cadete> ListaCadete;
    private List<Pedido> listaPedidos;

    public Cadeteria()
    {
        //Nombre = " POR DEFECTO ";
        //Telefono = " ";
        ListaCadete = new List<Cadete>();
        listaPedidos = new List<Pedido>();
    }

    public Cadeteria(string nombre, string telefono)
    {

        this.Nombre = nombre;
        this.telefono = telefono;
        ListaCadete = new List<Cadete>();
        listaPedidos = new List<Pedido>();
    }

    public Cadeteria(string ruta)
    {
        AccesoDatos acceso;

        if((ruta.Substring(ruta.Length - 4))== ".csv")
        {
            acceso = new AccesoCSV();
        }else
        {
            acceso = new AccesoJSON();
        }

        nombre = acceso.ObtenerCadeteria(ruta).Nombre;
        telefono = acceso.ObtenerCadeteria(ruta).Telefono;
        ListaCadete = new List<Cadete>();
        listaPedidos = new List<Pedido>();
    }

    public string? Telefono { get => telefono; set => telefono = value; }
    public string? Nombre { get => nombre; set => nombre = value; }

    public void AgregarCadete(string id,string nombre, string direccion, string telefono)
    {
        Cadete cadete1 = new Cadete(id,nombre,direccion,telefono);
        ListaCadete.Add(cadete1);
    }

    public void AgregarListaCadetes(List<Cadete> listaCadetes){
        this.ListaCadete = listaCadetes;
    }
public void AgregarPedido(Pedido ped)
    {
        if(ped != null)
        {
            listaPedidos.Add(ped);
        }
    }
    public void AgregarPedido(int num, string obs, string nomb, string dir, string tel, string dat)
    {
        Pedido ped = new Pedido(num,obs,nomb,dir,tel,dat);
        if(ped != null)
        {
            listaPedidos.Add(ped);
        }
    }

    public bool CambiarPedidoaEntregado(int id)
        {

        foreach (var p in from p in listaPedidos
                          where p.NumPedido1 == id
                          select p)
        {
            p.Estados = Estado.Entregado;
        }
        return true;
    }
    public int CantPedidosCadete(string idCadete){
        int cant = 0;
        foreach(var p in listaPedidos)
        {
            if((p.IdCadete() == idCadete) && (p.Estados == Estado.Entregado))
            {
                cant++;
            } 
        }

        return cant;
    }

    public Cadete ObtenerCadete(int i)
    {
     return this.ListaCadete[i];
    }

    public List<Pedido> listarPedido()
    {
        List<Pedido> pedidos = new List<Pedido>();
        foreach (var p in listaPedidos)
        {
            pedidos.Add(p);
        }
        return pedidos;
    }

    public List<Cadete> listarCadete()
    {
        List<Cadete> cadetes = new List<Cadete>();
        foreach (var p in ListaCadete)
        {
            cadetes.Add(p);
        }
        return cadetes;
    }
   /* public string[] TotalNombreCadete()
    {
        string[] total;
        int i=0;
        foreach(Cadete name in this.ListaCadete)
        {
            total[i]= name.Nombre;
            i++;
        }
        return total;
    }*/
    public double JornalACobrar(string idCadete){
        return ((double)500 * CantPedidosCadete(idCadete));
    }
}