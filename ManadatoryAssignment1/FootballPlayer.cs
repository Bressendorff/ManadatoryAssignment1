namespace ManadatoryAssignment1
{
    public class FootballPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int ShirtNumber { get; set; }

        public void Validate()
        {
            ValidateName();
            ValidateAge();
            ValidateShirtNumber();
        }

        public void ValidateName()
        {
            if (Name == null)
            {
                throw new ArgumentNullException("Name cannot be null");
            }

            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Cannot be blank");
            if (Name.Length < 2)
            {
                throw new ArgumentOutOfRangeException("Name must be at least 2 characters");
            }   
        }

        public void ValidateAge()
        {
            if (Age < 2)
            {
                throw new ArgumentOutOfRangeException("Age must be over 1");
            }
        }

        public void ValidateShirtNumber()
        {
            if (ShirtNumber > 99)
            {
                throw new ArgumentOutOfRangeException("Shirtnumber cannot be over 99");
            }
            if (ShirtNumber < 1)
            {
                throw new ArgumentOutOfRangeException("Shirtnumber must be at least 1");
            }
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Age)}: {Age}, {nameof(ShirtNumber)}: {ShirtNumber}";
            
        }
    }
}