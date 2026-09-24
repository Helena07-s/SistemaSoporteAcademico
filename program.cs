using System;

namespace SoporteAcademico
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;
            while (continuar)
            {
                // Requerimiento 4: Llamada a la función del menú principal
                MostrarMenu();
                Console.Write("Seleccione una opción (1-3): ");
                string opcion = Console.ReadLine();

                if (opcion == "3")
                {
                    continuar = false;
                    Console.WriteLine("Saliendo del sistema...");
                }
                else
                {
                    Console.WriteLine("\n[Opción en desarrollo...] Presione una tecla para regresar al menú.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        // Requerimiento 4: Función sin retorno dedicada exclusivamente a mostrar el menú principal
        static void MostrarMenu()
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("   SISTEMA DE ORIENTACIÓN Y SOPORTE ACADÉMICO       ");
            Console.WriteLine("====================================================");
            Console.WriteLine("1. Registrar nueva solicitud");
            Console.WriteLine("2. Mostrar resumen de atenciones");
            Console.WriteLine("3. Salir");
            Console.WriteLine("====================================================");
        }
    }
}
