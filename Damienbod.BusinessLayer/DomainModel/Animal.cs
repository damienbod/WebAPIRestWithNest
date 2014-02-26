using System;

namespace Damienbod.BusinessLayer.DomainModel
{
    public class Animal
    {
        public const string SearchIndex = "animals";

        public int Id { get; set; }

        public string AnimalType { get; set; }

        public DateTime CreatedTimestamp { get; set; }

        public DateTime UpdatedTimestamp { get; set; }
    }
}