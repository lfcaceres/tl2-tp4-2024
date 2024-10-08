using System.Text.Json;
using System.Text.Json.Serialization;

namespace MiAplicacion;
public class AccesoDatosCadeteria
{
    public bool ExisteArchivo(string ruta)
    {
        FileInfo f = new FileInfo(ruta);
        if (f.Exists && f.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public Cadeteria Obtener(string ruta)
    {
        Cadeteria cadeteriaSinInfo = new Cadeteria();
        if (ExisteArchivo(ruta))
        {
            string[] datosCadeteria;
            using (StreamReader s = new StreamReader(ruta))
            {
                datosCadeteria = s.ReadLine().Split(',');
            }
            Cadeteria cadeteriaConInfo = new Cadeteria(datosCadeteria[0], datosCadeteria[1]);
            return cadeteriaConInfo;
        }
        else
        {
            return cadeteriaSinInfo;
        }
    }
}