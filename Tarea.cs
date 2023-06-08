namespace EspacioTarea;

public class Tarea {
    // ATRIBUTOS
    private int tareaID;
    private string? descripcion;
    private int duracion;
    // PROPIEDADES
    public int TareaID { get => tareaID; set => tareaID = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public int Duracion { get => duracion; set => duracion = value; }
    // CONSTRUCTOR
    public Tarea(int id, string descrip, int dura) {
        TareaID = id;
        Descripcion = descrip;
        Duracion = dura;
    }
    public Tarea() {}
    // METODOS
    public void MostrarTarea() {
        Console.WriteLine(" ~ ID: "+TareaID);
        Console.WriteLine(" ~ Descripcion: "+Descripcion);
        Console.WriteLine(" ~ Duracion: "+Duracion);
    }
}