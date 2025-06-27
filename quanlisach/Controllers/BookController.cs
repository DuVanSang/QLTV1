using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using quanlisach.Models;

namespace quanlisach.Controllers
{
    public class BookController : Controller
    {
        // Bộ nhớ tạm để lưu danh sách sách
        private static List<Book> books = new List<Book>();

        // Hiển thị danh sách sách
        public ActionResult Index()
        {
            return View(books);
        }

        // Hiển thị form thêm sách mới
        public ActionResult Create()
        {
            return View();
        }

        // Xử lý thêm sách mới
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = books.Count > 0 ? books.Max(b => b.Id) + 1 : 1;
                books.Add(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // Hiển thị form chỉnh sửa thông tin sách
        public ActionResult Edit(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // Xử lý cập nhật thông tin sách
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            var existingBook = books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Price = book.Price;
                existingBook.PublishDate = book.PublishDate;
                existingBook.Category = book.Category;
                return RedirectToAction("Index");
            }
            return View(book);
        }
    }
}
