namespace ClassLibraryPOO
{
    // Taller#1 POO
    using System;
    using System.ComponentModel;
    using System.Security.Cryptography.X509Certificates;

    public class Time
    {
        private int hours;
        private int minutes;
        private int seconds;
        private int milliseconds;

        //Constructor (#1) sin parámetros
        public Time(int hours, int minutes, int seconds, int milliseconds)
        {

            if (!IsValidTime(hours, minutes, seconds, milliseconds))
            {
                throw new ArgumentException($"The hour: {hours}, is not valid.");
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
        public Time Add(Time other, out bool isOtherDay)
        {
            long totalMs = this.ToMilliseconds() + other.ToMilliseconds();

            // Un día en milisegundos
            long msInDay = 24 * 3600000;

            isOtherDay = totalMs >= msInDay;
            totalMs %= msInDay;

            int newHours = (int)(totalMs / 3600000);
            totalMs %= 3600000;

            int newMinutes = (int)(totalMs / 60000);
            totalMs %= 60000;

            int newSeconds = (int)(totalMs / 1000);
            int newMilliseconds = (int)(totalMs % 1000);

            return new Time(newHours, newMinutes, newSeconds, newMilliseconds);
        }

        // Método para mostrar la hora en formato "HH:MM:SS.mmm"
        public override string ToString()
        {
            return $"{hours:D2}:{minutes:D2}:{seconds:D2}.{milliseconds:D3}";
        }
    }
}
