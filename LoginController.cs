using EmployeeCertification_withoutMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace EmployeeCertification_withoutMVC.Controllers
{
    public class LoginController : Controller
    {

        //string constr = @"Data Source= DESKTOP-666L8AI\SQLEXPRESS;Initial Catalog=employee; Integrated Security = true";

              string constr = 
            WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Signup()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult signup(tbl_login tbl_loginobj)
        {

            if (tbl_loginobj.uname != "")
            {

                try
                {

                    using (SqlConnection conn = new SqlConnection(constr))
                    {
                        SqlCommand sqlCommand = new SqlCommand("sp_login_signup '" + tbl_loginobj.uname + "','" + tbl_loginobj.pwd + "'", conn);
                        conn.Open();
                        int i = sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        if (i > 0)
                        {
                            ViewBag.SignupSuccess = "success";
                        }
                        //return RedirectToAction("Index");
                        return View();
                    }
                }
                catch
                {
                    return View();
                }
            }
              return View();
        }

        // GET: Login/Create
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(tbl_login tbl_loginobj)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(constr))
                {
                    string uname = "";
                    SqlCommand sqlCommand = new SqlCommand("sp_login '" + tbl_loginobj.uname + "','" + tbl_loginobj.pwd + "'", conn);
                    conn.Open();
                    SqlDataReader sdr = sqlCommand.ExecuteReader();
                    if (sdr.Read())
                    {
                        uname = sdr[0].ToString();
                        Session["uname"] = uname;
                                                 
                    }

                    conn.Close();
                    if (uname != "")
                    {
                        ViewBag.Loginsuccess = "valid User";
                        return RedirectToAction("Index","tbl_employee");
                            
                    }

                    else
                    {

                        ViewBag.Loginsuccess = "Invalid User";
                        return RedirectToAction("SignIn");
                    }

                  




                    //return RedirectToAction("Index");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
