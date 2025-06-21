using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSSDotNetTrainingBatch2.MiniPosConsoleApp.Models
{
    [Table("Tbl_Product")]
    public class Product
    {
        [Key]
        [Column("ProductId")]
        public int ProductId { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Price")]
        public decimal Price { get; set; }

        [Column("Quantity")]
        public int Quantity { get; set; }

        [Column("DeleteFlag")]
        public bool DeleteFlag { get; set; }
    }
}
