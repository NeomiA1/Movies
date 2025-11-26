using System;
using Movies.DAL;

namespace Movies.BL
{
    public class User
    {
        public int Id { get; set; }          
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 
       
        public bool Register()
        {
            UserDAL dal = new UserDAL();
            return dal.RegisterUser(this);
        }

      
        public static User Login(string email, string password)
        {
            UserDAL dal = new UserDAL();
            return dal.LoginUser(email, password);
        }
    }
}
