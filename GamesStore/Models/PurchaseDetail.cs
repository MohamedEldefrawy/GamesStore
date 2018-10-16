namespace GamesStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PurchaseDetail
    {
        public int ID { get; set; }

        public int GameID { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Quantity { get; set; }

        public decimal Total { get; set; }

        public int PurchaseID { get; set; }

        public virtual Game Game { get; set; }

        public virtual Purchase Purchase { get; set; }
    }
}
