using System;
using System.IO;

public static class Program
{
    struct alumno_t
    {
        public string nombre;
        public int matricula;
        public string carrera;
        public int semestre;
        public char grupo;
        public double promedio;
    }

    static void Main(string[] args)
    {
        alumno_t[] alumno = new alumno_t[2];
        
        Console.Clear();
        Console.WriteLine("Este programa guarda los datos de dos estudiantes en un archivo secuencial");
        Console.WriteLine("Ingrese los datos de dos estudiantes\n");

        for (int i = 0; i < alumno.Count(); i++)
        {
            Console.Write("Ingrese el nombre completo del alumno: ");
            alumno[i].nombre = Console.ReadLine();
            Console.Write("Ingrese el número de control del alumno: ");
            alumno[i].matricula = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese la carrera del alumno: ");
            alumno[i].carrera = Console.ReadLine();
            Console.Write("Ingrese el semestre del alumno: ");
            alumno[i].semestre = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el grupo del alumno: ");
            alumno[i].grupo = Console.ReadLine()[0];
            Console.Write("Ingrese el promedio del alumno: ");
            alumno[i].promedio = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
        }

        Console.WriteLine("Datos del Alumno");
        Console.WriteLine("----------------");
        
        for (var i = 0; i < alumno.Count(); i++)
        {
            Console.WriteLine($"{alumno[i].nombre}");
            Console.WriteLine($"{alumno[i].matricula}");
            Console.WriteLine($"{alumno[i].carrera}");
            Console.WriteLine($"{alumno[i].semestre}");
            Console.WriteLine($"{alumno[i].grupo}");
            Console.WriteLine($"{alumno[i].promedio}");
            Console.WriteLine("----------------");
        }
        
        try
        {
            FileStream fileStream = new FileStream("Alumnos.csv", FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            streamWriter.WriteLine("nombre" + "," + "matricula" + "," + "carrera" + "," + "semestre" + "," + "grupo" + "," + "promedio");

            for (var i = 0; i < alumno.Count(); i++)
            {
                streamWriter.Write(alumno[i].nombre + ",");
                streamWriter.Write(alumno[i].matricula + "," );
                streamWriter.Write(alumno[i].carrera + ",");
                streamWriter.Write(alumno[i].semestre + ",");
                streamWriter.Write(alumno[i].grupo + ",");
                streamWriter.Write(alumno[i].promedio);
                streamWriter.WriteLine();
            }

            streamWriter.Close();
            fileStream.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error: {ex.Message}");
        }
        
        Console.WriteLine();
        Console.WriteLine("Guardando los datos... \nPresione una tecla para terminar");
        Console.ReadKey();
    }
}

