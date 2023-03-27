using BankSoftware.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSoftware.Tetsts.Fake
{
    internal class FakeTimeFalse : ITimeHelper
    {
        public bool ShouldGetCommissiom()
        {
            return false;
        }
    }
}
