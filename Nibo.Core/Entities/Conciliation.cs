using Nibo.Core.Enums;
using System;

namespace Nibo.Core
{
    public class Conciliation
    {
        public long Id { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public DateTime DatePosted { get; set; }
        public double TransactionAmount { get; set; }
        public string TransactionDescription { get; set; }
    }
}
