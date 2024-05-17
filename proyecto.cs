using System;
using System.Collections.Generic;
using static Practicando;

public class Practicando
{
    public struct Empleado
    {
        public string Dni;
        public string Nombre;
        public string Apellido;
        public string Localidad;
        public string CantidadHijos;
        public string SueldoBasico;
    }
    private static int MostrarMenu()
    {
        Console.WriteLine("====================");
        Console.WriteLine("1- Agregar empleado");
        Console.WriteLine("2- Listar por cantidad de hijos");
        Console.WriteLine("3- Listar por localidad y cantidad de hijos");
        Console.WriteLine("4- Incrementar el sueldo con un porcentaje");
        Console.WriteLine("5- Mostrar empleados ordenados por nombre");
        Console.WriteLine("6- Eliminar un empleado");
        Console.WriteLine("7- Modificar un empleado en particular");
        Console.WriteLine("0- Salir");
        Console.WriteLine("====================");
        Console.Write("Ingrese una opción: ");
        int opcion = Int32.Parse(Console.ReadLine());
        return opcion;
    }
    private static void IngresarEmpleados(List<Empleado> empleados)
    {
        int opcion;
        Console.Write("¿Desea agregar empleados? (1-Sí || 2-No): ");
        opcion = Int32.Parse(Console.ReadLine());

        while (opcion != 2)
        {
            Console.Clear();
            Console.WriteLine("Ingrese los datos del empleado");

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            if (nombre == "")
            {
                Console.WriteLine("Debes ingresar un nombre");
                Console.Write("Nombre: ");
                nombre = Console.ReadLine();
            }
            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();

            if (apellido == "")
            {
                Console.WriteLine("Debes ingresar un apellido");
                Console.Write("Apellido: ");
                apellido = Console.ReadLine();
            }

            Console.Write("Dni: ");
            string dni = Console.ReadLine();

            if (dni == "" || Convert.ToInt64(dni) < 0)
            {
                Console.WriteLine("Reingresa un dni valido ");
                Console.Write("Dni: ");
                dni = (Console.ReadLine());
            }
            Console.Write("Localidad: ");
            string localidad = Console.ReadLine();

            if (localidad == "")
            {
                Console.WriteLine("Debes ingresar un nombre");
                Console.Write("Localidad: ");
                localidad = Console.ReadLine();
            }
            Console.Write("Cantidad de hijos: ");
            string cantidadHijos = (Console.ReadLine());

            if (cantidadHijos == "" || Convert.ToInt64(cantidadHijos) < 0)
            {
                Console.WriteLine("No puede tener menos de 0 hijos");
                Console.Write("¿Cuantos hijos tenes?: ");
                cantidadHijos = (Console.ReadLine());
            }
            Console.Write("Sueldo básico: ");
            string sueldoBasico = Console.ReadLine();

            if (Convert.ToDouble(sueldoBasico) < 0 || sueldoBasico == "")
            {
                Console.WriteLine("No podes tener un sueldo basico inferior a $0");
                Console.Write("¿Cual es tu sueldo basico?: ");
                sueldoBasico = (Console.ReadLine());
            }
            empleados.Add(new Empleado
            {
                Dni = dni,
                Nombre = nombre,
                Apellido = apellido,
                Localidad = localidad,
                CantidadHijos = cantidadHijos,
                SueldoBasico = sueldoBasico
            });

            Console.Clear();
            Console.ReadKey();
            Console.Write("¿Desea continuar agregando empleados? (1-Sí || 2-No): ");
            opcion = Int32.Parse(Console.ReadLine());

            Console.Clear();
            Console.ReadKey();
        }
    }
    private static void ListarPorCantidadHijos(List<Empleado> empleados)
    {
        int contador_total = 0,contador_hijos=0;
        Console.WriteLine("Empleados con más de 2 hijos:");
        foreach (Empleado empleado in empleados)
        {
            if (Convert.ToInt16(empleado.CantidadHijos) > 2)
            {
                Console.WriteLine($"{empleado.Apellido}, {empleado.Nombre} tiene : {empleado.CantidadHijos} hijos");
                contador_hijos++;
            }
            contador_total++;
        }
        Console.WriteLine($"Se encontraron {contador_total} empleados/as en total pero solo {contador_hijos} empleados/as tiene mas de 2 hijos");
    }
    private static void ListadoPorLocalidad(List<Empleado> empleados)
    {
        int contador_total = 0,contador_localidad=0;
        Console.Write("Digite su localidad: ");
        string loc = Console.ReadLine();
        Console.Write("¿Cuantos hijos tenes?: ");
        int cantidad = Int32.Parse(Console.ReadLine());

        foreach (Empleado empleado in empleados)
        {
            if (empleado.Localidad == loc && Convert.ToInt16(empleado.CantidadHijos) >= cantidad)
            {
                Console.WriteLine($"El empleado {empleado.Apellido}, {empleado.Nombre} t" +
                    $"tiene {empleado.CantidadHijos} hijos y reside en {empleado.Localidad}");
                contador_localidad++;
            }
            contador_total++;
        }
        Console.WriteLine($"Se encontraron {contador_total} empleados/as en total pero solo {contador_localidad} empleados/as residen en {loc}");
    }
    private static void IncrementarSueldoBasico(List<Empleado> empleados)
    {
        double aumento, sueldo_con_aumento;
        Console.Write("Ingrese el porcentaje a incrementar: ");
        double porcentaje = double.Parse(Console.ReadLine());

        foreach (Empleado empleado in empleados)
        {
            aumento = Convert.ToDouble(empleado.SueldoBasico) * porcentaje / 100;
            sueldo_con_aumento = aumento + Convert.ToDouble(empleado.SueldoBasico);
            Console.WriteLine($"El nuevo salario con aumento es: ${sueldo_con_aumento}");
            break;
        }
    }
    public static void MostrarEmpleadosOrdenados(List<Empleado> empleados)
    {
        int contador = 0;
        empleados.Sort((emp1, emp2) => emp1.Nombre.CompareTo(emp2.Nombre));
        Console.WriteLine("Lista de empleados ordenados por nombre \n");

        foreach (var empleado in empleados)
        {
            Console.WriteLine($"Nombre: {empleado.Nombre} \nApellido: {empleado.Apellido}\n");
            contador++;
        }
        Console.WriteLine($"En total tenemos {contador} empleados");

    }
    public static void EliminarEmpleado(List<Empleado> empleados)
    {
        Console.Write("Ingrese el dni del empleado a dar de baja: ");
        string documento = Console.ReadLine();

        foreach (Empleado empleado in empleados)
        {
            if (documento == empleado.Dni)
            {
                empleados.Remove(empleado);
                Console.WriteLine($"El empleado {empleado.Apellido}, {empleado.Nombre} fue dado de baja  exitosamente ");
                break;
            }
        }
    }
    public static void ModificarEmpleado(List<Empleado> empleados)
    {
        Console.Write("¿Desea actualizar informacion (1-Si || 2-No)?: ");
        int confirmacion = Int32.Parse(Console.ReadLine());

        if (confirmacion == 1)
        {
            Console.Write("Ingrese el dni del empleado a modificar: ");
            string dni_verificar = (Console.ReadLine());

            foreach (var empleado in empleados)
            {
                if (dni_verificar == empleado.Dni)
                {
                    Console.Write($"¿Esta seguro que cambiara la informacion personal de {empleado.Apellido},{empleado.Nombre} (1-Si || 2-No)?: ");
                    int afirmacion = Int32.Parse(Console.ReadLine());

                    if (afirmacion == 1)
                    {
                        Console.Write("Reingrese su localidad: ");
                        string localidad = Console.ReadLine();

                        Console.Write("Reingrese su cantidad de hijos: ");
                        int cantidadHijos = Int32.Parse(Console.ReadLine());

                        Console.Write("Reingrese su sueldo básico: ");
                        double sueldoBasico = Double.Parse(Console.ReadLine());

                        Console.WriteLine($"El empleado {empleado.Apellido}, {empleado.Nombre} se cambio de barrio y ahora vive en  {localidad} y ahora tiene {cantidadHijos} hijos, y debido a esto cobra ${sueldoBasico}");
                    }
                }
            }
        }
        Console.ReadKey();
        Console.Clear();
    }
    public static void Main(string[] args)
    {
        List<Empleado> empleados = new List<Empleado>();
        int seleccion;

        do
        {
            seleccion = MostrarMenu();

            switch (seleccion)
            {
                case 1:
                    {
                        if (seleccion == 1)
                        {
                            DateTime fechaHoraActual = DateTime.Now;
                            Console.WriteLine("La fecha y hora actual de apertura es: " +
                            fechaHoraActual.ToString());
                            Console.ReadKey();
                            Console.Clear();
                        }
                        IngresarEmpleados(empleados);
                        break;
                    }
                case 2:
                    {
                        ListarPorCantidadHijos(empleados);
                        break;
                    }
                case 3:
                    {
                        ListadoPorLocalidad(empleados);
                        break;
                    }
                case 4:
                    {
                        IncrementarSueldoBasico(empleados);
                        break;
                    }
                case 5:
                    {
                        MostrarEmpleadosOrdenados(empleados);
                        break;
                    }
                case 6:
                    {
                        EliminarEmpleado(empleados);
                        break;
                    }
                case 7:
                    {
                        ModificarEmpleado(empleados);
                        break;
                    }
                case 0:
                    {
                        if (seleccion == 0)
                        {
                            DateTime fechaHoraActual = DateTime.Now;

                            Console.WriteLine("La fecha y hora actual del cierre es: " + fechaHoraActual.ToString());
                            Console.ReadKey();
                        }
                        Console.WriteLine("Gracias por usar nuestro sistema...");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Opción inválida");
                        break;
                    }
            }
        } while (seleccion != 0);
    }
}