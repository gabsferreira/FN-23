using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            var listaDePosts = new List<Post>
            {
                new Post { Titulo = "A volta dos que não foram", Resumo = "Uns foram e voltaram, outros não", Categoria = "Épico" },
                new Post { Titulo = "Homem Aranha 3", Resumo = "Um homem que também é aranha", Categoria = "Heróis" },
                new Post { Titulo = "Filme do Adam Sandler", Resumo = "Pode ser qualquer um", Categoria = "Pastelão" }
            };
            ViewBag.Posts = listaDePosts;
            return View();
        }
    }
}