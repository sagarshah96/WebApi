using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DemoWebApi.Models;
using DemoWebApi.Data;
using System.Web.Mvc;

namespace DemoWebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        public IHttpActionResult GetEmployee()
        {
            try
            {
                using (var obj = new myDBEntities())
                {
                    var results = obj.Employees.ToList();
                    return Ok(results);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       
        [System.Web.Http.HttpPost]
        public IHttpActionResult AddEmp(EmpModel empmodel)
        {
            try
            {
                using (var obj = new myDBEntities())
                {
                    Employee emp = new Employee();
                    emp.Name = empmodel.Name;
                    emp.Email = empmodel.Email;
                    emp.Location = empmodel.Location;
                    emp.Designation = empmodel.Designation;
                    obj.Employees.Add(emp);
                    obj.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
