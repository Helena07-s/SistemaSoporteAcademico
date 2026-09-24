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

        // REQUERIMIENTO 6: Función con retorno para validar texto obligatorio (No vacío)
        // Requerimiento 9: Las variables 'mensaje' y 'entrada' tienen alcance (scope) local aquí
        static string ValidarTextoObligatorio(string mensaje)
        {
            string entrada;
            do
            {
                Console.Write(mensaje);
                entrada = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(entrada))
                {
                    Console.WriteLine("[Error] Este campo es obligatorio. No puede quedar vacío.");
                }
            } while (string.IsNullOrEmpty(entrada));

            return entrada;
        }
    }
}
