namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [TestCaseSource("TestCaseSourceVBalidDataPassed")]
        public void Test_ConstructorValidDataPassed_Positive
            (
            //ARRANGE
            Person [] persons,
            int expectedCount
            )
        {
            //ACT
            Database data = new Database(persons);
            //ASSERT
            Assert.AreEqual(expectedCount, data.Count);


        }

        public static IEnumerable<TestCaseData> TestCaseSourceVBalidDataPassed()
        {
            //ARRANGE
            yield return new TestCaseData(
                new Person []
                {
                    new Person(87, "Boris"),
                    new Person(91, "Suzi"),
                    new Person(53, "Gabi")

                },
                3);
            yield return new TestCaseData(
                new Person[]
                {
                },
                0);
        }



        //[Test]

        //public void Test_ConstructorValidDataPassed_Positive()
        //{
                //ARRANGE
        //    Person person1 = new Person(87, "Boris");
        //    Person person2 = new Person(91, "Suzi");
        //    Person person3 = new Person(53, "Gabi");

        //    Person[] persons = new Person[] { person1, person2, person3 }; 
                 //ACT
        //    Database data = new Database (persons);
                  //ASSERT
        //    Assert.AreEqual (3, data.Count);


        //}







        [Test]

        public void Test_ThrowExceptionAddRangeMoreThan16DataLenght()
        {



            Person[] persons = new Person[] 
            {
                 new Person(1, "Boris1"),
            new Person(2, "Suzi2"),
            new Person(3, "Gabi3"),
            new Person(4, "Ga5bi4"),
            new Person(5, "Gabi65"),
            new Person(6, "Ga1bi6"),
            new Person(7, "Gab23i7"),
            new Person(8, "Gab97i8"),
            new Person(9, "Ga4b23i9"),
            new Person(10, "Gab48i10"),
            new Person(11, "Gab69i11"),
            new Person(12, "Ga4bi12"),
            new Person(13, "Ga1bi13"),
            new Person(14, "G7abi14"),
            new Person(15, "Gghabi15"),
            new Person(16, "Gabnli16"),
            new Person(17, "Tos63ho17")


            };

            Assert.Throws<ArgumentException>(
                ()=>
                {
                    Database data = new Database(persons);

                }
                
                );           


        }

        [Test]

        public void Test_ThrowExceptionWhenAddPersonToPersonsWhenLenghtIs16()
        {

            Person[] persons = new Person[] 
            {
                new Person(1, "Boris1"),
            new Person(2, "Suzi2"),
            new Person(3, "Gabi3"),
            new Person(4, "Ga5bi4"),
            new Person(5, "Gabi65"),
            new Person(6, "Ga1bi6"),
            new Person(7, "Gab23i7"),
            new Person(8, "Gab97i8"),
            new Person(9, "Ga4b23i9"),
            new Person(10, "Gab48i10"),
            new Person(11, "Gab69i11"),
            new Person(12, "Ga4bi12"),
            new Person(13, "Ga1bi13"),
            new Person(14, "G7abi14"),
            new Person(15, "Gghabi15"),
            new Person(16, "Gabnli16")
             };

           
            Database data = new Database(persons);

            Assert.Throws<InvalidOperationException>(
                ()=>
                {
                    data.Add(new Person(17, "Tos63ho17"));

                }
                );

        }
        [Test]

        public void Test_AddUserNameAlreadyExist()
        {
            
            Database data = new Database(new Person[] { new Person(1, "Pesho") });

            Assert.Throws<InvalidOperationException>(
                () => data.Add(new Person(2, "Pesho"))

                );
        }
        [Test]

        public void Test_AddIdAlreadyExist()
        {

            Database data = new Database(new Person[] { new Person(1, "Pesho") });

            Assert.Throws<InvalidOperationException>(
                () => data.Add(new Person(1, "Pesho2"))

                );
        }

        [Test]

        public void Test_RemoveWhenIsEmpty()
        {
            Database data = new Database(new Person [0]);

            Assert.Throws<InvalidOperationException>(
                () => data.Remove()
                ); ;

        }

        [Test]
        public void Test_RemoveShouldRemove()
        {
            Person pesho = new Person(1, "Pesho");

            Database data = new Database(pesho);

           

            data.Remove();

            Assert.AreEqual(0, data.Count);  


        }

        [TestCaseSource("TestCaseSourceFindUserNameButIsNullOrEmpty")]

        public void Test_FindUserNameButIsNullOrEmptyWithTestCaseSource(
            Person[] persons,
            string expectedName)
        {

            Database data = new Database(persons);

            Assert.Throws<ArgumentNullException>(
                () => data.FindByUsername(expectedName)
                );

        }
        public static IEnumerable<TestCaseData> TestCaseSourceFindUserNameButIsNullOrEmpty()
        {
            //ARRANGE
            yield return new TestCaseData
                (
                new Person[] 
                {
                    new Person(1, "Pesho")
                }
                ,
                null);
            yield return new TestCaseData
                (
                new Person[]
                {
                    new Person(1, "Pesho")
                }
                ,
                "");
        }

        [Test]

        public void Test_FindUserNameButIsNullOrEmpty()
        {

            Database data = new Database(new Person[] { new Person(1, "Pesho") });

            Assert.Throws<ArgumentNullException>(
                () => data.FindByUsername("")
                
                
                );
            Assert.Throws<ArgumentNullException>(
                () => data.FindByUsername(null)


                );

        }

        [Test]

        public void Test_ThrowExcWhenNotFoundUserName()
        {
            Database data = new Database(new Person[] { new Person(1, "Pesho") });

            Assert.Throws<InvalidOperationException>(
                () => data.FindByUsername("pe")

                );
        }

        [Test]

        public void Test_ThrowExcWhenNotFoundUserNameLettersSensitive()
        {
            Database data = new Database(new Person[] { new Person(1, "Pesho") });

            Assert.Throws<InvalidOperationException>(
                () => data.FindByUsername("pesho")

                );
        }

        [Test]

        public void Test_FindByIdButIdIsNegativeThrowsExc()
        {
            Database data = new Database(new Person[] { new Person(1, "Pesho") });

            Assert.Throws<ArgumentOutOfRangeException>(
                
                () => data.FindById(-1)
                
                
                );

        }

        [Test]

        public void Test_ThrowExcWhenNotFoundId()
        {
            Database data = new Database(new Person[] { new Person(1, "Pesho") });

            Assert.Throws<InvalidOperationException>(
                () => data.FindById(4)

                );
        }


        [Test]

        public void Test_FoundId_Positive()
        {
            Person pesho =  new Person(1, "Pesho");

            Database data = new Database(pesho);
            var expexted = pesho;

            var actual = data.FindById(1);

            Assert.AreEqual(expexted, actual );


        }
        [Test]

        public void Test_FoundUserName_Positive()
        {
            Person pesho = new Person(1, "Pesho");

            Database data = new Database(pesho);
            var expexted = pesho;

            var actual = data.FindByUsername("Pesho");

            Assert.AreEqual(expexted, actual);


        }

    }
}