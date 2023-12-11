using NUnit.Framework;
using DAL.Models;
using DAL;
using BLL;

namespace UnitTests
{
    using Moq;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class Tests
    {
        private Mock<sykhivgangContext> _context;
        private Bll _bll;

        [SetUp]
        public void Setup()
        {
            this._context = new Mock<sykhivgangContext>();
            this._bll = new Bll(this._context.Object);
        }

        [TestCase("valid_username")]
        [TestCase("AnotherValidUsername_123")]
        [TestCase("user123")]
        [TestCase("user_name_456")]
        public void IsValidUsername_ValidUsernames_ReturnsTrue(string username)
        {
            var result = Bll.IsValidUsername(username);

            Assert.IsTrue(result);
        }

        [TestCase("invalid username")]
        [TestCase("user%@name")]
        [TestCase("user name")]
        [TestCase("user|name")]
        public void IsValidUsername_InvalidUsernames_ReturnsFalse(string username)
        {
            var result = Bll.IsValidUsername(username);

            Assert.IsFalse(result);
        }

        [Test]
        public void GetUserByNameAndSurname_UserExists_ReturnsUser()
        {
            // Arrange
            var users = new List<User>
            {
                new User { UserName = "John", UserSurname = "Doe", Password = "pass123" },
                new User { UserName = "Alice", UserSurname = "Smith", Password = "pass456" }
                // Add more users as needed for test scenarios
            }.AsQueryable();

            _context.Setup(c => c.Users).Returns(MockDbSet(users));

            // Act
            var result = _bll.GetUserByNameAndSurname("John", "Doe");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("John", result.UserName);
            Assert.AreEqual("Doe", result.UserSurname);
        }

        [Test]
        public void GetUserByNameAndSurname_UserDoesNotExist_ReturnsNull()
        {
            // Arrange
            var users = new List<User>
            {
                new User { UserName = "John", UserSurname = "Doe", Password = "pass123" },
                new User { UserName = "Alice", UserSurname = "Smith", Password = "pass456" }
            }.AsQueryable();

            _context.Setup(c => c.Users).Returns(MockDbSet(users));

            // Act
            var result = _bll.GetUserByNameAndSurname("Jane", "Doe");

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void AuthenticateUser_CorrectCredentials_ReturnsTrue()
        {
            // Arrange
            var users = new List<User>
            {
                new User { UserName = "John", UserSurname = "Doe", Password = "pass123" },
                new User { UserName = "Alice", UserSurname = "Smith", Password = "pass456" }
            }.AsQueryable();

            _context.Setup(c => c.Users).Returns(MockDbSet(users));

            // Act
            var result = _bll.AuthenticateUser("John", "Doe", "pass123");

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void AuthenticateUser_IncorrectCredentials_ReturnsFalse()
        {
            // Arrange
            var users = new List<User>
            {
                new User { UserName = "John", UserSurname = "Doe", Password = "pass123" },
                new User { UserName = "Alice", UserSurname = "Smith", Password = "pass456" }
            }.AsQueryable();

            _context.Setup(c => c.Users).Returns(MockDbSet(users));

            // Act
            var result = _bll.AuthenticateUser("John", "Doe", "wrong_password");

            // Assert
            Assert.IsFalse(result);
        }

        // Helper method to mock DbSet
        private static DbSet<T> MockDbSet<T>(IQueryable<T> elements) where T : class
        {
            var dbSetMock = new Mock<DbSet<T>>();
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elements.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elements.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elements.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => elements.GetEnumerator());
            return dbSetMock.Object;
        }

        [Test]
        public void AddUser_AddsUserSuccessfully()
        {
            // Arrange
            _context.Setup(c => c.Set<User>().Add(It.IsAny<User>()));
            _context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            _bll.AddUser("Jane", "Doe", "password", "User");

            // Assert
            _context.Verify(c => c.Set<User>().Add(It.IsAny<User>()), Times.Once);
            _context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void AddAmmunition_AddsAmmunitionSuccessfully()
        {
            // Arrange
            _context.Setup(c => c.Set<Ammunition>().Add(It.IsAny<Ammunition>()));
            _context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            _bll.AddAmmunition("Bullet", "AK-47 Bullets", 10.99m, "Large", 100, 50, "Male", 1);

            // Assert
            _context.Verify(c => c.Set<Ammunition>().Add(It.IsAny<Ammunition>()), Times.Once);
            _context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void AddWeapon_AddsWeaponSuccessfully()
        {
            // Arrange
            _context.Setup(c => c.Set<Weapon>().Add(It.IsAny<Weapon>()));
            _context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            _bll.AddWeapon("Firearm", "AK-47", 499.99m, 3.5m, 10, 5, 1);

            // Assert
            _context.Verify(c => c.Set<Weapon>().Add(It.IsAny<Weapon>()), Times.Once);
            _context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void AddSoldier_AddsSoldierSuccessfully()
        {
            // Arrange
            _context.Setup(c => c.Set<SoldierAttrb>().Add(It.IsAny<SoldierAttrb>()));
            _context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            _bll.AddSoldier("Delta", 1);

            // Assert
            _context.Verify(c => c.Set<SoldierAttrb>().Add(It.IsAny<SoldierAttrb>()), Times.Once);
            _context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void DeleteWeapon_DeletesWeaponSuccessfully()
        {
            // Arrange
            var weaponId = 123;
            var weaponList = new List<Weapon>
            {
                new Weapon { WeaponId = weaponId }
            }.AsQueryable();

            _context.Setup(c => c.Set<Weapon>()).Returns(MockDbSet(weaponList));
            _context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            _bll.DeleteWeapon(weaponId);

            // Assert
            _context.Verify(c => c.Set<Weapon>().Remove(It.IsAny<Weapon>()), Times.Once);
            _context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void DeleteAmmunition_DeletesAmmunitionSuccessfully()
        {
            // Arrange
            var ammoId = 456;
            var ammoList = new List<Ammunition>
            {
                new Ammunition { AmmunitionId = ammoId }
            }.AsQueryable();

            _context.Setup(c => c.Set<Ammunition>()).Returns(MockDbSet(ammoList));
            _context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            _bll.DeleteAmmunition(ammoId);

            // Assert
            _context.Verify(c => c.Set<Ammunition>().Remove(It.IsAny<Ammunition>()), Times.Once);
            _context.Verify(c => c.SaveChanges(), Times.Once);
        }
        [Test]
        public void DeleteSoldier_DeletesSoldierSuccessfully()
        {
            // Arrange
            var soldierId = 123;
            var soldierList = new List<SoldierAttrb>
            {
                new SoldierAttrb { SoldierAttrbId = soldierId }
            }.AsQueryable();

            _context.Setup(c => c.Set<SoldierAttrb>()).Returns(MockDbSet(soldierList));
            _context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            _bll.DeleteSoldier(soldierId);

            // Assert
            _context.Verify(c => c.Set<SoldierAttrb>().Remove(It.IsAny<SoldierAttrb>()), Times.Once);
            _context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void GetWeaponById_ReturnsWeaponSuccessfully()
        {
            // Arrange
            var weaponId = 456;
            var weaponList = new List<Weapon>
            {
                new Weapon { WeaponId = weaponId }
            }.AsQueryable();

            _context.Setup(c => c.Set<Weapon>()).Returns(MockDbSet(weaponList));

            // Act
            var result = _bll.GetWeaponById(weaponId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(weaponId, result.WeaponId);
        }

        [Test]
        public void GetAmmunitionById_ReturnsAmmunitionSuccessfully()
        {
            // Arrange
            var ammoId = 789;
            var ammoList = new List<Ammunition>
            {
                new Ammunition { AmmunitionId = ammoId }
            }.AsQueryable();

            _context.Setup(c => c.Set<Ammunition>()).Returns(MockDbSet(ammoList));

            // Act
            var result = _bll.GetAmmunitionById(ammoId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(ammoId, result.AmmunitionId);
        }

        [Test]
        public void GetSoldierById_ReturnsSoldierSuccessfully()
        {
            // Arrange
            var soldierId = 987;
            var soldierList = new List<SoldierAttrb>
            {
                new SoldierAttrb { SoldierAttrbId = soldierId }
            }.AsQueryable();

            _context.Setup(c => c.Set<SoldierAttrb>()).Returns(MockDbSet(soldierList));

            // Act
            var result = _bll.GetSoldierById(soldierId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(soldierId, result.SoldierAttrbId);
        }

        [Test]
        public void EditWeapon_UpdatesWeaponSuccessfully()
        {
            // Arrange
            var weaponId = 123;
            var weapon = new Weapon { WeaponId = weaponId };
            var weaponList = new[] { weapon }.AsQueryable();

            _context.Setup(c => c.Set<Weapon>()).Returns(MockDbSet(weaponList));
            _context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            _bll.EditWeapon(weaponId, "Type", "Name", 100.0m, 50.0m, 5, 10, 1);

            // Assert
            Assert.AreEqual("Type", weapon.Type);
            Assert.AreEqual("Name", weapon.Name);
            Assert.AreEqual(100.0m, weapon.Price);
            Assert.AreEqual(50.0m, weapon.Weight);
            Assert.AreEqual(5, weapon.NeededAmount);
            Assert.AreEqual(10, weapon.AvailableAmount);
            Assert.AreEqual(1, weapon.UserId);
            _context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void EditAmmunition_UpdatesAmmunitionSuccessfully()
        {
            // Arrange
            var ammunitionId = 456;
            var ammunition = new Ammunition { AmmunitionId = ammunitionId };
            var ammunitionList = new[] { ammunition }.AsQueryable();

            _context.Setup(c => c.Set<Ammunition>()).Returns(MockDbSet(ammunitionList));
            _context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            _bll.EditAmmunition(ammunitionId, "Type", "Name", 50.0m, "Size", "Gender", 1, 5, 10);

            // Assert
            Assert.AreEqual("Type", ammunition.Type);
            Assert.AreEqual("Name", ammunition.Name);
            Assert.AreEqual(50.0m, ammunition.Price);
            Assert.AreEqual("Size", ammunition.Size);
            Assert.AreEqual("Gender", ammunition.UsersGender);
            Assert.AreEqual(1, ammunition.UserId);
            Assert.AreEqual(5, ammunition.NeededAmount);
            Assert.AreEqual(10, ammunition.AvailableAmount);
            _context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void EditSoldier_UpdatesSoldierSuccessfully()
        {
            // Arrange
            var soldierId = 789;
            var soldier = new SoldierAttrb { SoldierAttrbId = soldierId };
            var soldierList = new[] { soldier }.AsQueryable();

            _context.Setup(c => c.Set<SoldierAttrb>()).Returns(MockDbSet(soldierList));
            _context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            _bll.EditSoldier(soldierId, "Callsign", 1);

            // Assert
            Assert.AreEqual("Callsign", soldier.Callsign);
            Assert.AreEqual(1, soldier.UserId);
            _context.Verify(c => c.SaveChanges(), Times.Once);
        }


        [Test]
        public void DecrementNeededAmountOfWeaponById_DecrementsSuccessfully()
        {
            // Arrange
            var weaponId = 123;
            var weapon = new Weapon { WeaponId = weaponId, NeededAmount = 5 };
            var weaponList = new[] { weapon }.AsQueryable();

            _context.Setup(c => c.Set<Weapon>()).Returns(MockDbSet(weaponList));
            _context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            _bll.DecrementNeededAmountOfWeaponById(weaponId);

            // Assert
            Assert.AreEqual(4, weapon.NeededAmount);
            _context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void IncrementNeededAmountOfWeaponById_IncrementsSuccessfully()
        {
            // Arrange
            var weaponId = 123;
            var weapon = new Weapon { WeaponId = weaponId, NeededAmount = 5 };
            var weaponList = new[] { weapon }.AsQueryable();

            _context.Setup(c => c.Set<Weapon>()).Returns(MockDbSet(weaponList));
            _context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            _bll.IncrementNeededAmountOfWeaponById(weaponId);

            // Assert
            Assert.AreEqual(6, weapon.NeededAmount);
            _context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void DecrementAvailableAmountOfWeaponById_DecrementsSuccessfully()
        {
            // Arrange
            var weaponId = 123;
            var weapon = new Weapon { WeaponId = weaponId, AvailableAmount = 5 };
            var weaponList = new[] { weapon }.AsQueryable();

            _context.Setup(c => c.Set<Weapon>()).Returns(MockDbSet(weaponList));
            _context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            _bll.DecrementAvailableAmountOfWeaponById(weaponId);

            // Assert
            Assert.AreEqual(4, weapon.AvailableAmount);
            _context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void IncrementAvailableAmountOfWeaponById_IncrementsSuccessfully()
        {
            // Arrange
            var weaponId = 123;
            var weapon = new Weapon { WeaponId = weaponId, AvailableAmount = 5 };
            var weaponList = new[] { weapon }.AsQueryable();

            _context.Setup(c => c.Set<Weapon>()).Returns(MockDbSet(weaponList));
            _context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            _bll.IncrementAvailableAmountOfWeaponById(weaponId);

            // Assert
            Assert.AreEqual(6, weapon.AvailableAmount);
            _context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void GetWeapons_ReturnsListOfWeapons()
        {
            // Arrange
            var weapons = new List<Weapon>
            {
                new Weapon { WeaponId = 1, Name = "Weapon1" },
                new Weapon { WeaponId = 2, Name = "Weapon2" },
                new Weapon { WeaponId = 3, Name = "Weapon3" }
            }.AsQueryable();

            _context.Setup(c => c.Set<Weapon>()).Returns(MockDbSet(weapons));

            // Act
            var result = _bll.GetWeapons();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("Weapon1", result[0].Name);
            Assert.AreEqual("Weapon2", result[1].Name);
            Assert.AreEqual("Weapon3", result[2].Name);
        }

        [Test]
        public void GetAmmunitions_ReturnsListOfAmmunitions()
        {
            // Arrange
            var ammunitions = new List<Ammunition>
            {
                new Ammunition { AmmunitionId = 1, Name = "Ammunition1" },
                new Ammunition { AmmunitionId = 2, Name = "Ammunition2" },
                new Ammunition { AmmunitionId = 3, Name = "Ammunition3" }
            }.AsQueryable();

            _context.Setup(c => c.Set<Ammunition>()).Returns(MockDbSet(ammunitions));

            // Act
            var result = _bll.GetAmmunitions();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("Ammunition1", result[0].Name);
            Assert.AreEqual("Ammunition2", result[1].Name);
            Assert.AreEqual("Ammunition3", result[2].Name);
        }

        [Test]
        public void GetSoldiers_ReturnsListOfSoldiers()
        {
            // Arrange
            var soldiers = new List<SoldierAttrb>
    {
        new SoldierAttrb { SoldierAttrbId = 1, Callsign = "Soldier1" },
        new SoldierAttrb { SoldierAttrbId = 2, Callsign = "Soldier2" },
        new SoldierAttrb { SoldierAttrbId = 3, Callsign = "Soldier3" }
    }.AsQueryable();

            _context.Setup(c => c.Set<SoldierAttrb>()).Returns(MockDbSet(soldiers));

            // Act
            var result = _bll.GetSoldiers();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("Soldier1", result[0].Callsign);
            Assert.AreEqual("Soldier2", result[1].Callsign);
            Assert.AreEqual("Soldier3", result[2].Callsign);
        }

    }
}
