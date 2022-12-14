using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using Cumulative_Project_1.Models;

namespace Cumulative_Project_1.Controllers
{
   /// <summary>
   /// Controller for read functionality on data relating to teachers table
   /// </summary>
    public class TeacherController : Controller
    {
 
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Returns a page that lists all teachers in database
        /// </summary>
        /// <param name="SearchKey">For search bar input</param>
        /// <example>/Teacher/List</example>
        /// <returns>List of all teachers</returns>
       
        // GET: /Teacher/List
        public ActionResult List(string SearchKey=null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);
            return View(Teachers);
        }
        /// <summary>
        /// Method to display show page for individual, selected teacher
        /// </summary>
        /// <param name="id">teacherid of teacher </param>
        /// <example>/Teacher/Show/1</example>
        /// <returns>Info of Alexander Bennett</returns>
        
        // GET: /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);

            return View(SelectedTeacher);
        }
        /// <summary>
        /// Returns the confirm deletion page for selected teacher corresponding to teacherid
        /// </summary>
        /// <param name="id">teacherid for teacher</param>
        /// <example>/Teacher/DeleteConfirm/1</example>
        /// <returns>Are you sure you want to delete Alex Bennett?</returns>
       
        //GET: /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);

            return View(NewTeacher);
        }
        /// <summary>
        /// Performs teacher deletion and returns user back to list of teachers
        /// </summary>
        /// <param name="id">teacherid for teacher</param>
        /// <returns>/Teacher/List with updated list items</returns>
    
        //POST: /Teacher/Delete/{id}

        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        /// <summary>
        /// Returns new view where user can input parameters for new teacher in database
        /// </summary>
        /// <returns>HTML form input for teacher columns</returns>

        //GET: /Teacher/New

        public ActionResult New()
        {
            return View();
        }

        /// <summary>
        /// Adds a new teacher to the teacher table in the database by gathering input parameters on the New page.
        /// </summary>
        /// <param name="TeacherFname"></param>
        /// <param name="TeacherLName"></param>
        /// <param name="EmployeeNumber"></param>
        /// <param name="HireDate"></param>
        /// <param name="Salary"></param>
        /// <returns>/Teacher/List with new teacher added</returns>

        //POST: /Teacher/Create
        [HttpPost]
        public ActionResult Create(string TeacherFname, string TeacherLName, string EmployeeNumber, DateTime HireDate, decimal Salary)
        {
            // Testing input fields using Debug.WriteLine
            Debug.WriteLine("You have accessed the Create Method.");
            Debug.WriteLine(TeacherFname);
            Debug.WriteLine(TeacherFname);
            Debug.WriteLine(EmployeeNumber);
            Debug.WriteLine(HireDate);
            Debug.WriteLine(Salary);

            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLName;
            NewTeacher.EmployeeNumber = EmployeeNumber;
            NewTeacher.HireDate = HireDate;
            NewTeacher.Salary = Salary;

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            // Returns to list page where new teacher should now appear
            return RedirectToAction("List");
        }

        /// <summary>
        /// Routes to a dynamically generated "Teacher Update" page which gathers info from the database.
        /// </summary>
        /// <param name="id">Id of the teacher</param>
        /// <returns>Page which asks user for new information on selected teacher as part of a form</returns>
        
        // GET: Teacher/Update/{id}
        public ActionResult Update(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);

            return View(SelectedTeacher);
        }
        /// <summary>
        /// Recieves a POST request containing information about an existing teacher in the system with new values. Conveys this information to the API and redirects to the "teacher show" page of the updated teacher.
        /// </summary>
        /// <param name="id">Id of teacher to update</param>
        /// <param name="TeacherFname">Updated first name</param>
        /// <param name="TeacherLName">Updated last name</param>
        /// <param name="EmployeeNumber">Updated Employee Number</param>
        /// <param name="HireDate">Updated hire date</param>
        /// <param name="Salary">Updated salary</param>
        /// <returns>Dynamic webpage which provides the current info of teacher</returns>

        // POST: /Teacher/Update/{id}
        [HttpPost]
        public ActionResult Update(int id, string TeacherFname, string TeacherLName, string EmployeeNumber, DateTime HireDate, decimal Salary)
        {
            Teacher TeacherInfo = new Teacher();
            TeacherInfo.TeacherFname = TeacherFname;
            TeacherInfo.TeacherLname = TeacherLName;
            TeacherInfo.EmployeeNumber = EmployeeNumber;
            TeacherInfo.HireDate = HireDate;
            TeacherInfo.Salary = Salary;

            TeacherDataController controller = new TeacherDataController();
            controller.UpdateTeacher( id, TeacherInfo);

            return RedirectToAction("Show/" + id);
        }
    }

}