using System;

namespace Club_manager
{
    internal class Athlete
    {
        // properties 
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sexe { get; set; }
        public string PhoneNumber { get; set; }

        public string ImagePath { get; set; }

        // athlete subscription
        public Subscription AthleteSubcription { get; set; }

        // Constructor
        public Athlete (int id, string name, string sexe, DateTime birthDate, string phoneNumber, Subscription subscription, string imagepath)
        {
            this.ID = id;
            this.Name = name;
            this.Sexe = sexe;
            this.BirthDate = birthDate;
            this.PhoneNumber = phoneNumber;
            this.AthleteSubcription = subscription;
            this.ImagePath = imagepath;
        }

    }
}
