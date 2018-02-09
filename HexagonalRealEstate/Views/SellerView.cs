using HexagonalRealEstate.Infrastructure.View;
using HexagonalRealEstate.Infrastructure.View.Helpers;
using HexagonalRealEstate.Infrastructure.View.Models;
using System;
using System.Collections.Generic;
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
                    { "Set a person as a prospect", SetPersonAsProspect}
                });
        }

        public static void CreatePerson()
        {
            var person = new PersonModel
            {
                FirstName = View.GetString("FirstName"),
                Name = View.GetString("Name"),
                Email = View.GetString("Email")
            };
            _controller.CreatePerson(person);
        }

        public static void SellAccomodation()
        {
            var accomodation = View.DoAChoice(
                title: "Which accomodation do you want to sell ?",
                choices: _controller.GetAvailableAccomodations());

            var person = View.DoAChoice(
                title: "To which person ?",
                choices: _controller.GetPersons());

            _controller.SellAccomodation(person, accomodation);
        }

        public static void SetPersonAsProspect()
        {
            var person = View.DoAChoice(
                title: "To which person ?",
                choices: _controller.GetPersons());

            var accomodation = View.DoAChoice(
                title: "Which accomodation do you want to sell ?",
                choices: _controller.GetAvailableAccomodations());

            _controller.SetPersonAsProspect(person, accomodation);
        }
    }
}
