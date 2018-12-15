using HexagonalRealEstate.Views.Helpers;
using System;
using System.Collections.Generic;
using static HexagonalRealEstate.Views.AccomodationResponsibleView;
using static HexagonalRealEstate.Views.SellerView;

namespace HexagonalRealEstate.Views
{
    public class WelcomeView
    {
        public static void SelectUserType()
        {
            View.DoAChoice(
                title: "Who are you ?",
                choices: new Dictionary<string, Action>()
                {
                    { "An accomodation responssible", GoToAccomodationResponsibleView},
                    { "A seller", GoToSellerView }
                });
        }
    }
}
