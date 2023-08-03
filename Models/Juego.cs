public class Juego{
    private static string Username {get; set;}
    private static int PuntajeActual {get; set;}
    private static int CantidadPreguntasCorrectas {get; set;}
    private static List<Pregunta> Preguntas {get; set;}
    private static List<Respuesta> Respuestas {get; set;}
    public void InicializarJuego(){
        Username="";
        PuntajeActual=0;
        CantidadPreguntasCorrectas=0;
        Preguntas=new List<Pregunta>();
        Respuestas=new List<Respuesta>();
    }
    public List<Categoria> ObtenerCategorias(){

    }
}