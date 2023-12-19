public class Program
{
    static void Main (string[] args)
    {
        CProxy.ISujeto miProxy = new CProxy.ProxySencillo();

        //No podemos acceder a la clase
        //CProxy.CCocina

        // miProxy.Peticion(1);
        // Console.WriteLine("----------");
        // miProxy.Peticion(2);
        // Console.WriteLine("----------");

        CProxy.ISujeto miProxyS = new CProxy.ProxySeguro();

        miProxyS.Peticion(1);
        Console.WriteLine("----------");
        miProxyS.Peticion(2);
        Console.WriteLine("----------");
    }
}