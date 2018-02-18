using System;
using System.Collections.Generic;
using HexagonalRealEstate.Infrastructure.View.Controllers;
using HexagonalRealEstate.Infrastructure.View.Helpers;
using HexagonalRealEstate.Infrastructure.View.Models;
using Unity;

namespace HexagonalRealEstate.Views
{
    public static class AccomodationResponsibleView
    {
        private static readonly Controller _controller = DependencyInjectionContainer.Container.Resolve<Controller>();

        public static void GoToAccomodationResponsibleView()
        {
            View.DoAChoice(
                title: "What do you want to do ?",
                choices: new Dictionary<string, Action>()
                {
                    { "Create an accomodation", CreateAccomodation}
                });
        }

        public static void CreateAccomodation()
        {
            var accomodation = new CreateAccomodationModel
            {
                Number = View.GetString("Number")
            };

            var message = _controller.CreateAccomodation(accomodation);

            Console.WriteLine(message);
        }
    }
}
