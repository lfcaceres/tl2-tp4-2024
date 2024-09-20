using System.Globalization;

public enum Estado
{
    Pendiente,
    Entregado
}

public class Pedido
{
    int NumPedido;
    string Obs;
    Cliente clientes;
    Estado estados;
    Cadete cadete;

    public Pedido(int num, string obs, string nomb, string dir, string tel, string dat) //: Cliente(nomb,dir,tel,dat)
    {
        NumPedido1 = num;
        Obs1 = obs;
        Clientes = new Cliente(nomb,dir,tel,dat);
        Estados = Estado.Pendiente;
        Cadete = new Cadete();
    }

  
    public int NumPedido1 { get => NumPedido; set => NumPedido = value; }
    public string Obs1 { get => Obs; set => Obs = value; }
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