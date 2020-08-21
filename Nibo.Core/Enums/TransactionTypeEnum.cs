using System.ComponentModel;

namespace Nibo.Core.Enums
{
    public enum TransactionTypeEnum
    {
        [Description("Débito")]
        DEBIT,
        [Description("Crédito")]
        CREDIT
    }
}
