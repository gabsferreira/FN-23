using Blog.Infra;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
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
            using (BlogContext contexto = new BlogContext())
            {
                var lista = contexto.Posts.ToList();
                return lista;
            }
        }

        public void Adiciona(Post post)
        {
            using (BlogContext contexto = new BlogContext())
            {
                contexto.Add(post);
                contexto.SaveChanges();
            }
        }

        public IList<Post> FiltraPorCategoria(string categoria)
        {
            using (BlogContext contexto = new BlogContext())
            {
                var posts = contexto.Posts.Where(p => p.Categoria.Contains(categoria));

                return posts.ToList();
            }
        }

        public void Remove(int id)
        {
            using (BlogContext contexto = new BlogContext())
            {
                var post = contexto.Posts.Find(id);
                contexto.Remove(post);
                contexto.SaveChanges();
            }
        }

        public Post BuscaPorId(int id)
        {
            using (BlogContext contexto = new BlogContext())
            {
                return contexto.Posts.Find(id);
            }
        }

        public void Atualiza(Post p)
        {
            using (BlogContext contexto = new BlogContext())
            {
                contexto.Entry(p).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Publica(int id)
        {
            using (BlogContext contexto = new BlogContext())
            {
                Post post = contexto.Posts.Find(id);
                post.Publicado = true;
                post.DataPublicacao = DateTime.Now;
                contexto.SaveChanges();
            }
        }
    }
}
