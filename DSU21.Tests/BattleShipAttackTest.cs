using NUnit.Framework;
using DSU21.Helpers;
using System.Drawing;

namespace DSU21.Tests
{
    [TestFixture]
    public class BattleShipAttackTests
    {
        private Ship _ship;
       [SetUp]
        public void Setup()
        {
            // Arrange
            Point point = new Point(3, 3);

            _ship = new Ship(point, Direction.Horizontal);
        }

        [TestCase(3,3, ExpectedResult =Result.Hit)]
        [TestCase(3,4, ExpectedResult =Result.Hit)]
        [TestCase(3,5, ExpectedResult =Result.Hit)]
        [TestCase(3,6, ExpectedResult =Result.Sunk)]
        public Result ShipUnderAttack_ShouldReturnHitAndSunk(int x, int y)
        {
            // Act
            var point = new Point(x, y);

            // Assert
            return _ship.UnderAttack(point);
        }

        [Test]
        public void ShipIsPlacedInBattlefiled()
        {
            // Assert
            Assert.That(_ship.StartLocation.X, Is.InRange(1, 10));
            Assert.That(_ship.StartLocation.Y, Is.InRange(1, 10));

            Assert.That(_ship.Type, Has.Length.EqualTo(9));

            Assert.That(_ship, Is.InstanceOf(typeof(Ship)));
        }
    }
}