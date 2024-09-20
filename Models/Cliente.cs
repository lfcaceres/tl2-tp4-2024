public class Cliente
{
    private string Nombre;
    private string Direccion;
    private string Telefono;
    private string DatosRefDir;

    public Cliente(string nomb, string dir, string tel, string dat)
    {
        Nombre=nomb;
        Direccion=dir;
        Telefono=tel;
        DatosRefDir=dat;
    }

    public string? GetNombre{get => Nombre; }
    public string? GetDireccion {get => Direccion;}
    public string? GetTelefono {get => Telefono;}
}