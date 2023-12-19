using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Se implementa el uso de clases anidadas, esto hace que cualquier clase pública o privada solo sea conocida por CProxy.
public class CProxy
{
    //Este método no regresa nada y va a recibir como parámetro un entero q se llama pOpcion. (Es la interfaz que simula el objeto/sujeto)
    public interface ISujeto
    {
        void Peticion(int pOpcion);
    }

    //La clase ProxySencillo es con la que vamos a estar trabajando, la que va a hacer de intermediario entre el cliente
    //y la clase CCocina que es el objeto/sujeto con el que queremos interactuar, pero solo lo podremos hacer a través del Proxy.
    public class ProxySencillo : ISujeto
    {
        //Variable de referencia privada de tipo CCocina.
        private CCocina cocina;

        //Este método es la implementación de la interfaz ISujeto
        //pOpción nos va a servir para invocar uno u otro método que tengamos en CCocina.
        public void Peticion (int pOpcion)
        {
            //Si cocina es = null, es decir si nuestra variable de rederencia de cocina no ha sido asignada todavia, simplemente
            //mandamos un mensaje que dice activando sujeto y creamos la instancia del sujeto.
            if (cocina == null)
            {
                Console.WriteLine("Colocando receta");
                cocina = new CCocina();
            }
            //Si la pOpcion es = 1, invocamos el método RecetaSecreta() de CCocina, si la pOpcion es = 2, invocamos el
            //método de Cocinar() de CCocina colocando un 5 de referencia de que estamos cocinando 5 cangreburgers.
            if (pOpcion == 1)
            {cocina.RecetaSecreta();}
            if (pOpcion == 2)
            {cocina.Cocinar(5);}
        }
    }

    //La clase ProxySeguro que también está anidada, tenemos un acceso público que también está implementada a la interfaz ISujeto
    public class ProxySeguro : ISujeto
    {
        private CCocina cocina;

        public void Peticion(int pOpcion)
        {
            //Tenemos una contraseña para verificar si el cliente tiene acceso al sujeto CCocina y este a través del Proxy pueda
            //interactuar con el.
            string password = "";

            Console.WriteLine("Ingrese la contraseña: ");
            password = Console.ReadLine();

            //Se verifica si la contraseña ingresada es correcta.
            if (password == "1234")
            {
                if (cocina == null)
                {
                    Console.WriteLine("Accediendo...");
                    cocina = new CCocina();
                }
                if (pOpcion == 1)
                    {cocina.RecetaSecreta();}
                if (pOpcion == 2)
                    {cocina.Cocinar(5);}
            }
            //Si la contraseña ingresada es incorrecta se ejecuta el siguiente mensaje.
            else
            {
                Console.WriteLine("No plankton, ríndete");
            }
        }
    }

    //Esta es la clase que estamos protegiendo con el Proxy, 
    private class CCocina
    {
        public void RecetaSecreta()
        {
            Console.WriteLine("Pan");
            Console.WriteLine("Aceite de oliva");
            Console.WriteLine("Especias");
            Console.WriteLine("Jamón");
            Console.WriteLine("Queso");
        }
        public void Cocinar(int n)
        {
            Console.WriteLine("Cocinando {0} Cangreburgers", n);
        }
    }
}