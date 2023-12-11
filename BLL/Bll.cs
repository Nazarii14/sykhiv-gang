// <copyright file="Bll.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BLL
{
    using System.Data;
    using System.Text.RegularExpressions;
    using DAL;
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
        /// Gets a user by their name and surname.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <param name="surname">The surname of the user.</param>
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
        /// <param name="username">The username of user.</param>
        /// <param name="password">The password of user.</param>
        /// <param name="message">A message indicating the result of the registration.</param>
        /// <returns>True if the user is registered successfully, false otherwise.</returns>
        public bool RegisterUser(string name, string surname, string role, string password, string confirmPassword)
        {
            string path = Directory.GetCurrentDirectory() + "\\logs.txt";

            if (this.UserExists(name, surname)) {
                this.LogToFile(path, "User with that name and surname exists!");
                return false;
            }

            if (!IsValidUsername(name))
            {
                this.LogToFile(path, "Invalid username!");
                return false;
            }

            if (!IsValidPassword(password)) {
                this.LogToFile(path, "Invalid password!");
                return false;
            }

            if (password != confirmPassword)
            {
                this.LogToFile(path, "Passwords does not match!");
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
        /// Adds a new User.
        /// </summary>
        /// <param name="firstName">The firstname of user.</param>
        /// <param name="lastname">The lastname of user.</param>
        /// <param name="password">The password of user.</param>
        /// <param name="role">The role of user.</param>
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
#pragma warning disable SA1117 // Parameters should be on same line or separate lines
            decimal price, string size,
#pragma warning restore SA1117 // Parameters should be on same line or separate lines
            int neededAmount, int availableAmount,
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
                    NeededAmount = neededAmount,
                    AvailableAmount = availableAmount,
                    UserId = user_id,
                };

                this.context.Set<Ammunition>().Add(newAmmunition);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding ammunition: {ex.Message}");
            }
        }

