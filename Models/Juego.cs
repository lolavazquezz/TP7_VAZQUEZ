public class Juego{
    private static string Username {get; set;}
    private static int PuntajeActual {get; set;}
    private static int CantidadPreguntasCorrectas {get; set;}
    private static List<Pregunta> Preguntas {get; set;}
    private static List<Respuesta> Respuestas {get; set;}
    private static Pregunta PreguntaActual {get; set;}
    private static List<Respuesta> RespuestasActuales {get; set;}
    public void InicializarJuego(){
        Username="";
        PuntajeActual=0;
        CantidadPreguntasCorrectas=0;
        Preguntas=new List<Pregunta>();
        Respuestas=new List<Respuesta>();
        PreguntaActual="";
        RespuestasActuales = new List<Respuesta>();
    }
    public List<Categoria> ObtenerCategorias(){
        List<Categoria> Categorias=BD.ObtenerCategorias();
        return Categorias;
    }
    public List<Dificultad> ObtenerCategorias(){
        List<Dificultad> Dificultades=BD.ObtenerDificultades();
        return Dificultades;
    }
    public void CargarPartida(string Username, int Dificultad, int Categoria){
        Preguntas.Add(BD.ObtenerPreguntas(Dificultad, Categoria));
        Respuestas.Add(BD.ObtenerRespuestas(Preguntas));
    }
    public Pregunta ObtenerProximaPregunta(){
        if ((Pregunta.Count())>0){
            PreguntaActual=Pregunta[0];
            return PreguntaActual;
        }
    }
    public List<Respuesta> ObtenerProximasRespuestas(int IdPregunta){
        foreach (Respuesta item in Respuestas)
        {
            if (item.IdPregunta=IdPregunta){
                RespuestasActuales.Add(item);
            }
        }
        return RespuestasActuales;
    }
    public bool VerificarRespuesta(int IdPregunta, int IdRespuesta){
        bool Correcta=false;
        foreach (Respuesta item in Respuestas)
        {
            if (item.IdPregunta==IdPregunta)&&(item.IdRespuesta==IdRespuesta){
                Correcta=true;
                PuntajeActual+=10;
                CantidadPreguntasCorrectas+=1;
                Preguntas.RemoveAt(0);
            }
        }
        return Correcta;
    }
}