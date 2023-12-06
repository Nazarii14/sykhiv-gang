namespace BLL
{
    using System.Text.RegularExpressions;
    using DAL.Data;
    using DAL.Models;

    public class Bll
    {
        private readonly MilitaryProjectContext context;

        public Bll(MilitaryProjectContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Checks if the provided username is valid.
        /// </summary>
        /// <param name="username">The username to validate.</param>
        /// <returns>True if the username is valid, false otherwise.</returns>
        public static bool IsValidUsername(string username)
        {
            string usernamePattern = @"^[a-zA-Z0-9_]+$";
            return Regex.IsMatch(username, usernamePattern);
        }

        /// <summary>
        /// Checks if the provided password is valid.
        /// </summary>
        /// <param name="password">The password to validate.</param>
        /// <returns>True if the password is valid, false otherwise.</returns>
        public static bool IsValidPassword(string password)
        {
            string passwordPattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d).{8,}$";
            return Regex.IsMatch(password, passwordPattern);
        }

        /// <summary>
        /// Gets a user by their email.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <returns>The user if found, null otherwise.</returns>
        public User? GetUserByName(string name)
        {
            return this.context.Users.FirstOrDefault(u => u.FirstName == name);
        }

        /// <summary>
        /// Authenticates a user.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>True if the user is authenticated, false otherwise.</returns>
        public bool AuthenticateUser(string name, string password)
        {
            var user = this.GetUserByName(name);
            return user != null && user.Password == password;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <param name="message">A message indicating the result of the registration.</param>
        /// <returns>True if the user is registered successfully, false otherwise.</returns>
        public bool RegisterUser(string name, string username, string password, ref string message)
        {
            if (this.UserExists(name))
            {
                message = "Name must be unique!";
                return false;
            }

            if (!IsValidUsername(username))
            {
                message = "Username must be correct!";
                return false;
            }

            if (!IsValidPassword(password))
            {
                message = "Password must be correct!";
                return false;
            }

            var newUser = new User
            {
                FirstName = name,
                Password = password,
            };
            this.context.Set<User>().Add(newUser);
            this.context.SaveChanges();

            return true;
        }

        /// <summary>
        /// Adds a new recipe.
        /// </summary>
        /// <param name="name">The name of the recipe.</param>
        /// <param name="ingredients">The ingredients of the recipe.</param>
        /// <param name="process">The process of the recipe.</param>
        public void AddUser(string firstName, string lastName, string password, string role)
        {
            try
            {
                User newUser = new User
                {
                    FirstName = firstName,
                    Lastname = lastName,
                    Password = password,
                    Role = role
                };

                this.context.Set<User>().Add(newUser);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding user: {ex.Message}");
            }
        }

        private bool UserExists(string name)
        {
            return this.context.Set<User>().Any(u => u.FirstName == name);
        }

        public void LogToFile(string filePath, string message)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{DateTime.Now} - {message}");
            }
        }
    }
}