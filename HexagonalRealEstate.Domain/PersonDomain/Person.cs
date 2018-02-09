using System;

namespace HexagonalRealEstate.Domain.PersonDomain
{
    public class Person
    {
        public Person(string firstName, string name, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentNullException(nameof(firstName));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            this.FirstName = firstName;
            this.Name = name;
            this.Email = email;
        }

        public string Name { get; private set; }
        public string FirstName { get; private set; }
        public string Email { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var person = (Person)obj;
            return person.Name == this.Name && person.FirstName == this.FirstName;
        }
    }
}
