namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class PresentsTests
    {
        [Test]

        public void Test_PresentConstuctor()
        {
            Present present = new Present("magic stick", 100);

            Assert.IsNotNull(present);
            Assert.IsInstanceOf(typeof(Present), present);
            Assert.AreEqual("magic stick", present.Name);
            Assert.AreEqual(100, present.Magic);

        }

        [Test]

        public void Test_Constructor_BagAndTestMethodGetPresents()
        {
            Bag bag = new Bag();

            Assert.IsNotNull(bag);
            Assert.IsInstanceOf(typeof(Bag), bag);
            var presents = bag.GetPresents();

            Assert.IsNotNull(presents);
            Assert.AreEqual(0, presents.Count);
        }

        [Test]

        public void Test_Positive_CreateMethodShouldShouldAddPresentToColleection()
        {
            Bag bag = new Bag();

            Present present = new Present("magic stick", 100);
            string result = bag.Create(present);
            var presents = bag.GetPresents();
            Assert.AreEqual(1, presents.Count);
            CollectionAssert.Contains(presents, present);

            Assert.AreEqual($"Successfully added present {present.Name}.", result);

        }

        [Test]

        public void Negative_ThrowArgumentNullException_WhenPresentToCreateIsNUll()
        {
            Bag bag = new Bag();
            Present present = null;

            Assert.Throws<ArgumentNullException>(
                () => bag.Create(present)


                );

        }
        [Test]

        public void Negative_ThrowInvalidOperationException_WhenPresentAlreadyExistIncollection()
        {
            Bag bag = new Bag();
            Present present = new Present("magic stick", 100);
            bag.Create(present);

            Assert.Throws<InvalidOperationException>(
                () => bag.Create(present)


                );

        }

        [Test]
        public void PositiveTest_RemoveMethodShouldRemovePresentFromTheCOllection()
        {
            Bag bag = new Bag();

            Present present = new Present("magic stick", 100);
            bag.Create(present);
            var presents = bag.GetPresents();
            Assert.IsTrue(bag.Remove(present));
            Assert.AreEqual(0, presents.Count);

        }
        [Test]
        public void NegativeTest_RemoveMethodShouldnntRemovePresentFromTheCOllection_BecausePresentIsMissingInCollection()
        {
            Bag bag = new Bag();

            Present present = new Present("magic stick", 100);
            Present present2 = new Present("MagicCircle", 200);
            bag.Create(present);
            var presents = bag.GetPresents();
            Assert.IsFalse(bag.Remove(present2));
            Assert.AreEqual(1, presents.Count);

        }
        [Test]
        public void Positive_MustReturnPresentWithLeastMagic()
        {
            Bag bag = new Bag();

            Present present = new Present("magic stick", 200);
            Present present2 = new Present("MagicCircle", 100);
            bag.Create(present);
            bag.Create(present2);

            var presentLeastMagic =  bag.GetPresentWithLeastMagic();
            var result = bag.GetPresentWithLeastMagic();

            Assert.AreSame(present2, presentLeastMagic);
            Assert.AreEqual(present2, presentLeastMagic);
            Assert.That(result.Name == present2.Name && result.Magic == present2.Magic);

        }
        //[Test]
        //public void Negative_MustReturnPresentWithLeastMagic_ButCollectionIsEmpty()
        //{
        //    Bag bag = new Bag();

        //    Present present = new Present("magic stick", 200);
        //    Present present2 = new Present("MagicCircle", 100);
            

            
        //    var result = bag.GetPresentWithLeastMagic();

            
        //    Assert.IsNull(result);

        //}
        [Test]

        public void Positive_ShouldReturnPresentWithGivenName()
        {
            Bag bag = new Bag();

            Present present = new Present("magic stick", 200);
            Present present2 = new Present("MagicCircle", 100);
            bag.Create(present);
            bag.Create(present2);

            var result = bag.GetPresent("MagicCircle");

            Assert.AreEqual(100, result.Magic);
            Assert.AreEqual("MagicCircle", result.Name);

            Assert.AreEqual(present2, result);


        }
        [Test]

        public void Negative_ShouldReturnPresentWithGivenName_ButNull_CauseMissingPresentWithGivenName()
        {
            Bag bag = new Bag();

            Present present = new Present("magic stick", 200);
            Present present2 = new Present("MagicCircle", 100);
            bag.Create(present);
            bag.Create(present2);

            var result = bag.GetPresent("jhjhh");
            Assert
                .IsNull(result);


        }

    }
}
