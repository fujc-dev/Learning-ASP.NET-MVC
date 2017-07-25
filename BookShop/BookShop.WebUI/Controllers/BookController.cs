using BookShop.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.WebUI.Controllers
{
    public class BookController : Controller
    {

        private IBookRepository repository;

        public BookController(IBookRepository bookRepository)
        {
            repository = bookRepository;
        }
        public ViewResult List()
        {
            return View(repository.Books);
        }
	}
}