
using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        CultureInfo cultura = new CultureInfo("es-ES");

        Console.Write("Introduce tu nombre completo: ");
        string nombreCompleto = Console.ReadLine();

        int espacio = nombreCompleto.IndexOf(" ");
        string primerNombre = espacio > 0 ? nombreCompleto.Substring(0, espacio) : nombreCompleto;

        DateTime fechaNacimiento;
        Console.Write("Fecha de nacimiento (dd/MM/yyyy): ");
        string entradaFecha = Console.ReadLine();

        while (!DateTime.TryParseExact(entradaFecha, "dd/MM/yyyy", cultura, DateTimeStyles.None, out fechaNacimiento)
               || fechaNacimiento > DateTime.Today)
        {
            Console.WriteLine("Fecha no válida o en el futuro. Inténtalo de nuevo.");
            Console.Write("Fecha de nacimiento (dd/MM/yyyy): ");
            entradaFecha = Console.ReadLine();
        }
        DateTime hoy = DateTime.Today;
        int edad = hoy.Year - fechaNacimiento.Year;
        if (fechaNacimiento > hoy.AddYears(-edad))
            edad--;
        string signo = ObtenerSignoZodiaco(fechaNacimiento);

        DateTime proximoCumple = new DateTime(hoy.Year, fechaNacimiento.Month, fechaNacimiento.Day);
        if (proximoCumple < hoy)
            proximoCumple = proximoCumple.AddYears(1);

        int diasFaltan = (proximoCumple - hoy).Days;

        Console.WriteLine();
        Console.WriteLine($"Hola, {primerNombre}!");
        Console.WriteLine($"Tienes {edad} años.");
        Console.WriteLine($"Tu cumpleaños es el {fechaNacimiento.ToString("dddd, dd 'de' MMMM 'de' yyyy", cultura)}.");
        Console.WriteLine($"Tu signo del zodiaco es {signo}.");

        if (diasFaltan == 0)
            Console.WriteLine("Hoy es tu cumpleaños");
        else
            Console.WriteLine($"Faltan {diasFaltan} días para tu próximo cumpleaños.");

        Console.WriteLine();
        Console.WriteLine("Pulsa cualquier tecla para salir...");
        Console.ReadKey();
    }

    static string ObtenerSignoZodiaco(DateTime fecha)
    {
        int dia = fecha.Day;
        int mes = fecha.Month;

        return mes switch
        {
            1 => (dia <= 20) ? "Capricornio" : "Acuario",
            2 => (dia <= 19) ? "Acuario" : "Piscis",
            3 => (dia <= 20) ? "Piscis" : "Aries",
            4 => (dia <= 20) ? "Aries" : "Tauro",
            5 => (dia <= 21) ? "Tauro" : "Géminis",
            6 => (dia <= 21) ? "Géminis" : "Cáncer",
            7 => (dia <= 22) ? "Cáncer" : "Leo",
            8 => (dia <= 23) ? "Leo" : "Virgo",
            9 => (dia <= 23) ? "Virgo" : "Libra",
            10 => (dia <= 23) ? "Libra" : "Escorpio",
            11 => (dia <= 22) ? "Escorpio" : "Sagitario",
            12 => (dia <= 21) ? "Sagitario" : "Capricornio",
            _ => "Desconocido"
        };
    }
}








