// <copyright file="UnitTest1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnitTests
{
    using System.Collections.Generic;
    using BLL;
    using DAL;
    using DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Moq;

    public class Tests
    {
        private Mock<SykhivgangContext> context;
        private Bll bll;

        [SetUp]
        public void Setup()
        {
            this.context = new Mock<SykhivgangContext>();
            this.bll = new Bll(this.context.Object);
        }

        private static DbSet<T> MockDbSet<T>(IQueryable<T> elements)
            where T : class
        {
            var dbSetMock = new Mock<DbSet<T>>();
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elements.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elements.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elements.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => elements.GetEnumerator());
            return dbSetMock.Object;
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
            var users = new List<User>
            {
                new User { UserName = "John", UserSurname = "Doe", Password = "pass123" },
                new User { UserName = "Alice", UserSurname = "Smith", Password = "pass456" },
            }.AsQueryable();

            this.context.Setup(c => c.Users).Returns(MockDbSet(users));

            var result = this.bll.GetUserByNameAndSurname("John", "Doe");

            Assert.IsNotNull(result);
            Assert.That(result.UserName, Is.EqualTo("John"));
            Assert.That(result.UserSurname, Is.EqualTo("Doe"));
        }

        [Test]
        public void GetUserByNameAndSurname_UserDoesNotExist_ReturnsNull()
        {
            // Arrange
            var users = new List<User>
            {
                new User { UserName = "John", UserSurname = "Doe", Password = "pass123" },
                new User { UserName = "Alice", UserSurname = "Smith", Password = "pass456" },
            }.AsQueryable();

            this.context.Setup(c => c.Users).Returns(MockDbSet(users));

            // Act
            var result = this.bll.GetUserByNameAndSurname("Jane", "Doe");

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
                new User { UserName = "Alice", UserSurname = "Smith", Password = "pass456" },
            }.AsQueryable();

            this.context.Setup(c => c.Users).Returns(MockDbSet(users));

            // Act
            var result = this.bll.AuthenticateUser("John", "Doe", "pass123");

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
                new User { UserName = "Alice", UserSurname = "Smith", Password = "pass456" },
            }.AsQueryable();

            this.context.Setup(c => c.Users).Returns(MockDbSet(users));

            // Act
            var result = this.bll.AuthenticateUser("John", "Doe", "wrong_password");

            // Assert
            Assert.IsFalse(result);
        }



        [Test]
        public void AddUser_AddsUserSuccessfully()
        {
            // Arrange
            this.context.Setup(c => c.Set<User>().Add(It.IsAny<User>()));
            this.context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            this.bll.AddUser("Jane", "Doe", "password", "User");

            // Assert
            this.context.Verify(c => c.Set<User>().Add(It.IsAny<User>()), Times.Once);
            this.context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void AddAmmunition_AddsAmmunitionSuccessfully()
        {
            // Arrange
            this.context.Setup(c => c.Set<Ammunition>().Add(It.IsAny<Ammunition>()));
            this.context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            this.bll.AddAmmunition("Bullet", "AK-47 Bullets", 10.99m, "Large", 100, 50, "Male", 1);

            // Assert
            this.context.Verify(c => c.Set<Ammunition>().Add(It.IsAny<Ammunition>()), Times.Once);
            this.context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void AddWeapon_AddsWeaponSuccessfully()
        {
            // Arrange
            this.context.Setup(c => c.Set<Weapon>().Add(It.IsAny<Weapon>()));
            this.context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            this.bll.AddWeapon("Firearm", "AK-47", 499.99m, 3.5m, 10, 5, 1);

            // Assert
            this.context.Verify(c => c.Set<Weapon>().Add(It.IsAny<Weapon>()), Times.Once);
            this.context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void AddSoldier_AddsSoldierSuccessfully()
        {
            // Arrange
            this.context.Setup(c => c.Set<SoldierAttrb>().Add(It.IsAny<SoldierAttrb>()));
            this.context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            this.bll.AddSoldier("Delta", 1);

            // Assert
            this.context.Verify(c => c.Set<SoldierAttrb>().Add(It.IsAny<SoldierAttrb>()), Times.Once);
            this.context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void DeleteWeapon_DeletesWeaponSuccessfully()
        {
            var weaponId = 123;
            var weaponList = new List<Weapon>
            {
                new Weapon { WeaponId = weaponId },
            }.AsQueryable();

            this.context.Setup(c => c.Set<Weapon>()).Returns(MockDbSet(weaponList));
            this.context.Setup(c => c.SaveChanges()).Returns(1);

            this.bll.DeleteWeapon(weaponId);

            this.context.Verify(c => c.Set<Weapon>().Remove(It.IsAny<Weapon>()), Times.Once);
            this.context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void DeleteAmmunition_DeletesAmmunitionSuccessfully()
        {
            // Arrange
            var ammoId = 456;
            var ammoList = new List<Ammunition>
            {
                new Ammunition { AmmunitionId = ammoId },
            }.AsQueryable();

            this.context.Setup(c => c.Set<Ammunition>()).Returns(MockDbSet(ammoList));
            this.context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            this.bll.DeleteAmmunition(ammoId);

            // Assert
            this.context.Verify(c => c.Set<Ammunition>().Remove(It.IsAny<Ammunition>()), Times.Once);
            this.context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void DeleteSoldier_DeletesSoldierSuccessfully()
        {
            // Arrange
            var soldierId = 123;
            var soldierList = new List<SoldierAttrb>
            {
                new SoldierAttrb { SoldierAttrbId = soldierId },
            }.AsQueryable();

            this.context.Setup(c => c.Set<SoldierAttrb>()).Returns(MockDbSet(soldierList));
            this.context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            this.bll.DeleteSoldier(soldierId);

            // Assert
            this.context.Verify(c => c.Set<SoldierAttrb>().Remove(It.IsAny<SoldierAttrb>()), Times.Once);
            this.context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void GetWeaponById_ReturnsWeaponSuccessfully()
        {
            // Arrange
            var weaponId = 456;
            var weaponList = new List<Weapon>
            {
                new Weapon { WeaponId = weaponId },
            }.AsQueryable();

            this.context.Setup(c => c.Set<Weapon>()).Returns(MockDbSet(weaponList));

            // Act
            var result = this.bll.GetWeaponById(weaponId);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.WeaponId, Is.EqualTo(weaponId));
        }

        [Test]
        public void GetAmmunitionById_ReturnsAmmunitionSuccessfully()
        {
            // Arrange
            var ammoId = 789;
            var ammoList = new List<Ammunition>
            {
                new Ammunition { AmmunitionId = ammoId },
            }.AsQueryable();

            this.context.Setup(c => c.Set<Ammunition>()).Returns(MockDbSet(ammoList));

            // Act
            var result = this.bll.GetAmmunitionById(ammoId);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.AmmunitionId, Is.EqualTo(ammoId));
        }

        [Test]
        public void GetSoldierById_ReturnsSoldierSuccessfully()
        {
            // Arrange
            var soldierId = 987;
            var soldierList = new List<SoldierAttrb>
            {
                new SoldierAttrb { SoldierAttrbId = soldierId },
            }.AsQueryable();

            this.context.Setup(c => c.Set<SoldierAttrb>()).Returns(MockDbSet(soldierList));

            // Act
            var result = this.bll.GetSoldierById(soldierId);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.SoldierAttrbId, Is.EqualTo(soldierId));
        }

        [Test]
        public void EditWeapon_UpdatesWeaponSuccessfully()
        {
            // Arrange
            var weaponId = 123;
            var weapon = new Weapon { WeaponId = weaponId };
            var weaponList = new[] { weapon }.AsQueryable();

            this.context.Setup(c => c.Set<Weapon>()).Returns(MockDbSet(weaponList));
            this.context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            this.bll.EditWeapon(weaponId, "Type", "Name", 100.0m, 50.0m, 5, 10, 1);

            // Assert
            Assert.That(weapon.Type, Is.EqualTo("Type"));
            Assert.That(weapon.Name, Is.EqualTo("Name"));
            Assert.That(weapon.Price, Is.EqualTo(100.0m));
            Assert.That(weapon.Weight, Is.EqualTo(50.0m));
            Assert.That(weapon.NeededAmount, Is.EqualTo(5));
            Assert.That(weapon.AvailableAmount, Is.EqualTo(10));
            Assert.That(weapon.UserId, Is.EqualTo(1));
            this.context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void EditAmmunition_UpdatesAmmunitionSuccessfully()
        {
            // Arrange
            var ammunitionId = 456;
            var ammunition = new Ammunition { AmmunitionId = ammunitionId };
            var ammunitionList = new[] { ammunition }.AsQueryable();

            this.context.Setup(c => c.Set<Ammunition>()).Returns(MockDbSet(ammunitionList));
            this.context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            this.bll.EditAmmunition(ammunitionId, "Type", "Name", 50.0m, "Size", "Gender", 1, 5, 10);

            // Assert
            Assert.That(ammunition.Type, Is.EqualTo("Type"));
            Assert.That(ammunition.Name, Is.EqualTo("Name"));
            Assert.That(ammunition.Price, Is.EqualTo(50.0m));
            Assert.That(ammunition.Size, Is.EqualTo("Size"));
            Assert.That(ammunition.UsersGender, Is.EqualTo("Gender"));
            Assert.That(ammunition.UserId, Is.EqualTo(1));
            Assert.That(ammunition.NeededAmount, Is.EqualTo(5));
            Assert.That(ammunition.AvailableAmount, Is.EqualTo(10));
            this.context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void EditSoldier_UpdatesSoldierSuccessfully()
        {
            // Arrange
            var soldierId = 789;
            var soldier = new SoldierAttrb { SoldierAttrbId = soldierId };
            var soldierList = new[] { soldier }.AsQueryable();

            this.context.Setup(c => c.Set<SoldierAttrb>()).Returns(MockDbSet(soldierList));
            this.context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            this.bll.EditSoldier(soldierId, "Callsign", 1);

            // Assert
            Assert.That(soldier.Callsign, Is.EqualTo("Callsign"));
            Assert.That(soldier.UserId, Is.EqualTo(1));
            this.context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void DecrementNeededAmountOfWeaponById_DecrementsSuccessfully()
        {
            // Arrange
            var weaponId = 123;
            var weapon = new Weapon { WeaponId = weaponId, NeededAmount = 5 };
            var weaponList = new[] { weapon }.AsQueryable();

            this.context.Setup(c => c.Set<Weapon>()).Returns(MockDbSet(weaponList));
            this.context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            this.bll.DecrementNeededAmountOfWeaponById(weaponId);

            // Assert
            Assert.That(weapon.NeededAmount, Is.EqualTo(4));
            this.context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void IncrementNeededAmountOfWeaponById_IncrementsSuccessfully()
        {
            // Arrange
            var weaponId = 123;
            var weapon = new Weapon { WeaponId = weaponId, NeededAmount = 5 };
            var weaponList = new[] { weapon }.AsQueryable();

            this.context.Setup(c => c.Set<Weapon>()).Returns(MockDbSet(weaponList));
            this.context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            this.bll.IncrementNeededAmountOfWeaponById(weaponId);

            // Assert
            Assert.That(weapon.NeededAmount, Is.EqualTo(6));
            this.context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void DecrementAvailableAmountOfWeaponById_DecrementsSuccessfully()
        {
            // Arrange
            var weaponId = 123;
            var weapon = new Weapon { WeaponId = weaponId, AvailableAmount = 5 };
            var weaponList = new[] { weapon }.AsQueryable();

            this.context.Setup(c => c.Set<Weapon>()).Returns(MockDbSet(weaponList));
            this.context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            this.bll.DecrementAvailableAmountOfWeaponById(weaponId);

            // Assert
            Assert.That(weapon.AvailableAmount, Is.EqualTo(4));
            this.context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void IncrementAvailableAmountOfWeaponById_IncrementsSuccessfully()
        {
            // Arrange
            var weaponId = 123;
            var weapon = new Weapon { WeaponId = weaponId, AvailableAmount = 5 };
            var weaponList = new[] { weapon }.AsQueryable();

            this.context.Setup(c => c.Set<Weapon>()).Returns(MockDbSet(weaponList));
            this.context.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            this.bll.IncrementAvailableAmountOfWeaponById(weaponId);

            // Assert
            Assert.That(weapon.AvailableAmount, Is.EqualTo(6));
            this.context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void GetWeapons_ReturnsListOfWeapons()
        {
            // Arrange
            var weapons = new List<Weapon>
            {
                new Weapon { WeaponId = 1, Name = "Weapon1" },
                new Weapon { WeaponId = 2, Name = "Weapon2" },
                new Weapon { WeaponId = 3, Name = "Weapon3" },
            }.AsQueryable();

            this.context.Setup(c => c.Set<Weapon>()).Returns(MockDbSet(weapons));

            // Act
            var result = bll.GetWeapons();

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[0].Name, Is.EqualTo("Weapon1"));
            Assert.That(result[1].Name, Is.EqualTo("Weapon2"));
            Assert.That(result[2].Name, Is.EqualTo("Weapon3"));
        }

        [Test]
        public void GetAmmunitions_ReturnsListOfAmmunitions()
        {
            // Arrange
            var ammunitions = new List<Ammunition>
            {
                new Ammunition { AmmunitionId = 1, Name = "Ammunition1" },
                new Ammunition { AmmunitionId = 2, Name = "Ammunition2" },
                new Ammunition { AmmunitionId = 3, Name = "Ammunition3" },
            }.AsQueryable();

            this.context.Setup(c => c.Set<Ammunition>()).Returns(MockDbSet(ammunitions));

            // Act
            var result = this.bll.GetAmmunitions();

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[0].Name, Is.EqualTo("Ammunition1"));
            Assert.That(result[1].Name, Is.EqualTo("Ammunition2"));
            Assert.That(result[2].Name, Is.EqualTo("Ammunition3"));
        }

        [Test]
        public void GetSoldiers_ReturnsListOfSoldiers()
        {
            // Arrange
            var soldiers = new List<SoldierAttrb>
    {
        new SoldierAttrb { SoldierAttrbId = 1, Callsign = "Soldier1" },
        new SoldierAttrb { SoldierAttrbId = 2, Callsign = "Soldier2" },
        new SoldierAttrb { SoldierAttrbId = 3, Callsign = "Soldier3" },
    }.AsQueryable();

            this.context.Setup(c => c.Set<SoldierAttrb>()).Returns(MockDbSet(soldiers));

            // Act
            var result = this.bll.GetSoldiers();

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[0].Callsign, Is.EqualTo("Soldier1"));
            Assert.That(result[1].Callsign, Is.EqualTo("Soldier2"));
            Assert.That(result[2].Callsign, Is.EqualTo("Soldier3"));
        }
    }
}
