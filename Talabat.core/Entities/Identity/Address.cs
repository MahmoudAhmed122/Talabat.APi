﻿namespace Talabat.core.Entities.Identity
{
    public class Address
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Street { get; set; }

        public string ApplicationUserId { get; set; } // Foreign Key

        public ApplicationUser ApplicationUser { get; set; } //One RelationShip

    }
}