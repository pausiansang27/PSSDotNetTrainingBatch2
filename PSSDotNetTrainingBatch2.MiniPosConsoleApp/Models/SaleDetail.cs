using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSSDotNetTrainingBatch2.MiniPosConsoleApp.Models
{
    [Table("Tbl_SaleDetail")]
    public class SaleDetail
    {
        [Key]
        [Column("SaleDetailId")]
        public int SaleDetailId { get; set; }

        [ForeignKey(nameof(Sale))]
        [Column("SaleId")]
        public int SaleId { get; set; }

        [ForeignKey(nameof(Product))]
        [Column("ProductId")]
        public int ProductId { get; set; }

        [Column("Price")]
        public decimal Price { get; set; }

        [Column("Quantity")]
        public int Quantity { get; set; }

        [Column("DeleteFlag")]
        public bool DeleteFlag { get; set; }
    }
}
