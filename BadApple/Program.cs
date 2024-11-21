using BadApple;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Sistema de Visualización de Video ===");
        Console.WriteLine("Seleccione una opción:");
        Console.WriteLine("1. Mostrar Video");
        Console.WriteLine("2. Salir");

        // Crear instancia de la implementación del menú
        IMenu menu = new MenuImplementation();

        while (true)
        {
            Console.Write("Opción: ");
            string opcion = Console.ReadLine();

            if (!menu.HandleOption(opcion))
            {
                break;
            }
        }
    }
}
