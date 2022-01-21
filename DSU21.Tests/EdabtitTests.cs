using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DSU21.Helpers;
namespace DSU21.Tests
{
    [TestFixture]
    class EdabtitTests
    {
        [Test]
        public static void TestAllergiesClass()
        {
            var solo = new Allergies("Solo");
            var dimitri = new Allergies("Dimitri", "Cats Eggs Tomatoes");
            var sally = new Allergies("Sally", (int)(Allergies.Allergen.Pollen | Allergies.Allergen.Shellfish));
            var sniffy = new Allergies("Sniffy", 255);

            var test = 1;
            Assert.AreEqual(solo.ToString(), "Solo has no allergies!", string.Format("Test {0} failed!", test++));
            solo.AddAllergy(Allergies.Allergen.Eggs);
            Assert.AreEqual(solo.ToString(), "Solo is allergic to Eggs.", string.Format("Test {0} failed!", test++));
            Assert.AreEqual(solo.Score, 1, string.Format("Test {0} failed!", test++));
            Assert.AreEqual(dimitri.ToString(), "Dimitri is allergic to Eggs, Tomatoes and Cats.", string.Format("Test {0} failed!", test++));
            Assert.AreEqual(dimitri.IsAllergicTo("Cats"), true, string.Format("Test {0} failed!", test++));
            Assert.AreEqual(dimitri.Score, 145, string.Format("Test {0} failed!", test++));
            dimitri.DeleteAllergy("Tomatoes");
            dimitri.DeleteAllergy(Allergies.Allergen.Cats);
            dimitri.AddAllergy(Allergies.Allergen.Strawberries);
            Assert.AreEqual(dimitri.Score, 9, string.Format("Test {0} failed!", test++));
            Assert.AreEqual(sally.ToString(), "Sally is allergic to Shellfish and Pollen.", string.Format("Test {0} failed!", test++));
            Assert.AreEqual(sally.IsAllergicTo("Cats"), false, string.Format("Test {0} failed!", test++));
            Assert.AreEqual(sally.Score, 68, string.Format("Test {0} failed!", test++));
            sally.AddAllergy("Tomatoes");
            Assert.AreEqual(sally.Score, 84, string.Format("Test {0} failed!", test++));
            Assert.AreEqual(sally.IsAllergicTo(Allergies.Allergen.Tomatoes), true, string.Format("Test {0} failed!", test++));
            Assert.AreEqual(sniffy.Score, 255, string.Format("Test {0} failed!", test++));
            Assert.AreEqual(sniffy.ToString(), "Sniffy is allergic to Eggs, Peanuts, Shellfish, Strawberries, Tomatoes, Chocolate, Pollen and Cats.", string.Format("Test {0} failed!", test++));
        }
    }
}
