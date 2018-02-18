using System;
using System.Collections.Generic;
using System.Linq;
using HexagonalRealEstate.Infrastructure.View.Controllers;
using HexagonalRealEstate.Infrastructure.View.Helpers;
using HexagonalRealEstate.Infrastructure.View.Models;
using Unity;

namespace HexagonalRealEstate.Views
{
    public static class SellerView
    {
        private static readonly Controller _controller = DependencyInjectionContainer.Container.Resolve<Controller>();

        public static void GoToSellerView()
        {
            View.DoAChoice(
                title: "What do you want to do ?",
                choices: new Dictionary<string, Action>()
                {
                    { "Create a person", CreatePerson},
                    { "Sell an accomodation", SellAccomodation},
                    { "Create a prospect", CreateProspect}
                });
        }

        public static void CreatePerson()
        {
            var person = new CreatePersonModel
            {
                FirstName = View.GetString("FirstName"),
                Name = View.GetString("Name"),
                Email = View.GetString("Email")
            };

            var message = _controller.CreatePerson(person);

            Console.WriteLine(message);
        }

        public static void SellAccomodation()
        {
            var accomodations = _controller.GetAvailableAccomodations();

            if (!accomodations.Any())
            {
                Console.WriteLine("There is no accomodation available, create an accomodation before");
                return;
            }

            var persons = _controller.GetPersons();

            if (!persons.Any())
            {
                Console.WriteLine("There is no person, create an accomodation before");
                return;
            }

            var accomodation = View.DoAChoice(
                title: "Which accomodation do you want to sell ?",
                choices: accomodations);

            var person = View.DoAChoice(
                title: "To who ?",
                choices: persons);

            var model = new SellAccomodationModel
            {
                PersonId = person.Id,
                AccomodationNumber = accomodation.Number
            };

            var message = _controller.SellAccomodation(model);

            Console.WriteLine(message);
        }

        public static void CreateProspect()
        {
            var accomodations = _controller.GetAvailableAccomodations();

            if (!accomodations.Any())
            {
                Console.WriteLine("There is no accomodation available, create an accomodation before");
                return;
            }

            var persons = _controller.GetPersons();

            if (!persons.Any())
            {
                Console.WriteLine("There is no person, create an accomodation before");
                return;
            }

            var person = View.DoAChoice(
                title: "Who want to become prospect ?",
                choices: persons);

            var accomodation = View.DoAChoice(
                title: "On which accomodation ?",
                choices: accomodations);

            var model = new CreateProspectModel
            {
                AccomodationNumber = accomodation.Number,
                PersonId = person.Id
            };

            var message = _controller.CreateProspect(model);

            Console.WriteLine(message);
        }
    }
}
