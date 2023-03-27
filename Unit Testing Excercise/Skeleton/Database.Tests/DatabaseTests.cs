namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(
            new int[0],
            new[] { 1, 2, 6, 9 },
            4
            )]
        public void Test_Constructor_ValidDataAndValidCount(
            int[] parameters,
            int[] toAdd,
            int expectedCount)
        {
            Database data = new Database(parameters);
            for (int i = 0; i < toAdd.Length; i++)
            {
                data.Add(toAdd[i]);
            }

            Assert.AreEqual(expectedCount, data.Count);

        }


        [Test]
        public void Test_Count()
        {
            Database data = new Database(new int[16]);

            Assert.AreEqual(16, data.Count);

        }


        [TestCase
            (new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]



        public void Test_Exactly16(int[] parameters)
        {
            Database data = new Database(parameters);

            if (data.Count < 16 || data.Count > 16)
            {
                throw new InvalidOperationException("Array's capacity must be exactly 16 integers!");
            }
        }

        [Test]
        public void Test_ToAdd17Element()
        {
            Database data = new Database(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

            Assert.Throws<InvalidOperationException>(
                () => data.Add(17)
                );
        }

        [TestCase(
            new[] { 1, 2, 4},
            
            2

            )]
        public void Test_RemoveLastElement_Positive(
            int[] parameters,
            int expectedCountDecrease
            )
        {
            Database data = new Database(parameters);

            data.Remove();

            Assert.AreEqual(expectedCountDecrease, data.Count);

        }
        [TestCase (
            new int[0]
            
            )]
        public void Test_Remove_Negative(int[] parameters)
        {

            Database data = new Database(parameters);

            Assert.Throws<InvalidOperationException>(
                () =>
                data.Remove()

                ); ;

        }
        [TestCase(
            new[] {1, 2, 3 }
          
            )]
        public void Test_Fetche(int[] parameters)
        {
            Database data = new Database(parameters);

           int[] copppyData =  data.Fetch();

            CollectionAssert.AreEqual(parameters, copppyData);
        }

    }
}
