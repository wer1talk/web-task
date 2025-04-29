namespace WebTask.Models
{
    public class Debt
    {
        public int Id { get; set; }
        public int RPersonId { get; set; }
        public string ContractNumber { get; set; } = null!; // можно избежать ошибки с NULL через !
        public string ContractDt { get; set; } = null!;
        public string DebtSum { get; set; } = null!;
    }
}