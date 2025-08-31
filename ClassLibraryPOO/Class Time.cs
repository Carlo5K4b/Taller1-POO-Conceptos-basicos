namespace ClassLibraryPOO
{
    // Taller#1 POO
    using System;
    using System.ComponentModel;
    using System.Security.Cryptography.X509Certificates;

    public class MyTime
    {
        private int hours;
        private int minutes;
        private int seconds;
        private int milliseconds;

        //Constructor (#1) sin parámetros
        public MyTime(int hours, int minutes, int seconds, int milliseconds)
        {

            if (!IsValidTime(hours, minutes, seconds, milliseconds))
            {
                throw new ArgumentException($" The hour: {hours}, is not valid.");
            }

            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            this.milliseconds = milliseconds;
        }

        // Método validar (si) la hora es válida
        private bool IsValidTime(int hours, int minutes, int seconds, int milliseconds)
        {
            return hours >= 0 && hours < 24 &&
                   minutes >= 0 && minutes < 60 &&
                   seconds >= 0 && seconds < 60 &&
                   milliseconds >= 0 && milliseconds < 1000;
        }

        // Método ToMilliseconds
        public long ToMilliseconds()
        {
            return (long)hours * 3600000 + minutes * 60000 + seconds * 1000 + milliseconds;
        }

        // Método ToSeconds|
        public long ToSeconds()
        {
            return ToMilliseconds() / 1000;
        }

        // Método ToMinutes
        public long ToMinutes()
        {
            return ToMilliseconds() / 60000;
        }

        // Método Add
        public MyTime Add(MyTime other, out bool isOtherDay)
        {
            long totalMs = this.ToMilliseconds() + other.ToMilliseconds();
            long msInDay = 24 * 3600000; // Milisegundos en un día

            // Determinar si pasa a otro día
            isOtherDay = totalMs >= msInDay;

            // Calcular el tiempo normalizado (siempre entre 0-23 horas)
            long remainingMs = totalMs % msInDay;

            int newHours = (int)(remainingMs / 3600000);
            remainingMs %= 3600000;

            int newMinutes = (int)(remainingMs / 60000);
            remainingMs %= 60000;

            int newSeconds = (int)(remainingMs / 1000);
            int newMilliseconds = (int)(remainingMs % 1000);

            // Ahora newHours siempre estará entre 0-23
            return new MyTime(newHours, newMinutes, newSeconds, newMilliseconds);
        }

        // Método para mostrar la hora
        public override string ToString()
        {
            //Caso especial: 00:00:00.000 noche
            if (hours == 0 && minutes == 0 && seconds == 0 && milliseconds ==0 )
            {
                return $"00:00:00.000 A.M.";
            }

            var dateTime = new DateTime(1, 1, 1, hours, minutes, seconds, milliseconds);
            return dateTime.ToString("hh:mm:ss.fff tt").ToUpper();

        }
    }
}

