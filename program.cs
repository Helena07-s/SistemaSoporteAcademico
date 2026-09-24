using System;

namespace SoporteAcademico
{
    struct Solicitud
    {
        public string CodigoEstudiante;
        public string Nombre;
        public string TipoConsulta;
        public string Descripcion;
        public string Prioridad;
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;
            
            // REQUERIMIENTO 10: Estructura de almacenamiento para un mínimo de 3 registros
            Solicitud[] registroSolicitudes = new Solicitud;
            int contadorSolicitudes = 0;

            while (continuar)
            {
                MostrarMenu();
                Console.Write("Seleccione una opción (1-3): ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        // REQUERIMIENTO 10: Control para permitir el registro de las 3 solicitudes necesarias
                        if (contadorSolicitudes < 3)
                        {
                            Console.WriteLine($"\n--- REGISTRO DE LA SOLICITUD {contadorSolicitudes + 1} ---");
                            
                            Solicitud nuevaSolicitud = new Solicitud();

                            nuevaSolicitud.CodigoEstudiante = ValidarCodigo("Ingrese el código del estudiante (mínimo 8 caracteres): ", 8);
                            nuevaSolicitud.Nombre = ValidarTextoObligatorio("Ingrese el nombre del estudiante: ");
                            nuevaSolicitud.TipoConsulta = ValidarTipoConsulta();
                            nuevaSolicitud.Descripcion = ValidarTextoObligatorio("Ingrese una breve descripción: ");
                            nuevaSolicitud.Prioridad = CalcularPrioridad(nuevaSolicitud.TipoConsulta);
                            
                            // Guardamos la solicitud en el índice correspondiente del arreglo
                            registroSolicitudes[contadorSolicitudes] = nuevaSolicitud;
                            contadorSolicitudes++;

                            Console.WriteLine($"\n[✓] Solicitud {contadorSolicitudes} registrada con éxito.");
                        }
                        else
                        {
                            Console.WriteLine("\n[!] Ya se ha alcanzado el límite máximo de 3 solicitudes.");
                        }
                        break;

                    case "2":
                        // REQUERIMIENTO 10: Uso de la función del resumen adaptada para iterar el arreglo
                        MostrarResumenAtenciones(registroSolicitudes, contadorSolicitudes);
                        break;

                    case "3":
                        continuar = false;
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }

                if (opcion != "3")
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("   SISTEMA DE ORIENTACIÓN Y SOPORTE ACADÉMICO       ");
            Console.WriteLine("====================================================");
            Console.WriteLine("1. Registrar nueva solicitud (Mínimo 3)");
            Console.WriteLine("2. Mostrar resumen de atenciones");
            Console.WriteLine("3. Salir");
            Console.WriteLine("====================================================");
        }

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

        static string ValidarCodigo(string mensaje, int longitudMinima)
        {
            string codigo;
            do
            {
                codigo = ValidarTextoObligatorio(mensaje);
                if (codigo.Length < longitudMinima)
                {
                    Console.WriteLine($"[Error] El código debe tener al menos {longitudMinima} caracteres.");
                }
            } while (codigo.Length < longitudMinima);

            return codigo;
        }

        static string ValidarTipoConsulta()
        {
            string consulta = "";
            bool esValido = false;

            while (!esValido)
            {
                Console.WriteLine("\nTipos de consulta permitidos: [matricula, pagos, constancia, plataforma, otro]");
                consulta = ValidarTextoObligatorio("Ingrese el tipo de consulta: ").ToLower();

                if (consulta == "matricula" || consulta == "pagos" || consulta == "constancia" || consulta == "plataforma" || consulta == "otro")
                {
                    esValido = true;
                }
                else
                {
                    Console.WriteLine("[Error] Categoría no válida. Debe escribir exactamente una opción de la lista.");
                }
            }
            return consulta;
        }

        static string CalcularPrioridad(string tipo)
        {
            if (tipo == "plataforma" || tipo == "pagos")
            {
                return "alta";
            }
            else if (tipo == "matricula")
            {
                return "media";
            }
            else
            {
                return "baja";
            }
        }

        // REQUERIMIENTO 10: Función modificada para recibir el arreglo entero e imprimir todas las solicitudes creadas
        static void MostrarResumenAtenciones(Solicitud[] solicitudes, int cantidad)
        {
            Console.WriteLine("\n====================================================");
            Console.WriteLine("               RESUMEN DE ATENCIONES                ");
            Console.WriteLine("====================================================");
            
            if (cantidad == 0)
            {
                Console.WriteLine("No se han encontrado solicitudes registradas.");
                Console.WriteLine("====================================================");
                return;
            }

            // Un bucle recorre el arreglo imprimiendo cada una de las consultas guardadas
            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"Registro N°: {i + 1}");
                Console.WriteLine($"Código Est. : {solicitudes[i].CodigoEstudiante}");
                Console.WriteLine($"Nombre      : {solicitudes[i].Nombre}");
                Console.WriteLine($"Consulta    : {solicitudes[i].TipoConsulta.ToUpper()}");
                Console.WriteLine($"Descripción : {solicitudes[i].Descripcion}");
                Console.WriteLine($"Prioridad   : {solicitudes[i].Prioridad.ToUpper()}");
                Console.WriteLine("----------------------------------------------------");
            }
        }
    }
}
