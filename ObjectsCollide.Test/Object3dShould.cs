using System;

using NUnit.Framework;

namespace ObjectsCollide.Test
{
    [TestFixture]
    public class Object3dShould
    {
        private static readonly Cube[] CubesCollided =
{
            new Cube(dimension: 3, x: 5, y: 0, z: 0),
            new Cube(dimension: 3, x: 6, y: 0, z: 0),
            new Cube(dimension: 3, x: 7, y: 0, z: 0),
            new Cube(dimension: 3, x: 8, y: 0, z: 0),
            new Cube(dimension: 3, x: 9, y: 0, z: 0)
        };

        private static readonly Cube[] CubesNotCollided =
{
            new Cube(dimension: 3, x: 1, y: 0, z: 0),
            new Cube(dimension: 3, x: 2, y: 0, z: 0),
            new Cube(dimension: 3, x: 12, y: 0, z: 0),
            new Cube(dimension: 3, x: 13, y: 0, z: 0)
        };

        private Cube _cubeBase;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _cubeBase = new Cube(dimension: 5, x: 7, y: 0, z: 0);
        }

        [Test]
        [Category("CheckingExceptions")]
        public void CollidesWith_IfThatObjectIsNull_ReturnArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _cubeBase.CollidesWith(null));
        }

        [Test]
        [TestCaseSource("CubesCollided")]
        [Category("CheckingCollided")]
        public void CollidesWith_IfThatObjectCollided_ReturnTrue(Cube thatCube)
        {
            bool result = _cubeBase.CollidesWith(thatCube);

            Assert.IsTrue(result);
        }

        [Test]
        [TestCaseSource("CubesNotCollided")]
        [Category("CheckingCollided")]
        public void CollidesWith_IfThatObjectNotCollided_ReturnFalse(Cube thatCube)
        {
            bool result = _cubeBase.CollidesWith(thatCube);

            Assert.IsFalse(result);
        }

        [Test]
        [Category("CheckingExceptions")]
        public void IntersectedVolume_IfThatObjectIsNull_ReturnArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _cubeBase.IntersectedVolume(null));
        }

        [Test]
        [TestCaseSource("CubesCollided")]
        [Category("CheckingCollided")]
        public void IntersectedVolume_IfThatObjectCollided_ReturnValueGreaterThanZero(Cube thatCube)
        {
            double result = _cubeBase.IntersectedVolume(thatCube);

            Assert.Greater(result, 0);
        }

        [Test]
        [TestCaseSource("CubesNotCollided")]
        [Category("CheckingNotCollided")]
        public void IntersectedVolume_IfThatObjectNotCollided_ReturnValueZero(Cube thatCube)
        {
            double result = _cubeBase.IntersectedVolume(thatCube);

            Assert.Zero(result);
        }
    }
}
