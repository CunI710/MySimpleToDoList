using Microsoft.AspNetCore.Mvc;
using SimpleToDoList.Models;

namespace SimpleToDoList.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index(int id)
        {
            
            List<ToDoTask> tasks = new List<ToDoTask>();
            using(ToDoListContext db = new ToDoListContext())
            {
                if(id != 0)
                {

                    ToDoTask? task = db.ToDoList.FirstOrDefault(t => t.Id == id);
                    if (task != null)
                    {
                        db.ToDoList.Remove(task);
                        db.SaveChanges();
                    }

                }
                tasks = db.ToDoList.Where(t=>!t.Complete).OrderBy(t=>t.CreateDate).ToList();
            }
            return View(tasks);
        }

        [HttpPost]
        public IActionResult Index(ToDoTask todoTask)
        {

            using (ToDoListContext db = new ToDoListContext())
            {
                db.ToDoList.Add(todoTask);
                db.SaveChanges();
            }

                
            return Redirect("/");  
        }

        //[HttpDelete]
        //public IActionResult Index(int Id)
        //{
        //    using (ToDoListContext db = new ToDoListContext())
        //    {
        //        ToDoTask task = db.ToDoList.FirstOrDefault(t => t.Id==Id);
        //        if (task!=null)
        //        {
        //            db.ToDoList.Remove(task);
        //            db.SaveChanges();
        //        }
        //    }
        //    return Redirect("/");
        //}

    }
}
