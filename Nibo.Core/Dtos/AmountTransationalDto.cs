using Nibo.Core.Enums;
using System;

namespace Nibo.Core.Dtos
{
    public class AmountTransationalDto
    {
        public TransactionTypeEnum TransactionType { get; set; }
        public DateTime DatePosted { get; set; }
        public double TransactionAmount { get; set; }
        public string OperationDescription { get; set; }
        public string TransactionTypeDescription { get; set; }
    }
}
