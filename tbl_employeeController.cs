//using EmployeeCertification_withoutMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;

//using System.Data.Common;
//using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.UI.WebControls;

//using System.Web.Services.Description;
using EmployeeCertification_withoutMVC.Models;

namespace EmployeeCertification_withoutMVC.Controllers
{
    public class tbl_employeeController : Controller
    {

        //string constr = @"Data Source= DESKTOP-666L8AI\SQLEXPRESS;Initial Catalog=employee; Integrated Security = true";

        string constr = 
            WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        // GET: tbl_employee
        public ActionResult Index()
        {
            if ((string)Session["uname"] == null)
            {
                return RedirectToAction("SignIn", "Login");
            }
            else
            {


                ViewBag.LoggedInUser = Session["uname"];

                List<tbl_employee> tbl_employee_Obj = new List<tbl_employee>();
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlCommand sqlCommand = new SqlCommand("sp_fetch_employee", conn);
                    conn.Open();
                    SqlDataReader sdr = sqlCommand.ExecuteReader();
                    while (sdr.Read())
                    {
                        tbl_employee_Obj.Add(new tbl_employee
                        {
                            id = Convert.ToInt32(sdr[0].ToString()),
                            emp_name = sdr[1].ToString(),
                            age = Convert.ToInt32(sdr[2].ToString()),
                            emp_id = (sdr[3].ToString()),
                            designation = sdr[4].ToString(),
                        }
                        );
                    }
                    conn.Close();
                    return View(tbl_employee_Obj);
                }
            }  
        }
          public ActionResult Logout()
        {
            ViewBag.LoggedInUser = "";
            Session["uname"] = "";
            //Session.Remove("uname");
            return View();


        }
    

        // GET: tbl_employee/Details/5
        public ActionResult Details(int id)
        {
            tbl_employee tbl_employee_Obj = new tbl_employee();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_fetch_employee_id " + id, conn);
                conn.Open();
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                while (sdr.Read())
                {
                    tbl_employee_Obj = new tbl_employee
                    {
                        id = Convert.ToInt32(sdr[0].ToString()),
                        emp_name = sdr[1].ToString(),
                        age = Convert.ToInt32(sdr[2].ToString()),
                        emp_id = (sdr[3].ToString()),
                        designation = sdr[4].ToString(),
                    };
                    
                }
                conn.Close();
                
            }
            return View(tbl_employee_Obj);
        }

        // GET: tbl_employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_employee/Create
        [HttpPost]
        public ActionResult Create(tbl_employee tbl_employee_obj)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlCommand sqlCommand = new SqlCommand("sp_create_employee_id '" + tbl_employee_obj.emp_name + "'," + tbl_employee_obj.age + ",'" + tbl_employee_obj.emp_id + "','" + tbl_employee_obj.designation + "'", conn);
                    conn.Open();
                    int i = sqlCommand.ExecuteNonQuery();
                    conn.Close();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: tbl_employee/Edit/5
        public ActionResult Edit(int id)
        {
            tbl_employee tbl_employee_Obj = new tbl_employee();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_fetch_employee_id " + id, conn);
                conn.Open();
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                while (sdr.Read())
                {
                    tbl_employee_Obj = new tbl_employee
                    {
                        id = Convert.ToInt32(sdr[0].ToString()),
                        emp_name = sdr[1].ToString(),
                        age = Convert.ToInt32(sdr[2].ToString()),
                        emp_id = (sdr[3].ToString()),
                        designation = sdr[4].ToString(),
                    };

                }
                conn.Close();

            }
            return View(tbl_employee_Obj);
        }

        // POST: tbl_employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, tbl_employee tbl_employee_obj)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlCommand sqlCommand = new SqlCommand("sp_edit_employee_id " + id + ",'" + tbl_employee_obj.emp_name + "'," + tbl_employee_obj.age + ",'" + tbl_employee_obj.emp_id + "','" + tbl_employee_obj.designation + "'", conn);
                    conn.Open();
                    int i = sqlCommand.ExecuteNonQuery();
                    conn.Close();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: tbl_employee/Delete/5
        public ActionResult Delete(int id)
        {
            tbl_employee tbl_employee_Obj = new tbl_employee();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_fetch_employee_id " + id, conn);
                conn.Open();
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                while (sdr.Read())
                {
                    tbl_employee_Obj = new tbl_employee
                    {
                        id = Convert.ToInt32(sdr[0].ToString()),
                        emp_name = sdr[1].ToString(),
                        age = Convert.ToInt32(sdr[2].ToString()),
                        emp_id = (sdr[3].ToString()),
                        designation = sdr[4].ToString(),
                    };

                }
                conn.Close();

            }
            return View(tbl_employee_Obj);
        }

        // POST: tbl_employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, tbl_employee tbl_employee_obj)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlCommand sqlCommand = new SqlCommand("sp_delete_employee_id " + id, conn);
                    conn.Open();
                    int i = sqlCommand.ExecuteNonQuery();
                    conn.Close();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
      
        
        
     
        }

        [HttpGet]
        public ActionResult ListCertification(int id)
        {

            List<tbl_employee> get_cert_obj = new List<tbl_employee>();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_get_certification " + id, conn);
                conn.Open();
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                while (sdr.Read())
                {
                    get_cert_obj.Add(new tbl_employee
                    {
                        emp_name = sdr[0].ToString(),
                        emp_id = sdr[1].ToString(),
                        designation = sdr[2].ToString(),
                        certification = sdr[3].ToString()
                    }
                    );
                }
                conn.Close();
                return View(get_cert_obj);
            }
 
        }



    }

}
