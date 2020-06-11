using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ProjectCentral.Models
{
    public static class AuthenticationModel
    {
        public static UserContextModel UserContext;

        private static List<UserAssignment> SessionUserAssignment = new List<UserAssignment>();

        public static bool UserExists(UserModel User)
        {
            User = UserContext.Users.SingleOrDefault(usr => usr.UserName == User.UserName);

            if (User != null) return true;
            return false;
        }

        public static bool UserInfoCorrect(UserModel User)
        {
            UserModel Correct = UserContext.Users.SingleOrDefault(usr => usr.UserName == User.UserName);
            if (Correct == null) return false;

            if (User.UserName == Correct.UserName && User.Password == Correct.Password) return true;

            return false;
        }
        public static UserModel DatabaseAccurateUser(UserModel User)
        {
            UserModel Correct = UserContext.Users.Include(usr => usr.Role).SingleOrDefault(usr => usr.UserName == User.UserName);
            if (Correct == null) return null;

            if (User.UserName == Correct.UserName && User.Password == Correct.Password) return Correct;

            return null;

        }
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
        public static void AddSessionUser(UserModel User, string SessionID)
        {
            SessionUserAssignment.Add(new UserAssignment() { User = User, SessionID = SessionID });
        }
        public static UserModel GetSessionUser(string SessionID)
        {
            return SessionUserAssignment.Find(usrsess => usrsess.SessionID == SessionID).User;
        }
        private struct UserAssignment
        {
            public UserModel User;
            public string SessionID;
        }
    }
}

