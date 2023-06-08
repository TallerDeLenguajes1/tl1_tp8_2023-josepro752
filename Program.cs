// See https://aka.ms/new-console-template for more information
using EspacioTarea;

int cantidad;
int ID = 0;
List<string> LTarea = new List<string>();
LTarea.Add("Lavar");
LTarea.Add("Limpiar");
LTarea.Add("Odernar");
LTarea.Add("Reponer");
LTarea.Add("Contabilizar");

Tarea CrearTarea() {
    Random azar = new Random();
    ID++;
    Tarea T = new Tarea(ID,LTarea[azar.Next(0,5)],azar.Next(10,100));
    return T;
}

Console.WriteLine("Escriba una cantidad de tareas");
if (!(int.TryParse(Console.ReadLine(), out cantidad))) {
    cantidad = 0;
}

List<Tarea> Pendientes = new List<Tarea>();

for (int i = 0;i < cantidad;i++) {
    Pendientes.Add(CrearTarea());
}

List<Tarea> Realizadas = new List<Tarea>();

for(int i = 0;i < Pendientes.Count();) {
    Pendientes[i].MostrarTarea();
    Console.WriteLine("Se realizo la tarea? (si/no)");
    string? resp = Console.ReadLine();
    if (resp != null) {
        if (resp.ToLower() == "si") {
            Realizadas.Add(Pendientes[i]);
            if (Pendientes.Remove(Pendientes[i])) {
                Console.WriteLine("Se movio la tarea a 'Realizadas'");
            }
        } else {
            i++;
        }
    }
}

Tarea BuscarTareaPorDescripcion(string descrip, List<Tarea> lista) {
    Tarea retorno = new Tarea();
    foreach(var tarea in lista) {
        if (tarea.Descripcion != null) {
            if (tarea.Descripcion.ToLower() == descrip.ToLower()) {
                retorno = tarea;
            }
        }
    }
    return retorno;
}
Console.WriteLine("Ingrese la descripcion de la tarea que desea buscar: ");
string? buscada = Console.ReadLine();
if (buscada != null) {
    BuscarTareaPorDescripcion(buscada,Pendientes).MostrarTarea();
}