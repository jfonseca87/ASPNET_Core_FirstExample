using FirstWebApp_ASPNETCore.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp_ASPNETCore.Controllers
{
    public class AuthorController: Controller
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IActionResult List()
        {
            var authors = _authorRepository.GetAllWithBooks();

            if (authors.Count() == 0)
                return View("Empty");

            return View(authors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            _authorRepository.Create(author);

            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        {
            Author author =_authorRepository.GetById(id);

            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            _authorRepository.Update(author);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            Author author = _authorRepository.GetById(id);

            if (author == null)
                return View("Not Found");

            _authorRepository.Delete(author);

            return RedirectToAction("List");
        }
    }
}
