using HexagonalRealEstate.Domain.PersonDomain;
using NFluent;
using System;
using Xunit;

namespace HexagonalRealEstate.Tests.Domain.PersonDomain
{
    public class PersonTest
    {
        [Fact]
        public void NameShouldBeTheSameAsConstructorParameter()
        {
            var name = "De la licorne";

            var person = new Person("firstName", name, "email@email.fr");

            Check.That(person.Name).Equals("De la licorne");
        }

        [Fact]
        public void FirstNameShouldBeTheSameAsConstructorParameter()
        {
            var firstName = "Samantha";

            var person = new Person(firstName, "name", "email@email.fr");

            Check.That(person.FirstName).Equals("Samantha");
        }

        [Fact]
        public void NameShouldNotBeNull()
        {
            string name = null;

            Check.ThatCode(() => { new Person("firstName", name, "email@email.fr"); })
                .Throws<ArgumentException>();
        }

        [Fact]
        public void FirstNameShouldNotBeNull()
        {
            string firstName = null;

            Check.ThatCode(() => { new Person(firstName, "name", "email@email.fr"); })
                .Throws<ArgumentException>();
        }

        [Fact]
        public void EmailShouldBeTheSameAsConstructorParameter()
        {
            string email = "emal@email.fr";
            var person = new Person("firstname", "name", email);

            Check.That(person.Email).Equals(email);
        }

        [Fact]
        public void EmailCanBeNull()
        {
            string email = null;
            var person = new Person("firstname", "name", email);

            Check.That(person.Email).IsNull();
        }
    }
}
