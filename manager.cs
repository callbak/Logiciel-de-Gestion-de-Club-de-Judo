namespace Club_manager
{
    internal class Manager
    {
        // properties 
        public int ID { get; set; }
        public string Name { get; set; }
        public ManagerRole role { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Constructor
        public Manager (int id, string name, ManagerRole role, string email, string phoneNumber)
        {
            this.ID = id;
            this.Name = name;
            this.role = role;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
        }

        // ----------- Athlete OPERATIONS
        public void AddAthlete (Athlete athlete)
        {
            //
        }
        public void RemoveAthlete (Athlete athlete)
        {
            //
        }
        public void UpdateAthlete (Athlete athlete)
        {
            //
        }
        public void ManageSubscription (Subscription subscription)
        {
            //
        }


    }
    public enum ManagerRole
    {
        Admin,
        Assistant
    }
}
