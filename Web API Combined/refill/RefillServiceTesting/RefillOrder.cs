using System;

namespace RefillServiceTesting
{
    internal class RefillOrder
    {
        public int Id { get; set; }
        public DateTime RefillDate { get; set; }
        public int DrugQuantity { get; set; }
        public bool RefillDelivered { get; set; }
        public bool Payment { get; set; }
        public int SubscriptionId { get; set; }
    }
}