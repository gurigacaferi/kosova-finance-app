using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATK_Business_API.Models
{
    [Table("business_ledger", Schema = "public")]
    public class BusinessLedger
    {
        [Key]
        [Column("ledger_id")]
        public int LedgerId { get; set; }

        [Column("transaction_date")]
        public DateTime TransactionDate { get; set; }

        [Column("transaction_type")]
        public string TransactionType { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("category")]
        public string? Category { get; set; }

        [Column("amount")]
        public decimal Amount { get; set; }
    }
}
