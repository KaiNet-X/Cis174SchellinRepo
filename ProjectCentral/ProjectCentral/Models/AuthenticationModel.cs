using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ProjectCentral.Models
{
    public static class AuthenticationModel
    {
        //static usercontext allows access to user database
        public static UserContextModel UserContext;
        //creates list of user assignments, consisiting of logged in user and session id
        private static List<UserAssignment> SessionUserAssignment = new List<UserAssignment>();
        //checks if the specified user exists by username
        public static bool UserExists(UserModel User)
        {
            User = UserContext.Users.SingleOrDefault(usr => usr.UserName == User.UserName);

            if (User != null) return true;
            return false;
        }
        //checks if the username and password entered are correct for the user
        public static bool UserInfoCorrect(UserModel User)
        {
            UserModel Correct = UserContext.Users.SingleOrDefault(usr => usr.UserName == User.UserName);
            if (Correct == null) return false;

            if (User.UserName == Correct.UserName && User.Password == Correct.Password) return true;

            return false;
        }
        //if user exists, return a database instance of the user with all of it's information
        private static UserModel DatabaseInstance(UserModel User)
        {
            UserModel Correct = UserContext.Users.Include(usr => usr.Role).SingleOrDefault(usr => usr.UserName == User.UserName);
            
            return Correct;
        }
        //the same use as DatabaseInstance, only it checks if the password is correct
        public static UserModel DatabaseAccurateUser(UserModel User)
        {
            UserModel Correct = DatabaseInstance(User);

            if (User.Password == Correct.Password) return Correct;

            return null;
        }
        //creates the user if a user with the same username does not already exist
        public static bool RegisterUser(UserModel User)
        {
            if (!UserExists(User))
            {
                UserContext.Add(User);
                UserContext.SaveChanges();
                return true;
            }
            return false;
        }
        //removes the user if it exists and its role is user
        public static void RemoveUser(UserModel User)
        {
            if (UserExists(User) && User.RoleID == 2)
            {
                UserContext.Users.Remove(DatabaseInstance(User));
                UserContext.SaveChanges();
            }
        }
        //returns the annonymous user
        private static UserModel GetDefaultUser()
        {
            return UserContext.Users.Include(rol => rol.Role).SingleOrDefault(def => def.RoleID == 3);
        }
        //gets a user based on database id
        public static UserModel GetUserWithID(int ID)
        {
            return UserContext.Users.Find(ID);
        }
        //adds or logs a user in that can be accessed by the session
        public static void AddSessionUser(UserModel User, string SessionID)
        {
            SessionUserAssignment.Add(new UserAssignment() { User = User, SessionID = SessionID });
        }
        //accesses logged in user by its session
        public static UserModel GetSessionUser(string SessionID)
        {
            UserModel User =  SessionUserAssignment.Find(usrsess => usrsess.SessionID == SessionID).User;
            if (User == null) User = GetDefaultUser();
            return User;
        }
        //return all users with a role of users
        public static List<UserModel> GetBasicUsers()
        {
            return UserContext.Users.Where(usr => usr.RoleID == 2).ToList();
        }
        //logs out or removes a user from the list of active users
        public static void RemoveSessionUser(string SessionID)
        {
            UserAssignment? User = SessionUserAssignment.Find(usrsess => usrsess.SessionID == SessionID);
            if (User != null)
                SessionUserAssignment.Remove(User.Value);
        }
        //structure that combines user with a session id to be accessed by it's session
        private struct UserAssignment
        {
            public UserModel User;
            public string SessionID;
        }
    }
}

