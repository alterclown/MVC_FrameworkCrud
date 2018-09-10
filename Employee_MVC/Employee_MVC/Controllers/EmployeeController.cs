using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Employee_MVC.Models;

namespace Employee_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        string connectionString = @"Data Source=.;Initial Catalog=Employee_CRUDDB;Integrated Security=True";
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string q = "Select * from Employee_MVC";
                SqlDataAdapter sda = new SqlDataAdapter(q,con);
                sda.Fill(dt);
            }
                return View(dt);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View(new EmployeeModel());
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeModel employeeModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string q = "Insert into Employee_MVC values (@First_Name,@Last_Name,@Email_Id,@City,@Country)";
                SqlCommand cmd = new SqlCommand(q,con);
                cmd.Parameters.AddWithValue("@First_Name",employeeModel.First_Name);
                cmd.Parameters.AddWithValue("@Last_Name", employeeModel.Last_Name);
                cmd.Parameters.AddWithValue("@Email_Id", employeeModel.Email_Id);
                cmd.Parameters.AddWithValue("@City", employeeModel.City);
                cmd.Parameters.AddWithValue("@Country", employeeModel.Country);
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string q = "Select * from Employee_MVC where Employee_Id = @Employee_Id";
                SqlDataAdapter sda = new SqlDataAdapter(q,con);
                sda.SelectCommand.Parameters.AddWithValue("@Employee_Id", id);
                sda.Fill(dt);
            }
            if (dt.Rows.Count == 1)
            {
                employeeModel.Employee_Id = Convert.ToInt32(dt.Rows[0][0].ToString());
                employeeModel.First_Name = dt.Rows[0][1].ToString();
                employeeModel.Last_Name = dt.Rows[0][2].ToString();
                employeeModel.Email_Id = dt.Rows[0][3].ToString();
                employeeModel.City = dt.Rows[0][4].ToString();
                employeeModel.Country = dt.Rows[0][5].ToString();
                return View(employeeModel);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(EmployeeModel employeeModel)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string q = "Update Employee_MVC Set First_Name = @First_Name, Last_Name = @Last_Name, Email_Id = @Email_Id, City = @City, Country = @Country where Employee_Id = @Employee_Id";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@Employee_Id", employeeModel.Employee_Id);
                cmd.Parameters.AddWithValue("@First_Name", employeeModel.First_Name);
                cmd.Parameters.AddWithValue("@Last_Name", employeeModel.Last_Name);
                cmd.Parameters.AddWithValue("@Email_Id", employeeModel.Email_Id);
                cmd.Parameters.AddWithValue("@City", employeeModel.City);
                cmd.Parameters.AddWithValue("@Country", employeeModel.Country);
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string q = "Select * from Employee_MVC where Employee_Id = @Employee_Id";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);
                sda.SelectCommand.Parameters.AddWithValue("@Employee_Id", id);
                sda.Fill(dt);
            }
            if (dt.Rows.Count == 1)
            {
                employeeModel.Employee_Id = Convert.ToInt32(dt.Rows[0][0].ToString());
                employeeModel.First_Name = dt.Rows[0][1].ToString();
                employeeModel.Last_Name = dt.Rows[0][2].ToString();
                employeeModel.Email_Id = dt.Rows[0][3].ToString();
                employeeModel.City = dt.Rows[0][4].ToString();
                employeeModel.Country = dt.Rows[0][5].ToString();
                return View(employeeModel);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string q = "Delete from Employee_MVC where Employee_Id = @Employee_Id";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@Employee_Id", id);

                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}
