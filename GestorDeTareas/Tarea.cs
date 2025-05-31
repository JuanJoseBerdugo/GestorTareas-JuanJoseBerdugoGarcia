using System;

namespace GestorDeTareas //esta clase es una tarea individual dentro de el gestor de tareas.
{
    public class Tarea
    {
        public string Descripcion { get; set; } //aca le pido al usuario que me de una descripcion del nombre de la tarea.
        public DateTime? FechaLimite { get; set; } //aca le pregunto al usuario si quiere ponerle una fecha limite a la tarea.
        public bool Completada { get; private set; } //aca indico si la tarea esta completada o no, por defecto es false.

        public Tarea(string texto, DateTime? fecha) //aqui inicializo las propiedades de la clase Tarea.
        {
            Descripcion = texto;
            FechaLimite = fecha;
            Completada = false;
        }

        public void MarcarComoCompletada() //aqui verifico si la tarea ya fue completada o no.
        {
            Completada = true;
        }

        public override string ToString() // Esto lo uso para devolver los datos al usuario respecto a su tarea.
        {
            string estado = Completada ? "Completada" : "Pendiente";
            string fecha = FechaLimite.HasValue ? FechaLimite.Value.ToShortDateString() : "Sin fecha definida por el usuario";

            return $"{Descripcion} - {fecha} - {estado}";
        }
    }
}

