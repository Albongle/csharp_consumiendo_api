namespace test_csharp;
public class Usuario
{
    public string? Email { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public int? Edad { get; set; }
}


public class Emisor : Usuario
{

}

public class Receptor : Usuario
{

}