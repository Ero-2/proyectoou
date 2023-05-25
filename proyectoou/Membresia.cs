using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoou
{
    public class Membresia
    {
        public int Saldo { get; protected set; }

        public DateTime FechaInicio { get; set; }

        public virtual TimeSpan TiempoRestante()
        {
            // Cálculo del tiempo restante basado en la fecha de inicio y el período de la membresía
            return TimeSpan.Zero; // Implementa el cálculo real en las clases derivadas
        }

        public DateTime FechaFin()
        {
            // Lógica para calcular la fecha de finalización según la duración de la membresía
            // Ejemplo para MembresiaSemana:
            return FechaInicio.AddDays(7); // La membresía de una semana dura 7 días
        }

    }
    public class MembresiaSemana : Membresia
    {
        public MembresiaSemana()
        {
            Saldo = 100;
        }

        public override TimeSpan TiempoRestante()
        {
            DateTime fechaVencimiento = FechaInicio.AddDays(7); // La membresía dura una semana
            TimeSpan tiempoRestante = fechaVencimiento - DateTime.Now;
            return tiempoRestante;
        }

    }


    public class MembresiaMes : Membresia
    {
        public MembresiaMes()
        {
            Saldo = 300;
        }
        public override TimeSpan TiempoRestante()
        {
            DateTime fechaVencimiento = FechaInicio.AddMonths(1); // La membresía dura un mes
            TimeSpan tiempoRestante = fechaVencimiento - DateTime.Now;
            return tiempoRestante;
        }


    }

    public class Membresiaño : Membresia
    {
        public Membresiaño()
        {
            Saldo = 3200;
        }
        public override TimeSpan TiempoRestante()
        {
            DateTime fechaVencimiento = FechaInicio.AddYears(1); // La membresía dura un año
            TimeSpan tiempoRestante = fechaVencimiento - DateTime.Now;
            return tiempoRestante;
        }

    }

   
} 
