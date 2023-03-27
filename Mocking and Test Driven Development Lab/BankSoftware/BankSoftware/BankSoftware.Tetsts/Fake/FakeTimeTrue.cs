using BankSoftware.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSoftware.Tetsts.Fake
{
    public class FakeTimeTrue : ITimeHelper
    {
        public bool ShouldGetCommissiom()
        {
            return true;
        }
    }
}
