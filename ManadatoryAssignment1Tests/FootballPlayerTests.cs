using Microsoft.VisualStudio.TestTools.UnitTesting;
using ManadatoryAssignment1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManadatoryAssignment1.Tests
{
    [TestClass()]
    public class FootballPlayerTests
    {
        private FootballPlayer correctFootballPlayer = new FootballPlayer() {Id = 1, Name = "Frederik", Age = 23, ShirtNumber = 12};
        private FootballPlayer blankName = new FootballPlayer() {Id = 2, Name = "    ", Age = 23, ShirtNumber = 12};
        private FootballPlayer nullName = new FootballPlayer() {Id = 3, Age = 23, ShirtNumber = 12};
        private FootballPlayer playerTooYoung = new FootballPlayer() {Id = 5, Name = "Frederik", Age = 1, ShirtNumber = 12};
        private FootballPlayer shirtTooLow = new FootballPlayer() {Id = 7, Name = "Frederik", Age = 23, ShirtNumber = 0};
        private FootballPlayer shirtLowerLimit = new FootballPlayer() {Id = 8, Name = "Frederik", Age = 23, ShirtNumber = 1};
        private FootballPlayer shirtUpperLimit = new FootballPlayer() {Id = 9, Name = "Frederik", Age = 23, ShirtNumber = 99};
        private FootballPlayer shirtTooHigh = new FootballPlayer() {Id = 10, Name = "Frederik", Age = 23, ShirtNumber = 100};
        private FootballPlayer tooShortName = new FootballPlayer() { Id = 11, Name = "a", Age = 23, ShirtNumber = 12 };
        private FootballPlayer nameLimit = new FootballPlayer() { Id = 12, Name = "Bo", Age = 23, ShirtNumber = 12 };
        private FootballPlayer ageLimit = new FootballPlayer() { Id = 13, Name = "Bo", Age = 2, ShirtNumber = 12 };


        [TestMethod()]
        public void ValidateTest()
        {
            correctFootballPlayer.Validate();
            ValidateAgeTest();
            ValidateNameTest();
            ValidateShirtNumberTest();
        }

        [TestMethod()]
        public void ValidateNameTest()
        {
            Assert.AreEqual("Frederik", correctFootballPlayer.Name);
            Assert.ThrowsException<ArgumentNullException>(() => nullName.ValidateName());
            Assert.ThrowsException<ArgumentException>(() => blankName.ValidateName()); 
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => tooShortName.ValidateName()); 
            nameLimit.ValidateName();
        }

        [TestMethod()]
        public void ValidateAgeTest()
        {
            correctFootballPlayer.ValidateAge();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => playerTooYoung.ValidateAge());
            ageLimit.ValidateAge();
            
        }

        [TestMethod()]
        public void ValidateShirtNumberTest()
        {
            correctFootballPlayer.ValidateShirtNumber();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => shirtTooLow.ValidateShirtNumber());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => shirtTooHigh.ValidateShirtNumber());
            shirtLowerLimit.ValidateShirtNumber();
            shirtUpperLimit.ValidateShirtNumber();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("Id: 1, Name: Frederik, Age: 23, ShirtNumber: 12", correctFootballPlayer.ToString());
        }
    }
}