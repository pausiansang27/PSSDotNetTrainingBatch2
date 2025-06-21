using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSSDotNetTrainingBatch2.MiniPosConsoleApp.Models
{
    [Table("Tbl_Sale")]
    public class Sale
    {
        [Key]
        [Column("SaleId")]
        public int SaleId { get; set; }

        [Column("SaleDate")]
        public DateTime SaleDate { get; set; }

        [Column("VoucherNo")]
        public string VoucherNo { get; set; }

        [Column("TotalAmount")]
        public decimal TotalAmount { get; set; }

        [Column("DeleteFlag")]
        public bool DeleteFlag { get; set; }
    }
}
