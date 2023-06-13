﻿// See https://aka.ms/new-console-template for more information
// using EspacioTarea;

// int cantidad;
// int ID = 0;
// List<string> LTarea = new List<string>();
// LTarea.Add("Lavar");
// LTarea.Add("Limpiar");
// LTarea.Add("Ordenar");
// LTarea.Add("Reponer");
// LTarea.Add("Contabilizar");

// Tarea CrearTarea() {
//     Random azar = new Random();
//     ID++;
//     Tarea T = new Tarea(ID,LTarea[azar.Next(0,5)],azar.Next(10,100));
//     return T;
// }

// Console.WriteLine("Escriba una cantidad de tareas");
// if (!(int.TryParse(Console.ReadLine(), out cantidad))) {
//     cantidad = 0;
// }

// List<Tarea> Pendientes = new List<Tarea>();

// for (int i = 0;i < cantidad;i++) {
//     Pendientes.Add(CrearTarea());
// }

// List<Tarea> Realizadas = new List<Tarea>();

// for(int i = 0;i < Pendientes.Count();) {
//     Pendientes[i].MostrarTarea();
//     Console.WriteLine("Se realizo la tarea? (si/no)");
//     string? resp = Console.ReadLine();
//     if (resp != null) {
//         if (resp.ToLower() == "si") {
//             Realizadas.Add(Pendientes[i]);
//             if (Pendientes.Remove(Pendientes[i])) {
//                 Console.WriteLine("Se movio la tarea a 'Realizadas'");
//             }
//         } else {
//             i++;
//         }
//     }
// }

// Tarea BuscarTareaPorDescripcion(string descrip, List<Tarea> lista) {
//     Tarea retorno = new Tarea();
//     foreach(var tarea in lista) {
//         if (tarea.Descripcion != null) {
//             if (tarea.Descripcion.ToLower() == descrip.ToLower()) {
//                 retorno = tarea;
//             }
//         }
//     }
//     return retorno;
// }

// Console.WriteLine("Ingrese la descripcion de la tarea que desea buscar: ");
// string? buscada = Console.ReadLine();
// if (buscada != null) {
//     BuscarTareaPorDescripcion(buscada,Pendientes).MostrarTarea();
// }

// CargarHorasEnArchivo("TotalDeHoras.txt",TotalDeHoras(Realizadas));

// int TotalDeHoras(List<Tarea> Tareas){
//     int horas = 0;
//     foreach (var tarea in Tareas){
//         horas += tarea.Duracion;
//     }
//     return horas;
// }

// void CargarHorasEnArchivo(string ruta, int hora) {
//     using (StreamWriter x = new StreamWriter(ruta)) {
//         x.WriteLine("*****CANTIDAD DE HORAS*****");
//         x.WriteLine("Hora: "+hora);
//     }
// }

Console.Write("Ingrese una ruta valida: ");
var path = Console.ReadLine();

if(!Directory.Exists(path)){
    Console.WriteLine("ERROR. Ruta invalida\n");
} else{
    List<string> listaArchivos = Directory.GetFiles(path).ToList();
    Console.WriteLine("Lista de archivos");
    listaArchivos.ForEach(Console.WriteLine);
    using(StreamWriter indexador = new StreamWriter("index.csv")){

        for(int i = 0; i < listaArchivos.Count; i++){
            // El método Path.GetFileWithoutExtension() devuelve solo el nombre del archivo
            // El método Path.GetExtension() devuelve la extensión del archivo
            indexador.WriteLine($"{i};{Path.GetFileNameWithoutExtension(listaArchivos[i])};{Path.GetExtension(listaArchivos[i])}");
        }

        indexador.Close();
        indexador.Dispose();
    }
}