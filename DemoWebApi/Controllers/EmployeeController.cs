using DemoWebApi.Data;
using DemoWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoWebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Route("ListEmployee")]
        public IHttpActionResult ListEmployee()
        {
            try
            {
                using (var obj = new myDBEntities())
                {
                    Employee emp = new Employee();

                    var result = obj.Employees.ToList();
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [Route("GetEmployee")]
        public IHttpActionResult GetEmployee(int? id)
        {
            try
            {
                using (var obj = new myDBEntities())
                {
                    List<Employee> emp = new List<Employee>();
                    if (id != null)
                    {
                        emp = obj.Employees.Where(x => x.EmployeeId == id).ToList();
                    }
                    else
                    {
                        emp = obj.Employees.ToList();
                    }
                    return Ok(emp);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Add edit Employee
        [HttpPost]
        [Route("AddEditEmp")]
        public IHttpActionResult AddEditEmp(EmpModel empmodel)
        {
            try
            {
                using (var obj = new myDBEntities())
                {
                    Employee emp = new Employee();
                    emp = obj.Employees.Where(x => x.EmployeeId == empmodel.EmployeeId).FirstOrDefault();
                    if (emp == null)
                    {

                        emp.Name = empmodel.Name;
                        emp.Email = empmodel.Email;
                        emp.Location = empmodel.Location;
                        emp.Designation = empmodel.Designation;
                        obj.Employees.Add(emp);
                    }
                    else
                    {
                        emp.EmployeeId = empmodel.EmployeeId;
                        emp.Name = empmodel.Name;
                        emp.Email = empmodel.Email;
                        emp.Location = empmodel.Location;
                        emp.Designation = empmodel.Designation;
                    }
                    obj.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // Delete Employee
        [HttpGet]
        [Route("Delete")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (var obj = new myDBEntities())
                {
                    var empDel = obj.Employees.Find(id);
                    obj.Employees.Remove(empDel);
                    obj.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
