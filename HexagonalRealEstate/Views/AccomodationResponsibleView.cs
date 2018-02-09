using HexagonalRealEstate.Infrastructure.View;
using HexagonalRealEstate.Infrastructure.View.Helpers;
using HexagonalRealEstate.Infrastructure.View.Models;
using System;
using System.Collections.Generic;
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
            var accomodation = new AccomodationModel
            {
                Number = View.GetString("Number")
            };

            _controller.CreateAccomodation(accomodation);
        }
    }
}
