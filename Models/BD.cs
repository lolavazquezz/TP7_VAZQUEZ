using System.Data.SqlClient;
using Dapper;
namespace TP7_VAZQUEZ.Models;
public static class BD{
    private static string ConnectionString= @"Server=localhost;DataBase=PreguntadORT;Trusted_Connection=True;";
    public static List<Categoria> ObtenerCategorias(){
        List<Categoria> Categorias= new List<Categoria>();
        using (SqlConnection db = new SqlConnection(ConnectionString)){
            string sql = "SELECT * FROM Categorias";
            Categorias = db.Query<Categoria>(sql).ToList();
        }
        return Categorias;
    }
    public static List<Dificultad> ObtenerDificultades(){
        List<Dificultad> Dificultades= new List<Dificultad>();
        using (SqlConnection db = new SqlConnection(ConnectionString)){
            string sql = "SELECT * FROM Dificultades";
            Dificultades = db.Query<Dificultad>(sql).ToList();
        }
        return Dificultades;
    }
    public static List<Pregunta> ObtenerPreguntas(int IdDificultad, int IdCategoria){
        List<Pregunta> Preguntas= new List<Pregunta>();
        using (SqlConnection db = new SqlConnection(ConnectionString)){
            string sql = "SELECT * FROM Preguntas ";
            if(IdDificultad>-1){
                if (IdDificultad!=-1)  sql += "where IdDificultad=@pDificultad";
                if (IdCategoria!=-1)  sql += " and IdCategoria=@pCategoria";
            }
            Preguntas = db.Query<Pregunta>(sql, new {pDificultad = IdDificultad, pCategoria = IdCategoria}).ToList();
        }
        return Preguntas;
    }
    public static List<Respuesta> ObtenerRespuestas(List<Pregunta> Preguntas){
        List<Respuesta> Respuestas= new List<Respuesta>();
        using (SqlConnection db = new SqlConnection(ConnectionString)){
            foreach (Pregunta item in Preguntas)  
            {
                string sql="SELECT * FROM Respuestas WHERE IdPregunta=@pIdPregunta";
                Respuestas.AddRange(db.Query<Respuesta>(sql, new {@pIdPregunta = item.IdPregunta}).ToList());
            }
        }
        return Respuestas;
    }
}