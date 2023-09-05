namespace TP7_VAZQUEZ.Models;
public class Juego{
    private static string Username {get; set;}
    private static int PuntajeActual {get; set;}
    private static int CantidadPreguntasCorrectas {get; set;}
    private static List<Pregunta> Preguntas {get; set;}
    private static List<Respuesta> Respuestas {get; set;}
    private static Pregunta PreguntaActual {get; set;}
    private static List<Respuesta> RespuestasActuales {get; set;}
    public static void InicializarJuego(){
        Username="";
        PuntajeActual=0;
        CantidadPreguntasCorrectas=0;
        Preguntas=new List<Pregunta>();
        Respuestas=new List<Respuesta>();
        PreguntaActual=new Pregunta();
        RespuestasActuales = new List<Respuesta>();
    }
    public static List<Categoria> ObtenerCategorias(){
        List<Categoria> Categorias=BD.ObtenerCategorias();
        return Categorias;
    }
    public static List<Dificultad> ObtenerDificultades(){
        List<Dificultad> Dificultades=BD.ObtenerDificultades();
        return Dificultades;
    }
    public static void CargarPartida(string Username, int Dificultad, int Categoria){
        Preguntas = BD.ObtenerPreguntas(Dificultad, Categoria);
        Respuestas= BD.ObtenerRespuestas(Preguntas);
    }
    public static Pregunta ObtenerProximaPregunta(){
        if ((Preguntas.Count)>0){
            PreguntaActual=Preguntas[0];
            return PreguntaActual;
        }
        else return null;
    }
    public static List<Respuesta> ObtenerProximasRespuestas(int IdPregunta){
        foreach (Respuesta item in Respuestas)
        {
            if (item.IdPregunta == IdPregunta){
                RespuestasActuales.Add(item);
            }
        }
        return RespuestasActuales;
    }
    public static bool VerificarRespuesta(int IdPregunta, int IdRespuesta){
        bool Correcta=false;
        foreach (Respuesta item in Respuestas)
        {
            if ((item.IdPregunta==IdPregunta)&&(item.IdRespuesta==IdRespuesta)){
                Correcta=true;
                PuntajeActual+=10;
                CantidadPreguntasCorrectas+=1;
                Preguntas.RemoveAt(0);
            }
        }
        return Correcta;
    }
    public static int ObtenerPuntaje(){
        return PuntajeActual;
    }
}