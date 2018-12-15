using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects.Properties;
using NFluent;
using Optional;
using Optional.Unsafe;
using System;
using Xunit;

namespace HexagonalRealEstate.Tests.Domain.PersonDomain
{
    public class PersonTest
    {
        public static Person GetPerson(Option<PersonFirstName> firstName, Option<PersonName> name, Option<PersonEmail> email)
        {
            return new Person(
                surrogateId: Option.None<string>(),
                firstName: firstName.ValueOr(PersonFirstName.Create("firstname").Value),
                name: name.ValueOr(PersonName.Create("name").Value),
                email: email.Else(Option.None<PersonEmail>()));
        }

        public static Person GetPersonWithoutId()
        {
            return new Person(
                surrogateId: Option.None<string>(),
                firstName: PersonFirstName.Create("firstname").Value,
                name: PersonName.Create("name").Value,
                email: PersonEmail.Create("email@email.fr").Value);
        }

        [Fact]
        public void NameShouldBeTheSameAsConstructorParameter()
        {
            //Init
            var firstName = Option.None<PersonFirstName>();
            var name = Option.Some(PersonName.Create("name").Value);
            var email = Option.None<PersonEmail>();

            //Act
            var person = GetPerson(firstName, name, email);

            //Assert
            Check.That<string>(person.Name).Equals("name");
        }

        [Fact]
        public void FirstNameShouldBeTheSameAsConstructorParameter()
        {
            //Init
            var firstName = Option.Some(PersonFirstName.Create("firstname").Value);
            var name = Option.None<PersonName>();
            var email = Option.None<PersonEmail>();

            //Act
            var person = GetPerson(firstName, name, email);

            //Assert
            Check.That<string>(person.FirstName).IsEqualTo("firstname");
        }

        [Fact]
        public void NameShouldNotBeNull()
        {
            PersonName name = null;

            Action action = () =>
            {
                new Person(
                    surrogateId: Option.None<string>(),
                    firstName: PersonFirstName.Create("firstname").Value,
                    name: name,
                    email: PersonEmail.Create("email@email.fr").Value
                );
            };

            Check.ThatCode(action).Throws<ArgumentException>();
        }

        [Fact]
        public void FirstNameShouldNotBeNull()
        {
            PersonFirstName firstName = null;

            Action action = () =>
            {
                new Person(
                    surrogateId: Option.None<string>(),
                    firstName: firstName,
                    name: PersonName.Create("name").Value,
                    email: PersonEmail.Create("email@email.fr").Value
                );
            };

            Check.ThatCode(action).Throws<ArgumentException>();
        }

        [Fact]
        public void EmailShouldBeTheSameAsConstructorParameter()
        {
            //Init
            var firstName = Option.None<PersonFirstName>();
            var name = Option.None<PersonName>();
            var email = PersonEmail.Create("email@email.fr").Value;

            //Act
            var person = GetPerson(firstName, name, email);

            //Assert
            var expectedEmail = PersonEmail.Create("email@email.fr").Value;
            Check.That(person.Email.ValueOrFailure()).IsEqualTo(expectedEmail.ValueOrFailure());
        }

        [Fact]
        public void EmailCanBeEmpty()
        {
            //Init
            var firstName = Option.Some(PersonFirstName.Create("firstname").Value);
            var name = Option.Some(PersonName.Create("name").Value);
            var email = Option.None<PersonEmail>();

            //Act
            var person = GetPerson(firstName, name, email);

            //Assert
            Check.That(person.Email.HasValue).IsFalse();
        }
    }
}
