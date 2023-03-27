using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {


        [TestCaseSource("SourceDataForConstrucyor")]

        public void Test_Positive_Constructor_ValidData
            (
            string gymName,
            Gym gym,
            int gymCapacity,
            int gymCount)
        {


            Assert.AreEqual(gymName, gym.Name);
            Assert.AreEqual(gymCapacity, gym.Capacity);
            Assert.AreEqual(gymCount, gym.Count);

        }

        public static IEnumerable<TestCaseData> SourceDataForConstrucyor()
        {
            yield return new TestCaseData
                (

                    "Rocky",
                     new Gym("Rocky", 30),
                     30,
                     0
                );
            yield return new TestCaseData
                (

                    "Energy",
                     new Gym("Energy", 25),
                     25,
                     0
                );
            yield return new TestCaseData
            (

                "Energy",
                 new Gym("Energy", 0),
                 0,
                 0
            );


        }

        [TestCase(null)]
        [TestCase("")]

        public void Test_Negative_ThrowExc_NameIs_Null_Empty(string gymName)
        {
            Assert.Throws<ArgumentNullException>
                (

                    () => new Gym(gymName, 30),
                    "Invalid gym name."

                );


        }

        [Test]

        public void Test_Negative_ThrowExc_Capacity_IsLessThan0()
        {
            Assert.Throws<ArgumentException>(

                () => new Gym("Rocky", -1),
                "Invalid gym capacity."

                );

        }
        [Test]

        public void Test_Positive_AddAthleteToGym()
        {

            Athlete athlete = new Athlete("jean");
            Athlete athlete2 = new Athlete("perre");

            Gym gym = new Gym("Rocky", 20);

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);


            Assert.AreEqual(2, gym.Count);
        }

        [Test]

        public void Test_Negative_ThrowExc_DoesNotAddAthleteToGym_CapacityIEqualToGymAthletesCount()
        {
            Gym gym = new Gym("Rocky", 2);

            Athlete athlete = new Athlete("jean");
            Athlete athlete2 = new Athlete("pierre");

            Athlete athlete3 = new Athlete("Pinko");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(
                () => gym.AddAthlete(athlete3),
                "The gym is full."

                );
        }

        [Test]
        public void Test_Positive_RemoveAthleteFromGym()
        {
            Gym gym = new Gym("Rocky", 2);

            Athlete athlete = new Athlete("jean");
            Athlete athlete2 = new Athlete("pierre");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.AreEqual(2, gym.Count);

            gym.RemoveAthlete("jean");

            Assert.That(gym.Count == 1);

            


        }

        [Test]

        public void Test_Negative_RemoveAthleteFromGym_ThrowExc_fullNameDoesntExistInGym()
        {
            Gym gym = new Gym("Rocky", 2);
            Athlete athlete = new Athlete("jean");
            gym.AddAthlete(athlete);
            string fullName = "Pinko";
            Assert.Throws<InvalidOperationException>(
                () => gym.RemoveAthlete(fullName),
               String.Format("The athlete {0} doesn't exist.", fullName)

                );
        }

        [Test]

        public void Test_Positive_InjureAthlete_MustChangeStatusByFullName()
        {
            Gym gym = new Gym("Rocky", 2);
            Athlete athlete = new Athlete("jean");
            Athlete athlete2 = new Athlete("pierre");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            var injuredathlete = gym.InjureAthlete("jean");


            Assert.That(injuredathlete.IsInjured == true);
            Assert.IsTrue(athlete.IsInjured == true);
            Assert.IsTrue(athlete2.IsInjured == false);


        }
        [Test]
        public void Test_Negative_InjureAthlete_FullNameIsNull_ThrowExc()
        {
            Gym gym = new Gym("Rocky", 2);
            Athlete athlete = new Athlete("jean");
            Athlete athlete2 = new Athlete("pierre");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);
            string fullName = "Pinko";
            Assert.Throws<InvalidOperationException>(
                () => gym.InjureAthlete(fullName),
                String.Format("The athlete {0} doesn't exist.",fullName )

                );

        }

        [Test]
        public void PostiveTest_ShouldReturnReport_OnlyAthletersNotInjured()
        {
            Gym gym = new Gym("Rocky", 3);
            Athlete athlete = new Athlete("jean");
            Athlete athlete2 = new Athlete("pierre");
            Athlete athlete3 = new Athlete("Pinko");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);

            gym.InjureAthlete("Pinko");


            string report =  gym.Report();

            Assert.IsTrue(report.Contains("jean"));
            Assert.IsFalse(report.Contains("Pinko"));
            Assert.IsTrue(report.Contains("pierre"));

        }
    }
}
