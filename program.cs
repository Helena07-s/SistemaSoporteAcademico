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
            
            // Creamos la variable local que guardará los datos de la última solicitud
            Solicitud nuevaSolicitud = new Solicitud();
            bool hayRegistro = false;

            while (continuar)
            {
                MostrarMenu();
                Console.Write("Seleccione una opción (1-3): ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("\n--- REGISTRO DE NUEVA SOLICITUD ---");
                        
                        nuevaSolicitud.CodigoEstudiante = ValidarCodigo("Ingrese el código del estudiante (mínimo 8 caracteres): ", 8);
                        nuevaSolicitud.Nombre = ValidarTextoObligatorio("Ingrese el nombre del estudiante: ");
                        nuevaSolicitud.TipoConsulta = ValidarTipoConsulta();
                        nuevaSolicitud.Descripcion = ValidarTextoObligatorio("Ingrese una breve descripción: ");
                        
                        // REQUERIMIENTO 8: Se pasa 'nuevaSolicitud.TipoConsulta' por parámetro explícito
                        nuevaSolicitud.Prioridad = CalcularPrioridad(nuevaSolicitud.TipoConsulta);
                        hayRegistro = true;
                        
                        Console.WriteLine($"\n[✓] Solicitud registrada de prioridad: {nuevaSolicitud.Prioridad.ToUpper()}");
                        break;

                    case "2":
                        if (hayRegistro)
                        {
                            // REQUERIMIENTO 8: Traspaso de información explícita pasando el objeto por argumento
                            MostrarResumenAtenciones(nuevaSolicitud);
                        }
                        else
                        {
                            Console.WriteLine("\n[!] No hay ninguna solicitud registrada todavía.");
                        }
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
            Console.WriteLine("1. Registrar nueva solicitud");
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

        static void ShowAlert(string msg) { Console.WriteLine(msg); }

        // REQUERIMIENTO 8: Definición de parámetros para recibir los datos de forma aislada
        static void MostrarResumenAtenciones(Solicitud solicitud)
        {
            Console.WriteLine("\n====================================================");
            Console.WriteLine("               DETALLE DE LA SOLICITUD              ");
            Console.WriteLine("====================================================");
            Console.WriteLine($"Código Est. : {solicitud.CodigoEstudiante}");
            Console.WriteLine($"Nombre      : {solicitud.Nombre}");
            Console.WriteLine($"Consulta    : {solicitud.TipoConsulta.ToUpper()}");
            Console.WriteLine($"Descripción : {solicitud.Descripcion}");
            Console.WriteLine($"Prioridad   : {solicitud.Prioridad.ToUpper()}");
            Console.WriteLine("====================================================");
        }
    }
}
