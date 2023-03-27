using BankSoftware.Contracts;
using BankSoftware.Tetsts.Fake;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BankSoftware.Tetsts
{
    public class BankTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Transfer_Money_Should_Work()
        {
            //Arrange

            Mock<IAccount> accountMock = new Mock<IAccount>();

            accountMock.Setup(a => a.Amount).Returns(100);

            User user = new User()   
            {
                Name = "Pesho",

                Account = accountMock.Object
               
                
            
             
            };

            User user2 = new User()
            {
                Name = "Gosho",

                Account = accountMock.Object
               


            };


            Mock<ITimeHelper> timeMock = new Mock<ITimeHelper>();
            //timeMock.Setup(t => t.ShouldGetCommissiom()).Returns(true);
             
            Mock<IBankDb> bankDbMock = new Mock<IBankDb>();
            bankDbMock.Setup(db => db.ReadUsers()).Returns(new List<User>());

            

            IBankDb FakebankTextDb = new FakeDb();
            ITimeHelper timeTrue = new FakeTimeTrue();
            Bank bank = new Bank(bankDbMock.Object, timeMock.Object);

            bank.AddUser(user);
            bank.AddUser(user2);

            //ACT

            bank.TransferMoney(user.Name, user2.Name, 50);
            user.Account.WithdrawMoney(1);
            user2.Account.WithdrawMoney(1);

            //ASSERT

            Assert.AreEqual(49, user.Account.Amount);
            Assert.AreEqual(149, user2.Account.Amount);



        }
    }
}