#pragma warning disable SA1600 // Elements should be documented
        public void AddWeapon(string type, string name,
#pragma warning restore SA1600 // Elements should be documented
            decimal price, decimal weight, int neededAmount, int availableAmount,
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
                    NeededAmount = neededAmount,
                    AvailableAmount = availableAmount,
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

        public void DeleteWeapon(int id)
        {
            try
            {
                var weapon = this.context.Set<Weapon>().FirstOrDefault(w => w.WeaponId == id);

                if (weapon != null)
                {
                    this.context.Set<Weapon>().Remove(weapon);
                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting weapon: {ex.Message}");
            }
        }

        public void DeleteAmmunition(int id)
        {
            try
            {
                var ammunition = this.context.Set<Ammunition>().FirstOrDefault(a => a.AmmunitionId == id);

                if (ammunition != null)
                {
                    this.context.Set<Ammunition>().Remove(ammunition);
                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting ammunition: {ex.Message}");
            }
        }

        public void DeleteSoldier(int id)
        {
            try
            {
                var soldier = this.context.Set<SoldierAttrb>().FirstOrDefault(s => s.SoldierAttrbId == id);

                if (soldier != null)
                {
                    this.context.Set<SoldierAttrb>().Remove(soldier);
                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting soldier: {ex.Message}");
            }
        }

        public Weapon GetWeaponById(int id)
        {
            try
            {
                return this.context.Set<Weapon>().FirstOrDefault(w => w.WeaponId == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting weapon by id: {ex.Message}");
                return null;
            }
        }

        public Ammunition GetAmmunitionById(int id)
        {
            try
            {
                return this.context.Set<Ammunition>().FirstOrDefault(a => a.AmmunitionId == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting ammunition by id: {ex.Message}");
                return null;
            }
        }

        public SoldierAttrb GetSoldierById(int id)
        {
            try
            {
                return this.context.Set<SoldierAttrb>().FirstOrDefault(s => s.SoldierAttrbId == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting soldier by id: {ex.Message}");
                return null;
            }
        }

        public void EditWeapon(int weaponId, string type, 
            string name, decimal price, 
            decimal weight, int neededAmount, 
            int availableAmount, int userId)
        {
            try
            {
                var weapon = this.context.Set<Weapon>().FirstOrDefault(w => w.WeaponId == weaponId);

                if (weapon != null)
                {
                    weapon.Type = type;
                    weapon.Name = name;
                    weapon.Price = price;
                    weapon.Weight = weight;
                    weapon.NeededAmount = neededAmount;
                    weapon.AvailableAmount = availableAmount;
                    weapon.UserId = userId;

                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error editing weapon: {ex.Message}");
            }
        }

        public void EditAmmunition(int ammunitionId, string type, 
            string name, decimal price, 
            string size, string usersGender, int userId, 
            int neededAmount, int availableAmount) 
        {
            try
            {
                var ammunition = this.context.Set<Ammunition>().FirstOrDefault(a => a.AmmunitionId == ammunitionId);

                if (ammunition != null)
                {
                    ammunition.Type = type;
                    ammunition.Name = name;
                    ammunition.Price = price;
                    ammunition.Size = size;
                    ammunition.UsersGender = usersGender;
                    ammunition.UserId = userId;
                    ammunition.NeededAmount = neededAmount;
                    ammunition.AvailableAmount = availableAmount;

                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error editing ammunition: {ex.Message}");
            }
        }

        public void EditSoldier(int soldierId, string callsign, int userId)
        {
            try
            {
                var soldier = this.context.Set<SoldierAttrb>().FirstOrDefault(s => s.SoldierAttrbId == soldierId);

                if (soldier != null)
                {
                    soldier.Callsign = callsign;
                    soldier.UserId = userId;

                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error editing soldier: {ex.Message}");
            }
        }

        public void DecrementNeededAmountOfWeaponById(int weaponId)
        {
            try
            {
                var weapon = this.context.Set<Weapon>().FirstOrDefault(w => w.WeaponId == weaponId);

                if (weapon != null)
                {
                    weapon.NeededAmount -= 1;
                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error decrementing weapon: {ex.Message}");
            }
        }

        public void IncrementNeededAmountOfWeaponById(int weaponId)
        {
            try
            {
                var weapon = this.context.Set<Weapon>().FirstOrDefault(w => w.WeaponId == weaponId);

                if (weapon != null)
                {
                    weapon.NeededAmount += 1;
                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error decrementing weapon: {ex.Message}");
            }
        }

        public void DecrementAvailableAmountOfWeaponById(int weaponId)
        {
            try
            {
                var weapon = this.context.Set<Weapon>().FirstOrDefault(w => w.WeaponId == weaponId);

                if (weapon != null)
                {
                    weapon.AvailableAmount -= 1;
                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error decrementing weapon: {ex.Message}");
            }
        }

        public void IncrementAvailableAmountOfWeaponById(int weaponId)
        {
            try
            {
                var weapon = this.context.Set<Weapon>().FirstOrDefault(w => w.WeaponId == weaponId);

                if (weapon != null)
                {
                    weapon.AvailableAmount += 1;
                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Incrementing weapon: {ex.Message}");
            }
        }



        public void DecrementNeededAmountOfAmmunitionById(int ammunitionId)
        {
            try
            {
                var ammunition = this.context.Set<Ammunition>().FirstOrDefault(w => w.AmmunitionId == ammunitionId);

                if (ammunition != null)
                {
                    ammunition.NeededAmount -= 1;
                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error decrementing ammunition: {ex.Message}");
            }
        }

        public void IncrementNeededAmountOfAmmunitionById(int ammunitionId)
        {
            try
            {
                var ammunition = this.context.Set<Ammunition>().FirstOrDefault(w => w.AmmunitionId == ammunitionId);

                if (ammunition != null)
                {
                    ammunition.NeededAmount += 1;
                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Incrementing ammunition: {ex.Message}");
            }
        }

        public void DecrementAvailableAmountOfAmmunitionById(int ammunitionId)
        {
            try
            {
                var ammunition = this.context.Set<Ammunition>().FirstOrDefault(w => w.AmmunitionId == ammunitionId);

                if (ammunition != null)
                {
                    ammunition.AvailableAmount -= 1;
                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error decrementing ammunition: {ex.Message}");
            }
        }

        public void IncrementAvailableAmountOfAmmunitionById(int ammunitionId)
        {
            try
            {
                var ammunition = this.context.Set<Ammunition>().FirstOrDefault(w => w.AmmunitionId == ammunitionId);

                if (ammunition != null)
                {
                    ammunition.AvailableAmount += 1;
                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Incrementing ammunition: {ex.Message}");
            }
        }



        public List<Weapon> GetWeapons()
        {
            try
            {
                return this.context.Set<Weapon>().OrderBy(e => e.Name).ToList();
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
                return this.context.Set<Ammunition>().OrderBy(e => e.Name).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting ammunitions: {ex.Message}");
                return null;
            }
        }

        public List<SoldierAttrb> GetSoldiers()
        {
            try
            {
                return this.context.Set<SoldierAttrb>().OrderBy(e => e.Callsign).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting soldiers: {ex.Message}");
                return null;
            }
        }

        public void ChangeBrigadeInfo(string name, string commanderName, string establishmentDate, string location)
        {
            try
            {
                var brigade = this.context.Set<Brigade>().FirstOrDefault();

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
                Brigade brigade = this.context.Set<Brigade>().FirstOrDefault();
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
                Brigade brigade = this.context.Set<Brigade>().FirstOrDefault();
                return new string[] { brigade?.Name, brigade?.CommanderName, brigade?.EstablishmentDate.ToString(), brigade?.Location };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting brigade attributes: {ex.Message}");
                return null;
            }
        }   

        public void LogToFile(string path, string message)
        {
            using (StreamWriter writer = new StreamWriter("logs.txt", true))
            {
                writer.WriteLine($"{DateTime.Now} - {message}");
            }
        }
    }
}
