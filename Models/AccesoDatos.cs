using System.Text.Json;
using System.Text.Json.Serialization;


public abstract class AccesoDatos{
    public abstract Cadeteria ObtenerCadeteria(string ruta);
    public abstract List<Cadete> ObtenerCadetes(string ruta);

    public bool ExisteArchivo(string ruta){
        FileInfo f = new FileInfo(ruta);

        if(f.Exists && f.Length > 0){
            return true;
        }else{
            return false;
        }
    }
}

public class AccesoCSV : AccesoDatos
{
    public override Cadeteria ObtenerCadeteria(string ruta)
    {
        Cadeteria cadeteriaSinInfo = new Cadeteria();

        if(ExisteArchivo(ruta))
        {
            string[] datosCadeteria;

            using (StreamReader s = new StreamReader(ruta))
            {
                datosCadeteria = s.ReadLine().Split(',');
            }

            Cadeteria cadeteriaConInfo = new Cadeteria(datosCadeteria[0], datosCadeteria[1]);
            return cadeteriaConInfo;
        } else{
            return cadeteriaSinInfo;
        }
    }

    public override List<Cadete> ObtenerCadetes(string ruta)
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

public class AccesoJSON : AccesoDatos
{
    public override Cadeteria ObtenerCadeteria(string rutaDatosCadeteria){
        string infoCadeteria = File.ReadAllText(rutaDatosCadeteria);
        Cadeteria cadeteriaConInfo = JsonSerializer.Deserialize<Cadeteria>(infoCadeteria);
        return cadeteriaConInfo;
    }

    public override List<Cadete> ObtenerCadetes(string rutaDatosCadetes){
        string infoCadetes = File.ReadAllText(rutaDatosCadetes);
        List<Cadete> cadetes = JsonSerializer.Deserialize<List<Cadete>>(infoCadetes);
        return cadetes;
    }
}

/*public static class AccesoDatos
{
    private static bool ExisteArchivo(string ruta)
    {
        FileInfo f = new FileInfo(ruta); //no necesita invocar la libreria?
        if (f.Exists && f.Length > 0)
        {
            return true;
        }else
        {
            return false;
        }
    }
    
}*/