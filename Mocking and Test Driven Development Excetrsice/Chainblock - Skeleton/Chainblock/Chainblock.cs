using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> transactions;

        public Chainblock()
        {
            transactions = new Dictionary<int, ITransaction>();
        }

        public int Count => transactions.Count;

        public void Add(ITransaction tx)
        {
            if (transactions.ContainsKey(tx.Id))
            {
                return;
            }

            transactions.Add(tx.Id, tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!transactions.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            transactions[id].Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            return transactions.ContainsKey(tx.Id);
        }

        public bool Contains(int id)
        {
            return transactions.ContainsKey(id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            List<ITransaction> transactionsList = new List<ITransaction>();
            foreach (var (key, value) in transactions.OrderByDescending(t => t.Value.Amount).ThenBy(t => t.Key))
            {
                transactionsList.Add(value);

            }

            return transactionsList;


        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            List<string> list = new List<string>();
            if (!transactions.Any(t => t.Value.Status == status))
            {
                throw new InvalidOperationException();
            }

            foreach (var (key, value) in transactions.OrderBy(t => t.Value.Amount))
            {
                if (value.Status == status)
                {
                    list.Add(value.From);
                }
               
            }

            return list;
        }

        public ITransaction GetById(int id)
        {
            if (!transactions.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            return transactions[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            if (!transactions.Any(t=>t.Value.From == sender))
            {
                throw new InvalidOperationException();
            }

            List<ITransaction> list = new List<ITransaction>();
            foreach (var (key, value) in transactions.OrderByDescending(t =>t.Value.Amount))
            {
                if (value.From == sender)
                {
                    list.Add(value);
                }
            }

            return list;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            List<ITransaction> transactionsList = new List<ITransaction>();

            bool validStatus = transactions.Any(t => t.Value.Status == status);
            if (!validStatus)
            {
                throw new InvalidOperationException();
            }

            foreach (var (key, value) in transactions.OrderByDescending(t => t.Value.Amount))
            {
                if (value.Status == status)
                {
                    transactionsList.Add(value);
                }
            }

            return transactionsList;
           
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            if (!transactions.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            transactions.Remove(id);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

       
    }
}
