using System;
using CSharpFunctionalExtensions;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects.Properties;
using NFluent;
using Xunit;

namespace HexagonalRealEstate.Tests.Domain.PersonDomain
{
    public class PersonTest
    {
        public static Person GetPerson(PersonFirstName firstName = null, PersonName name = null, PersonEmail email = null)
        {
            return new Person(
                Maybe<string>.None,
                firstName: firstName ?? PersonFirstName.Create("firstname").Value,
                name: name ?? PersonName.Create("name").Value,
                email: email ?? PersonEmail.Create("email@email.fr").Value
                );
        }

        [Fact]
        public void NameShouldBeTheSameAsConstructorParameter()
        {
            var name = PersonName.Create("name").Value;

            var person = GetPerson(name: name);

            Check.That<string>(person.Name).Equals("name");
        }

        [Fact]
        public void FirstNameShouldBeTheSameAsConstructorParameter()
        {
            var firstName = PersonFirstName.Create("firstname").Value;

            var person = GetPerson(firstName: firstName);

            Check.That<string>(person.FirstName).IsEqualTo("firstname");
        }

        [Fact]
        public void NameShouldNotBeNull()
        {
            PersonName name = null;

            Check.ThatCode(() =>
            {
                new Person(
                    surrogateId: Maybe<string>.None,
                    firstName: PersonFirstName.Create("firstname").Value,
                    name: name,
                    email: PersonEmail.Create("email@email.fr").Value
                );
            }).Throws<ArgumentException>();
        }

        [Fact]
        public void FirstNameShouldNotBeNull()
        {
            PersonFirstName firstName = null;

            Check.ThatCode(() =>
            {
                new Person(
                    surrogateId: Maybe<string>.None,
                    firstName: firstName,
                    name: PersonName.Create("name").Value,
                    email: PersonEmail.Create("email@email.fr").Value
                );
            }).Throws<ArgumentException>();
        }

        [Fact]
        public void EmailShouldBeTheSameAsConstructorParameter()
        {
            var email = PersonEmail.Create("email@email.fr").Value;

            var person = GetPerson(email: email.Value);

            Check.That<string>(person.Email.Value).IsEqualTo("email@email.fr");
        }

        [Fact]
        public void EmailCanBeEmpty()
        {
            var email = Maybe<PersonEmail>.None;
            var person = new Person(
                surrogateId: Maybe<string>.None,
                 firstName: PersonFirstName.Create("firstname").Value,
                 name: PersonName.Create("name").Value,
                 email: email);
            Check.That(person.Email.HasNoValue).IsTrue();
        }
    }
}
