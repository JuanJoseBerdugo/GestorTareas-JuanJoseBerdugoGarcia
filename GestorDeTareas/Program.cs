using System;
using System.Collections.Generic;

namespace GestorDeTareas
{
    class Program
    {
        static List<Tarea> listaTareas = new List<Tarea>();

        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n--- GESTOR DE TAREAS ---");
                Console.WriteLine("1. Agregar una nueva tarea");
                Console.WriteLine("2. Mostrar tareas actuales");
                Console.WriteLine("3. Completar tareas");
                Console.WriteLine("4. Borrar tareas");
                Console.WriteLine("5. Salir");
                Console.Write("Elige una opcion: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CrearTarea();
                        break;
                    case "2":
                        MostrarTareas();
                        break;
                    case "3":
                        CompletarTarea();
                        break;
                    case "4":
                        EliminarTarea();
                        break;
                    case "5":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
            }
        }

        static void CrearTarea()
        {
            Console.Write("Descripcion de la tarea: ");
            string texto = Console.ReadLine();

            Console.Write("coloque la fecha de la tarea en formato dia-mes-año ?: ");
            string entrada = Console.ReadLine();
            DateTime? fecha = null;

            if (DateTime.TryParse(entrada, out DateTime fechaParsed))
            {
                fecha = fechaParsed;
            }

            listaTareas.Add(new Tarea(texto, fecha));
            Console.WriteLine("Tarea guardada");
        }

        static void MostrarTareas()
        {
            if (listaTareas.Count == 0)
            {
                Console.WriteLine("No hay tareas registradas aun");
                return;
            }

            for (int i = 0; i < listaTareas.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {listaTareas[i]}");
            }
        }

        static void CompletarTarea()
        {
            MostrarTareas();
            Console.Write("Cual es el numero de la tarea que completo ?: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int pos) && pos >= 1 && pos <= listaTareas.Count)
            {
                listaTareas[pos - 1].MarcarComoCompletada();
                Console.WriteLine("La tarea se ha actualizado.");
            }
            else
            {
                Console.WriteLine("Indice invalido.");
            }
        }

        static void EliminarTarea()
        {
            MostrarTareas();
            Console.Write("Numero de tarea a eliminar: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int index) && index >= 1 && index <= listaTareas.Count)
            {
                listaTareas.RemoveAt(index - 1);
                Console.WriteLine("Tarea eliminada con exito.");
            }
            else
            {
                Console.WriteLine("Indice invalido.");
            }
        }
    }
}
