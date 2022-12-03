using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cumulative_Project_1.Models;

namespace Cumulative_Project_1.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Returns a page that lists all classes in database
        /// </summary>
        /// <param name="SearchKey">For search bar input</param>
        /// <example>/Class/List</example>
        /// <returns>List of all classes</returns>

        // GET: /Class/List
        public ActionResult List()
        {
            ClassDataController controller = new ClassDataController();
            IEnumerable<Class> Classes = controller.ListClasses();
            return View(Classes);
        }

        /// <summary>
        /// Method to display show page for individual, selected class
        /// </summary>
        /// <param name="id">classid of class </param>
        /// <example>/Class/Show/1</example>
        /// <returns>Info of HTTP5101</returns>
        public ActionResult Show(int id)
        {
            ClassDataController controller = new ClassDataController();
            Class NewClass = controller.FindClass(id);

            return View(NewClass);
        }
    }
}