using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock.Tests
{
    public class ChainblockTests
    {
        private ITransaction transaction;
        private IChainblock chainblock;


        [SetUp]
        public void Setup()
        {
            transaction = new Transaction()
            {
                Id = 1,
                Status = TransactionStatus.Successfull,
                From = "Stoyan",
                To = "Kiro",
                Amount = 250
            };

            chainblock = new Chainblock();
            chainblock.Add(transaction);


        }


        [Test]

        public void Test_AddMethos_ShouldAddTransaction_IsValidData()
        {
           

            chainblock.Add(transaction);

            Assert.True(chainblock.Contains(transaction));
            Assert.AreEqual(1, chainblock.Count);

        }
        [Test]

        public void Test_CheckContainsIdWorks()
        {
            Assert.IsTrue(chainblock.Contains(1));
            Assert.IsFalse(chainblock.Contains(5));

        }
        [Test]
        public void Test_Positive_Change_TrxStatus()
        {
            chainblock.ChangeTransactionStatus(1, TransactionStatus.Failed);

            Assert.IsTrue(transaction.Status == TransactionStatus.Failed);
        }
        [Test]

        public void Test_Negative_ThrowExc_When_IdDoesntExist()
        {
            chainblock.RemoveTransactionById(1);
            Assert.Throws<InvalidOperationException>(
                () => chainblock.ChangeTransactionStatus(1,TransactionStatus.Failed )
                );
        }
        [Test]
        public void Test_Positive_ShouldRemoveTransactionById()
        {

            chainblock.RemoveTransactionById(1);

            Assert.AreEqual(0, chainblock.Count);

            Assert.IsFalse(chainblock.Contains(transaction));

        }

        [Test]
        public void Test_Negative_ThrowExc_RemoveNotExicstId()
        {
            chainblock.RemoveTransactionById(1);
            Assert.Throws<InvalidOperationException>(
                () => chainblock.RemoveTransactionById(1)

                ) ;

        }

        [Test]

        public void TEst_Positive_GetTrxById()
        {
           ITransaction trx =  chainblock.GetById(1);
            Assert.AreEqual(transaction, trx);
            Assert.AreEqual(1, trx.Id);

        }
        [Test]
        public void Test_Negative_GetTrxById()
        {
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetById(2)
                
                );

        }

        [Test]

        public void Test_Postivie_GetByTransactionStatus_ReturnAllTrxWithStatus()
        {
            List<ITransaction> transaxtionsTaked = new List<ITransaction>();

           ITransaction transaction2 = new Transaction()
            {
                Id = 5,
                Status = TransactionStatus.Aborted,
                From = "Tosho",
                To = "Pepo",
                Amount = 600
            };
            ITransaction transaction3 = new Transaction()
            {
                Id = 30,
                Status = TransactionStatus.Successfull,
                From = "Tino",
                To = "Dimi",
                Amount = 300
            };

            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            transaxtionsTaked = chainblock.GetByTransactionStatus(TransactionStatus.Successfull).ToList();

            Assert.AreEqual(2, transaxtionsTaked.Count);

            Assert.AreEqual(300, transaxtionsTaked[0].Amount);

        }
        [Test]
        public void Test_Negative_GetByTransactionStatus_ReturnAllTrxWithStatus()
        {

            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetByTransactionStatus(TransactionStatus.Aborted)
                );
        }

        [Test]

        public void Test_Positive_GetAllSendersWithTransactionStatus()
        {
            ITransaction transaction2 = new Transaction()
            {
                Id = 5,
                Status = TransactionStatus.Aborted,
                From = "Tosho",
                To = "Pepo",
                Amount = 600
            };
            ITransaction transaction3 = new Transaction()
            {
                Id = 10,
                Status = TransactionStatus.Aborted,
                From = "Tosho",
                To = "Pepo",
                Amount = 630
            };

            ITransaction transaction4 = new Transaction()
            {
                Id = 12,
                Status = TransactionStatus.Aborted,
                From = "Gosho",
                To = "Pepo",
                Amount = 650
            };

            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            List<string> senders = new List<string>();

            senders = chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Aborted).ToList();

            Assert.AreEqual(3, senders.Count);

            Assert.IsTrue(senders.Contains(transaction2.From));
            int count = 0;

            foreach (var item in senders)
            {
                if (item == "Tosho")
                {
                    count++;
                }
            }
            Assert.AreEqual(2, count);
            Assert.AreEqual("Gosho", senders[2] );
            
        }

        [Test]

        public void Test_Negative_GetAllSendersWithTransactionStatus()
        {
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Aborted)
                
                );
        
        }
        [Test]

        public void Test_Positive_ShouldGetAllOrderedByAmountDescendingThenById()
        {
            ITransaction transaction2 = new Transaction()
            {
                Id = 5,
                Status = TransactionStatus.Aborted,
                From = "Tosho",
                To = "Pepo",
                Amount = 300
            };
            ITransaction transaction3 = new Transaction()
            {
                Id = 14,
                Status = TransactionStatus.Aborted,
                From = "Gosho",
                To = "Dido",
                Amount = 200
            };
            ITransaction transaction4 = new Transaction()
            {
                Id = 10,
                Status = TransactionStatus.Aborted,
                From = "Mimi",
                To = "Kati",
                Amount = 200
            };

            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);

            List<ITransaction> transactions = new List<ITransaction>();

            transactions =  chainblock.GetAllOrderedByAmountDescendingThenById().ToList();

            Assert.AreEqual(4, transactions.Count);
            Assert.AreEqual(transaction2 ,transactions[0]);
            Assert.AreEqual(transaction ,transactions[1]);
            Assert.AreEqual(transaction4 ,transactions[2]);

        }

        [Test]
        public void Test_Pos_Should_GetBySenderOrderedByAmountDescending()
        {
            List<ITransaction> list = new List<ITransaction>();
            ITransaction transaction3 = new Transaction()
            {
                Id = 30,
                Status = TransactionStatus.Successfull,
                From = "Tino",
                To = "Dimi",
                Amount = 200
            };
            ITransaction transaction4 = new Transaction()
            {
                Id = 10,
                Status = TransactionStatus.Aborted,
                From = "Tino",
                To = "Kati",
                Amount = 300
            };
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);

            list = chainblock.GetBySenderOrderedByAmountDescending("Tino").ToList();

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(300, list[0].Amount);

        }
        [Test]

        public void Test_Negative_ThrowExc_WhenSenderIsNotFound()
        {
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetBySenderOrderedByAmountDescending("Tino")                
                );
        }




    }
}
