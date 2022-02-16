namespace CleanArchMvc.Application.Transactions.Commands
{
    public class TransactionUpdateCommand : TransactionCommand
    {
        public string Sku { get; set; }
    }
}
