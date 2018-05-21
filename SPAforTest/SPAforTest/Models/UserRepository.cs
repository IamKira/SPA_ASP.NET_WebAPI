using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Net.Http.Formatting;
using System.Web.Mvc;

namespace SPAforTest.Models
{
    public class UserRepository
    {
        public const string URI1 = "http://localhost:50404/api/users";
        public const string URI2 = "http://localhost:51321/api/departments";

        private static UserRepository repo = new UserRepository();
        public static UserRepository Current { get { return repo; } }

        public List<User> GetUsers()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(URI1).Result;

            List<User> users = null;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                string responseText = response.Content.ReadAsStringAsync().Result;
                users = jsSerializer.Deserialize<List<User>>(responseText);
                return users;
            }
            else { return users; }
        }
        public List<Department> GetDepartments()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(URI2).Result;

            List<Department> departments = null;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                string responseText = response.Content.ReadAsStringAsync().Result;
                departments = jsSerializer.Deserialize<List<Department>>(responseText);
                return departments;
            }
            else { return departments; }
        }
        

        public List<UsersAndDep> GetUsersAndDepartments()
        {
            List<User> users = GetUsers();
            List<Department> departments = GetDepartments();
            List<UsersAndDep> usersAndDepList = new List<UsersAndDep>();
            foreach (var user in users)
            {
                UsersAndDep uad = new UsersAndDep();
                uad.UserId = user.Id;
                uad.UserName = user.UserName;
                foreach(var dep in departments)
                {
                    if (user.DepartmentId == dep.Id)
                    {
                        uad.DepartmentTitle = dep.Title;
                        break;
                    }
                }
                usersAndDepList.Add(uad);
            }
            return usersAndDepList;
        }

        

        public User GetUser(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(URI1 + "/" + id).Result;

            User user = null;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                string responseText = response.Content.ReadAsStringAsync().Result;
                user = jsSerializer.Deserialize<User>(responseText);
                return user;
            }
            else { return user; }
        }
        public Department GetDepartment(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(URI2 + "/" + id).Result;

            Department department = null;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                string responseText = response.Content.ReadAsStringAsync().Result;
                department = jsSerializer.Deserialize<Department>(responseText);
                return department;
            }
            else { return department; }
        }

        public User AddUser(User user)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.PostAsync<User>(URI1, user, new JsonMediaTypeFormatter()).Result;
            return user;
        }
        public void RemoveUser(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync(URI1 + "/" + id).Result;
        }
        public bool UpdateUser(User user)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.PutAsync<User>(URI1 + "/" + user.Id, user, new JsonMediaTypeFormatter()).Result;
            if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else { return false; }
        }
    }
}