﻿namespace BLL
{
    using System.Data;
    using System.Text.RegularExpressions;
    using DAL.Data;
    using DAL.Models;

    public class Bll
    {
        private readonly sykhivgangContext context;

        public Bll(sykhivgangContext context)
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
        public User? GetUserByNameAndSurname(string name, string surname)
        {
            return this.context.Users
                .FirstOrDefault(u => u.UserName == name && u.UserSurname == surname);
        }

        /// <summary>
        /// Authenticates a user.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>True if the user is authenticated, false otherwise.</returns>
        public bool AuthenticateUser(string name, string surname, string password)
        {
            var user = this.GetUserByNameAndSurname(name, surname);
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
        public bool RegisterUser(string name, string surname, string role, string password, string confirmPassword)
        {
            string path = Directory.GetCurrentDirectory() + "\\logs.txt";

            if (UserExists(name, surname)) {
                LogToFile(path, "User with that name and surname exists!");
                return false;
            }

            if (!IsValidUsername(name))
            {
                LogToFile(path, "Invalid username!");
                return false;
            }

            if (!IsValidPassword(password)) {
                LogToFile(path, "Invalid password!");
                return false;
            }

            if (password != confirmPassword)
            {
                LogToFile(path, "Passwords does not match!");
                return false;
            }

            var newUser = new User
            {
                UserName = name,
                UserSurname = surname,
                Role = role,
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
                    UserName = firstName,
                    UserSurname = lastName,
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

        private bool UserExists(string name, string surname)
        {
            return this.context.Set<User>().Any(u => u.UserName == name && u.UserSurname == surname);
        }

        public void AddAmmunition(string type, string name,
            decimal price, string size, 
            string gender, int user_id)
        {
            try
            {
                Ammunition newAmmunition = new Ammunition
                {
                    Type = type,
                    Name = name,
                    Price = price,
                    Size = size,
                    UsersGender = gender,
                    UserId = user_id
                };

                this.context.Set<Ammunition>().Add(newAmmunition);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding ammunition: {ex.Message}");
            }
        }

        public void AddWeapon(string type, string name, 
            decimal price, decimal weight, 
            int user_id)
        {
            try
            {
                Weapon newWeapon = new Weapon
                {
                    Type = type,
                    Name = name,
                    Price = price,
                    Weight = weight,
                    UserId = user_id
                };

                this.context.Set<Weapon>().Add(newWeapon);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding weapon: {ex.Message}");
            }
        }

        public List<Weapon> GetWeapons()
        {
            try
            {
                return this.context.Set<Weapon>().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting weapons: {ex.Message}");
                return null;
            }
        }

        public List<Ammunition> GetAmmunitions()
        {
            try
            {
                return this.context.Set<Ammunition>().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting ammunitions: {ex.Message}");
                return null;
            }
        }

        public void AddSoldier(string callsign, int user_id)
        {
            try
            {
                SoldierAttrb newSoldier = new SoldierAttrb
                {
                    Callsign = callsign,
                    UserId = user_id
                };

                this.context.Set<SoldierAttrb>().Add(newSoldier);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding soldier: {ex.Message}");
            }
        }

        public void ChangeBrigadeInfo(string name, string commanderName, string establishmentDate, string location)
        {
            try
            {
                var brigade = context.Set<Brigade>().FirstOrDefault();

                if (brigade != null)
                {
                    brigade.Name = name;
                    brigade.EstablishmentDate = DateOnly.Parse(establishmentDate);
                    brigade.CommanderName = commanderName;
                    brigade.Location = location;

                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error changing brigade: {ex.Message}");
            }
        }

        public string GetBrigadeName()
        {
            try
            {
                Brigade brigade = context.Set<Brigade>().FirstOrDefault();
                return brigade?.Name;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting brigade name: {ex.Message}");
                return null;
            }

        }

        public string[] GetBrigadeInfo()
        {
            try
            {
                Brigade brigade = context.Set<Brigade>().FirstOrDefault();
                return new string[] { brigade?.Name, brigade?.CommanderName, brigade?.EstablishmentDate.ToString(), brigade?.Location };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting brigade attributes: {ex.Message}");
                return null;
            }
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