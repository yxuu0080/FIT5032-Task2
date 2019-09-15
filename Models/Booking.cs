namespace FIT5032_Task2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        public int CustomerId { get; set; }

        public int HotelId { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public int Amount { get; set; }

        public int BookingId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
