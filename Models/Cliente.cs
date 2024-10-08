public class Cliente
{
    private string nombre;
    private string direccion;
    private string telefono;
    private string datosRefDir;

    public Cliente()
    {
    }

    public Cliente(string nomb, string dir, string tel, string dat)
    {
        Nombre=nomb;
        Direccion=dir;
        Telefono=tel;
        DatosRefDir=dat;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public string DatosRefDir { get => datosRefDir; set => datosRefDir = value; }
}