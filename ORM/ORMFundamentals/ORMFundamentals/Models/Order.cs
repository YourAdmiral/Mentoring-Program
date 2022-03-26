using System;
using System.Collections.Generic;
using System.Text;

namespace ORMFundamentals.Models
{
    public enum OrderStatus
    {
        NotStarted, 
        Loading, 
        InProgress, 
        Arrived, 
        Unloading, 
        Cancelled, 
        Done
    }

    public class Order
    {
        public int Id { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
