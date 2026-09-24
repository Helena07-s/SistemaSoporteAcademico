using System;

namespace SoporteAcademico
{
    // [REQ 1]: Estructura de datos para almacenar la información de las solicitudes
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
            
            // [REQ 10]: Arreglo estructurado para almacenar un mínimo de 3 registros simultáneos
            Solicitud[] registroSolicitudes = new Solicitud[3];
            int contadorSolicitudes = 0;

            while (continuar)
            {
                // [REQ 4]: Invocación de la función del menú principal
                MostrarMenu();
                Console.Write("Seleccione una opción (1-3): ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        // [REQ 10]: Estructura de control para limitar a 3 solicitudes en ejecución
                        if (contadorSolicitudes < 3)
                        {
                            Console.WriteLine($"\n--- REGISTRO DE LA SOLICITUD {contadorSolicitudes + 1} ---");
                            
                            Solicitud nuevaSolicitud = new Solicitud();

                            // [REQ 2]: Captura de código con validación de tamaño mínimo
                            nuevaSolicitud.CodigoEstudiante = ValidarCodigo("Ingrese el código del estudiante (mínimo 8 caracteres): ", 8);
                            
                            // [REQ 1]: Captura del nombre del estudiante con texto obligatorio
                            nuevaSolicitud.Nombre = ValidarTextoObligatorio("Ingrese el nombre del estudiante: ");
                            
                            // [REQ 3]: Validación del tipo de consulta permitida
                            nuevaSolicitud.TipoConsulta = ValidarTipoConsulta();
                            
                            nuevaSolicitud.Descripcion = ValidarTextoObligatorio("Ingrese una breve descripción: ");
                            
                            // [REQ 5 y REQ 8]: Cálculo automático de prioridad pasando parámetros explícitos
                            nuevaSolicitud.Prioridad = CalcularPrioridad(nuevaSolicitud.TipoConsulta);
                            
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
                        // [REQ 7 y REQ 8]: Impresión de reportes pasando parámetros estructurados
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

        // [REQ 4]: Función sin retorno dedicada exclusivamente a pintar el menú en la consola
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

        // [REQ 6]: Función modular con retorno encargada de validar que un texto no sea vacío
        // [REQ 9]: Control del alcance (scope) local de las variables internas 'mensaje' y 'entrada'
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

        // [REQ 2]: Función con retorno reutilizable para evaluar la longitud mínima del código
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

        // [REQ 3]: Función con retorno encargada de filtrar las categorías válidas de soporte
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

        // [REQ 5]: Función con retorno que evalúa el tipo de consulta para asignar prioridad automática
        // [REQ 9]: El parámetro de entrada 'tipo' restringe su contexto a este bloque lógico
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

        // [REQ 7]: Función encargada del diseño, ordenamiento e impresión formateada del resumen
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
