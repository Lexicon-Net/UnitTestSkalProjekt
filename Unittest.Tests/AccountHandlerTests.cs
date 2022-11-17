﻿using Moq;
using UnitTestSkalProjekt;

namespace Unittest.Tests
{
    public class AccountHandlerTests
    {

        [Fact]
        public void GiveDiscount_BasicCustomer()
        {
            // Arrange
            var account = new Account("Test Testberg", 10);
            //var levelChecker = new LevelChecker(); // NEJ
            var mockLevelChecker = new Mock<ILevelChecker>();
            mockLevelChecker.Setup(x => x.CheckLevel(account)).Returns(CustomerLevels.Basic);
            var accountHandler = new AccountHandler(mockLevelChecker.Object);
            var expected = 0;

            // Act
            var actual = accountHandler.GiveDiscount(account);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GiveDiscount_GoldCustomer()
        {
            // Arrange
            var account = new Account("Test Testberg", 60);
            var mockLevelChecker = new Mock<ILevelChecker>();
            mockLevelChecker.Setup(x => x.CheckLevel(account)).Returns(CustomerLevels.Gold);
            var accountHandler = new AccountHandler(mockLevelChecker.Object);
            var expected = 30;

            // Act
            var actual = accountHandler.GiveDiscount(account);

            // Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void HowManyPointsToNextLevel_BasicCustomer()
        {
            // Arrange
            var account = new Account("Test Testberg", 0);
            var mockLevelChecker = new Mock<ILevelChecker>();
            mockLevelChecker.Setup(x => x.CheckLevel(account)).Returns(CustomerLevels.Basic);
            mockLevelChecker.Setup(x => x.Gold).Returns(50);
            var accountHandler = new AccountHandler(mockLevelChecker.Object);
            var expected = 50;

            // Act
            int actual = accountHandler.HowManyPointsToNextLevel(account);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HowManyPointsToNextLevel_GoldCustomer()
        {
            // Arrange
            var account = new Account("Test Testberg", 50);
            var mockLevelChecker = new Mock<ILevelChecker>();
            mockLevelChecker.Setup(x => x.CheckLevel(account)).Returns(CustomerLevels.Gold);
            mockLevelChecker.Setup(x => x.Platinum).Returns(200);
            var accountHandler = new AccountHandler(mockLevelChecker.Object);
            var expected = 150;

            // Act
            int actual = accountHandler.HowManyPointsToNextLevel(account);

            // Assert
            Assert.Equal(expected, actual);
        }


    }
}
