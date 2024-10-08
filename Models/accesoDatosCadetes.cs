using System.Text.Json;
using System.Text.Json.Serialization;

namespace MiAplicacion;
public class accesoDatosCadetes
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
    public  List<Cadete> Obtener(string ruta)
    {
        List<Cadete> cadetes = new List<Cadete>();
        if(ExisteArchivo(ruta))
        {
            string[] datosCadete;
            using StreamReader s = new StreamReader(ruta);
            string linea = s.ReadLine();
            {
                while(linea != null)
                {
                    datosCadete = linea.Split(',');
                    Cadete cadete = new Cadete(datosCadete[0], datosCadete[1], datosCadete[2], datosCadete[3]);
                    cadetes.Add(cadete);
                    linea = s.ReadLine();
                }
                
            }
            
        }
        return cadetes;
    }
}