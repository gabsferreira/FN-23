using Blog.Infra;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.DAO
{
    public class PostDAO
    {
        public IList<Post> Lista()
        {
            using (IDbConnection conexao = ConnectionFactory.CriaConexaoAberta())
            {
                IDbCommand comando = conexao.CreateCommand();
                comando.CommandText = "select	*	from	Posts";
                IDataReader leitor = comando.ExecuteReader();
                IList<Post> lista = new List<Post>();
                while (leitor.Read())
                {
                    Post post = new Post()
                    {
                        Id = Convert.ToInt32(leitor["id"]),
                        Titulo = Convert.ToString(leitor["titulo"]),
                        Resumo = Convert.ToString(leitor["resumo"]),
                        Categoria = Convert.ToString(leitor["categoria"]) };
                    lista.Add(post);
                }
                return lista;
            }
        }
    }
}
