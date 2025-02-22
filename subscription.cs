using System;
using System.Collections.Generic;

namespace Club_manager
{
    internal class Subscription
    {
        // Properties
        public int SubscriptionId { get; private set; }
        public decimal Price { get; set; }
        public string SubscriptionType { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public int IsActive { get; private set; }

        // Dictionary to store subscriptions by ID
        //public static Dictionary<int, Subscription> Subscriptions = new Dictionary<int, Subscription>();


        // Constructor
        public Subscription (int id, decimal price, string type, DateTime startDate, DateTime endDate)
        {
            this.SubscriptionId = id;
            this.Price = price;
            this.SubscriptionType = type;
            this.SubscriptionStartDate = startDate;
            this.SubscriptionEndDate = endDate;

            this.IsActive = endDate >= DateTime.Now ? 1 : 0;    
        }

        // SUBSCRIPTION OPERATIONS
        // ----------- Check if subscription is active
        /*public bool IsSubscriptionActive ()
        {
            return this.SubscriptionEndDate >= DateTime.Now;
        }
        // ----------- Renew the subscription
        public void RenewSubscription (DateTime newStartDate, DateTime newEndDate)
        {
            this.SubscriptionStartDate = newStartDate;
            this.SubscriptionEndDate = newEndDate;
            this.IsActive = 1;
        }
        // ----------- Deactivate subscription
        public void DeactivateSubscription ()
        {
            this.IsActive = 0;
        }*/
        // ----------- Update the end date of the subscription
        /*public void UpdateSubscriptionDates (DateTime newStartDate, DateTime newEndDate)
        {
            this.SubscriptionStartDate = newStartDate;
            this.SubscriptionEndDate = newEndDate;
            this.IsActive = newEndDate >= DateTime.Now ? 1 : 0;
        }*/
    }
}
