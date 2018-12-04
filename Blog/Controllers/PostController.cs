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
        public IActionResult Index()
        {
            PostDAO dao = new PostDAO();
            IList<Post> lista = dao.Lista();
            return View(lista);
        }

        public IActionResult Novo()
        {
            Post p = new Post();
            return View(p);
        }
        
        [HttpPost]
        public IActionResult Adiciona(Post p)
        {
            if(ModelState.IsValid)
            {
                PostDAO dao = new PostDAO();
                dao.Adiciona(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Novo", p);
            }
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
            if(ModelState.IsValid)
            {
                PostDAO dao = new PostDAO();
                dao.Atualiza(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Visualiza", p);
            }
        }

        public IActionResult PublicaPost(int id)
        {
            PostDAO dao = new PostDAO();
            dao.Publica(id);
            return RedirectToAction("Index");
        }


    }
}