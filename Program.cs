using System;
using static System.Net.Mime.MediaTypeNames;

namespace ExamenPractico1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool bandera = true;
            double clave, costo_llamada, costo_minuto, tiempo_minuto;
            int opcion = 0;
            int x;
            int codigo_libro, isbn, edicion;
            string titulo, autor, buscarLibro;
            string[] guardadoLibro;

            List<string[]> libros = new List<string[]>();
            while (bandera)
            {
                Console.WriteLine("Menu de opciones");
                Console.WriteLine("\n" +
                    "\n 1.- Calcular costo de llamadas telefonicas internacionales." +
                    "\n 2.- Agregar un libro." +
                    "\n 3.- Mostrar listado de libros." +
                    "\n 4.- Buscar libro por codigo." +
                    "\n 5.- Editar la informacion de un libro buscado por código." +
                    "\n 6.- Salir del programa. \n");
                Console.WriteLine("Digite una opción :");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    //Ejercicio 1
                    case 1:
                        Console.WriteLine("Ingresar el valor de clave de la zona: ");
                        clave = double.Parse(Console.ReadLine());
                        Console.Write("Ingresar el valor del tiempo de la llamada en minutos: ");
                        tiempo_minuto = double.Parse(Console.ReadLine());
                        costo_minuto = 0;
                        if (clave == 12)
                        {
                            Console.WriteLine("América del Norte");
                            costo_minuto = 2;
                        }
                        else if (clave == 15)
                        {
                            Console.WriteLine("América Central");
                            costo_minuto = 2.2;
                        }
                        else if (clave == 18)
                        {
                            Console.WriteLine("América del Sur");
                            costo_minuto = 4.5;
                        }
                        else if (clave == 19)
                        {
                            Console.WriteLine("Europa");
                            costo_minuto = 3.5;
                        }
                        else if (clave == 23)
                        {
                            Console.WriteLine("Asia");
                            costo_minuto = 6;
                        }
                        else
                        {
                            Console.WriteLine("Digite un clave de zona valida.");
                            Console.ReadKey(); Console.Clear();
                            break;
                        }
                        costo_llamada = tiempo_minuto * costo_minuto;
                        Console.WriteLine("El costo de la llamada es: " + '$' + costo_llamada);
                        Console.WriteLine("El costo por minuto es: " + '$' + costo_minuto);
                        Console.WriteLine();
                        Console.WriteLine("Presione una tecla para regresar al menu principal...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        //Ejercicio 2, Agregar
                        Console.WriteLine("Ingrese el titulo del libro: ");
                        titulo = Console.ReadLine();
                        Console.WriteLine("Ingrese el ISBN del libro: ");
                        isbn = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese la edicion del libro: ");
                        edicion = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese el autor del libro: ");
                        autor = Console.ReadLine();

                        if (titulo == "" || isbn == 0 || edicion == 0 || autor == "")
                        {
                            Console.WriteLine("Los campos son obligatorios.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            guardadoLibro = new string[4];

                            guardadoLibro[0] = titulo;
                            guardadoLibro[1] = Convert.ToString(isbn);
                            guardadoLibro[2] = Convert.ToString(edicion);
                            guardadoLibro[3] = autor;

                            libros.Add(guardadoLibro);
                            Console.Clear();
                        }
                        break;

                    case 3:
                        // Mostrar
                        Console.WriteLine("*****Listado de Libros Almacenados en el Sistema*****");
                        for (int i = 0; i < libros.Count; i++)
                        {
                            Console.WriteLine("|Código del libro: " + i + "|Titulo: " + libros[i][0] + "|ISBN: " + libros[i][1] + "|Edición: " + libros[i][2] + "|Autor: " + libros[i][3] + "|");
                        }
                        break;

                    case 4:
                        //Buscar
                        Console.Clear();
                        Console.WriteLine("Ingrese el codigo del libro que quiera buscar: ");
                        buscarLibro = Console.ReadLine();
                        foreach (string[] item in libros)
                        {
                            if (int.TryParse(buscarLibro, out x))
                            {

                                int posicionLibro = int.Parse(buscarLibro);
                                if (libros.Count <= posicionLibro)
                                {
                                    Console.WriteLine("El libro no existe.");
                                }
                                else
                                {
                                    Console.WriteLine("Libro " + buscarLibro + " encontrado.");
                                    Console.WriteLine("|Código del libro: " + libros.Count + "|Titulo: " + item[0] + "|ISBN: " + item[1] + "|Edición: " + item[2] + "|Autor: " + item[3] + "|");
                                }
                            }
                        }
                        break;

                    case 5:
                        //Editar
                        Console.Clear();
                        Console.WriteLine("*****Listado de Libros Almacenados en el Sistema*****");

                        for (int i = 0; i<libros.Count; i++)
                        {
                            Console.WriteLine("|Código del libro: " + i + "|Titulo: " + libros[i][0] + "|ISBN: " + libros[i][1] + "|Edición: " + libros[i][2] + "|Autor: " + libros[i][3] + "|");
                        }

                    Console.WriteLine("Ingrese el codigo del libro que desea modificar: ");
                        buscarLibro = Console.ReadLine();
                        if (int.TryParse(buscarLibro, out x))
                        {
                            int posicionLibro = int.Parse(buscarLibro);
                            if (libros.Count <= posicionLibro || posicionLibro < 0)
                            {
                                Console.WriteLine("La persona no existe.");
                            }
                            else
                            {
                                Console.WriteLine("Ingrese el nuevo titulo del libro: ");
                                titulo = Console.ReadLine();
                                Console.WriteLine("Ingrese el nuevo ISBN del libro: ");
                                isbn = int.Parse(Console.ReadLine());
                                Console.WriteLine("Ingrese la nueva edicion del libro: ");
                                edicion = int.Parse(Console.ReadLine());
                                Console.WriteLine("Ingrese el nuevo autor del libro: ");
                                autor = Console.ReadLine();

                                if (titulo == "" || isbn == 0 || edicion == 0 || autor == "")
                                {
                                    Console.WriteLine("Los campos son obligatorios.");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                else
                                {
                                    libros[posicionLibro][0] = titulo;
                                    libros[posicionLibro][1] = Convert.ToString(isbn);
                                    libros[posicionLibro][2] = Convert.ToString(edicion);
                                    libros[posicionLibro][3] = autor;

                                    Console.WriteLine("Libro actualizado exitosamente.");
                                }
                            }
                        }
                        
                        break;

                    case 6:
                        Console.Clear();
                        Console.WriteLine("Cerrando aplicacion...");
                        bandera = false;
                        break;
                    default:
                        Console.WriteLine("Eliga una opcion de menu existente.");
                        break;
                }
            }
        }
    }
}