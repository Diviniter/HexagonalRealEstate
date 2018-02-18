using System;
using System.Collections.Generic;
using HexagonalRealEstate.Domain.AccomodationDomain.Exceptions;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects.Properties;
using HexagonalRealEstate.Domain.AccomodationDomain.Service;
using HexagonalRealEstate.Domain.ClientDomain.Services;
using HexagonalRealEstate.Domain.PersonDomain.Exceptions;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Services;
using HexagonalRealEstate.Domain.ProspectDomain.Services;
using HexagonalRealEstate.Infrastructure.Dependencies.DataAccessLayer.Repositories;
using HexagonalRealEstate.Infrastructure.View.Helpers;
using HexagonalRealEstate.Infrastructure.View.Models;

namespace HexagonalRealEstate.Infrastructure.View.Controllers
{
    public class ControllerImpl : Controller
    {
        private readonly PersonService personService;
        private readonly ClientService clientService;
        private readonly ProspectService prospectService;
        private readonly AccomodationService accomodationService;
        private readonly PersonQueryExtended personQuery;
        private readonly AccomodationQueryExtended accomodationQuery;

        public ControllerImpl(PersonService personService,
            ClientService clientService,
            ProspectService prospectService,
            AccomodationService accomodationService,
            PersonQueryExtended personQuery,
            AccomodationQueryExtended accomodationQuery)
        {
            this.personService = personService;
            this.clientService = clientService;
            this.prospectService = prospectService;
            this.accomodationService = accomodationService;
            this.personQuery = personQuery;
            this.accomodationQuery = accomodationQuery;
        }

        public string SellAccomodation(SellAccomodationModel model)
        {
            try
            {
                var validationResult = model.Evaluate();
                if (validationResult.IsFailure)
                    return validationResult.Error;

                var personId = new PersonId(model.PersonId);

                var accomodationNumber = AccomodationNumber.Create(model.AccomodationNumber);
                var accomodationId = new AccomodationId(accomodationNumber.Value);

                this.clientService.SellAccomodation(personId, accomodationId);

                return "Accomodation Sold !";
            }
            catch (AccomodationAlreadySoldException)
            {
                return "The accomodation is already sold";
            }
            catch (AccomodationDoesNotExistException)
            {
                return "The accomodation does not exist";
            }
            catch (PersonDoesNotExistException)
            {
                return "The person does not exist";
            }
            catch (Exception)
            {
                return "An unknow error was thrown";
            }
        }

        public string CreateAccomodation(CreateAccomodationModel accomodationModel)
        {
            try
            {
                var validationResult = accomodationModel.Evaluate();
                if (validationResult.IsFailure)
                    return validationResult.Error;

                var accomodation = accomodationModel.ToBusinessObject();

                this.accomodationService.CreateAccomodation(accomodation);

                return "Accomodation Created";
            }
            catch (AccomodationAlreadyExistException)
            {
                return "This accomodation already exist";
            }
            catch (ArgumentNullException exception)
            {
                var parameter = exception.GetParameter();
                return $"It is not possible to create an accomodation without {parameter}";
            }
            catch (Exception)
            {
                return "An unknow error was thrown";
            }
        }

        public IEnumerable<AccomodationModel> GetAvailableAccomodations()
        {
            return this.accomodationQuery.GetAvailableAccomodations();
        }

        public IEnumerable<PersonModel> GetPersons()
        {
            return this.personQuery.GetAll();
        }

        public string CreatePerson(CreatePersonModel personModel)
        {
            try
            {
                var validationResult = personModel.Evaluate();
                if (validationResult.IsFailure)
                    return validationResult.Error;

                var person = personModel.ToBusinessObject();

                if (this.personQuery.WithSameName(person.FirstName, person.Name))
                {
                    var createNewPerson =
                        Helpers.View.YesNoChoice(
                            "A person with same firstname an name exist, are you sure you want to create a new one ?");
                    if (!createNewPerson)
                        return "Person has not been created";
                }

                this.personService.CreatePerson(person);

                return "Person created";
            }
            catch (ArgumentNullException exception)
            {
                var parameter = exception.GetParameter();
                return $"It is not possible to create a person without {parameter}";
            }
            catch (Exception)
            {
                return "An unknow error was thrown";
            }
        }

        public string CreateProspect(CreateProspectModel model)
        {
            try
            {
                var validationResult = model.Evaluate();
                if (validationResult.IsFailure)
                    return validationResult.Error;

                var personId = new PersonId(model.PersonId);

                var accomodationNumber = AccomodationNumber.Create(model.AccomodationNumber);
                var accomodationId = new AccomodationId(accomodationNumber.Value);

                this.prospectService.CreateProspect(personId, accomodationId);

                return "Person become a prospect on this accomodation!";
            }
            catch (AccomodationAlreadySoldException)
            {
                return "This accomodation is already sold";
            }
            catch (Exception)
            {
                return "An unknow error was thrown";
            }
        }
    }
}
