using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DAO;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        private IList<Post> listaDePosts;

        public PostController()
        {
            this.listaDePosts = new List<Post>
            {
                new Post { Titulo = "A volta dos que não foram", Resumo = "Uns foram e voltaram, outros não", Categoria = "Épico" },
                new Post { Titulo = "Homem Aranha 3", Resumo = "Um homem que também é aranha", Categoria = "Heróis" },
                new Post { Titulo = "Filme do Adam Sandler", Resumo = "Pode ser qualquer um", Categoria = "Pastelão" }
            };
        }

        public IActionResult Index()
        {
            PostDAO dao = new PostDAO();
            IList<Post> lista = dao.Lista();
            return View(lista);
        }

        public IActionResult Novo()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Adiciona(Post p)
        {
            PostDAO dao = new PostDAO();
            dao.Adiciona(p);
            return RedirectToAction("Index");
        }

        public IActionResult RemovePost (int id)
        {
            PostDAO dao = new PostDAO();
            dao.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            PostDAO dao = new PostDAO();
            var posts = dao.FiltraPorCategoria(categoria);
            return View("Index", posts);
        }

        public IActionResult Visualiza(int id)
        {
            PostDAO dao = new PostDAO();
            var post = dao.BuscaPorId(id);
            return View(post);
        }

        public IActionResult EditaPost (Post p)
        {
            PostDAO dao = new PostDAO();
            dao.Atualiza(p);
            return RedirectToAction("Index");
        }

        public IActionResult PublicaPost(int id)
        {
            PostDAO dao = new PostDAO();
            dao.Publica(id);
            return RedirectToAction("Index");
        }


    }
}