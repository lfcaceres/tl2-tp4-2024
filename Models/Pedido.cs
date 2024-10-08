using System.Globalization;

public enum Estado
{
    Pendiente,
    Entregado
}

public class Pedido
{
    int numPedido;
    string obs;
    Cliente clientes;
    Estado estados;
    Cadete cadete;

    public Pedido(int num, string obs, string nomb, string dir, string tel, string dat) //: Cliente(nomb,dir,tel,dat)
    {
        NumPedido = num;
        Obs = obs;
        Clientes = new Cliente(nomb,dir,tel,dat);
        Estados = Estado.Pendiente;
        Cadete = new Cadete();
    }

    public Pedido()
    {
    }

    public int NumPedido { get => numPedido; set => numPedido = value; }
    public string Obs { get => obs; set => obs = value; }
    public Cliente Clientes { get => clientes; set => clientes = value; }
    public Cadete Cadete { get => cadete; set => cadete = value; }
    public Estado Estados { get => estados; set => estados = value; }

    public void Entregado()
    {
        Estados = Estado.Entregado;
    }
    public void AsignarCadete(Cadete cad)
    {
        Cadete = cad;
    }
    public string IdCadete(){
        if (Cadete.Id != null)
        {
            return Cadete.Id;
        }else{
            return "";
        }
        
    }
}