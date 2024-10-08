using System.Text.Json;
using System.Text.Json.Serialization;

namespace MiAplicacion;
public class accesoDatosPedidos
{
     public bool ExisteArchivo(string ruta)
     {
        FileInfo f = new FileInfo(ruta);
        if(f.Exists && f.Length > 0){
            return true;
        }else{
            return false;
        }
    }

    public  List<Pedido> Obtener(string ruta)
    {
        List<Pedido> pedidos = new List<Pedido>();
        if(ExisteArchivo(ruta))
        {
            string[] datosPedidos;
            using StreamReader s = new StreamReader(ruta);
            string linea = s.ReadLine();
            {
                while(linea != null)
                {
                    
                    datosPedidos = linea.Split(',');
                    Pedido varpedido = new Pedido(Int32.Parse(datosPedidos[0]), datosPedidos[1], datosPedidos[2], datosPedidos[3],datosPedidos[4],datosPedidos[5]);
                    pedidos.Add(varpedido);
                    linea = s.ReadLine();
                }
                
            }
            
        }
        return pedidos;
    }

    public void Guardar(List<Pedido> Pedidos, string ruta)
    {
        using (StreamWriter writer = new StreamWriter(ruta))
        {
            // Escribir los datos de cada pedido
            foreach (var pedido in Pedidos)
            {
                writer.WriteLine($"{pedido.NumPedido},{pedido.Obs},{pedido.Clientes.Nombre},{pedido.Clientes.Direccion},{pedido.Clientes.Telefono},{pedido.Clientes.DatosRefDir},{pedido.Estados}");
            }
        }
    }
    
}