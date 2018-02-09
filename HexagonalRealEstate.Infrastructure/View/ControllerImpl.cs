using HexagonalRealEstate.Domain.Accomodation;
using HexagonalRealEstate.Domain.ClientDomain;
using HexagonalRealEstate.Domain.General;
using HexagonalRealEstate.Domain.PersonDomain;
using HexagonalRealEstate.Domain.ProspectDomain;
using HexagonalRealEstate.Infrastructure.View.Helpers;
using HexagonalRealEstate.Infrastructure.View.Models;
using System;
using System.Collections.Generic;

namespace HexagonalRealEstate.Infrastructure.View
{
    public class ControllerImpl : Controller
    {
        private readonly PersonService personService;
        private readonly ClientService clientService;
        private readonly ProspectService prospectService;
        private readonly AccomodationRepository accomodationRepository;
        private readonly AccomodationService accomodationService;
        private readonly WriteStrategy writeStrategy;
        private readonly PersonRepository personRepository;

        public ControllerImpl(PersonService personService,
            ClientService clientService,
            ProspectService prospectService,
            WriteStrategy writeStrategy,
            AccomodationRepository accomodationRepository,
            AccomodationService accomodationService,
            PersonRepository personRepository)
        {
            this.personService = personService;
            this.clientService = clientService;
            this.prospectService = prospectService;
            this.accomodationRepository = accomodationRepository;
            this.accomodationService = accomodationService;
            this.writeStrategy = writeStrategy;
            this.personRepository = personRepository;
        }

        public void SellAccomodation(PersonModel person, AccomodationModel accomodation)
        {
            try
            {
                this.clientService.SellAccomodation(person.ToBusiness(), accomodation.ToBusiness());
                this.writeStrategy.Write("Accomodation Sold !");
            }
            catch (AccomodationAlreadySold)
            {
                this.writeStrategy.Write($"The accomodation({accomodation}) is already sold");
            }
            catch (ObjectDoesNotExistInRepositoryException e) when (e.Message.Contains("accomodation"))
            {
                this.writeStrategy.Write($"The accomodation({accomodation}) does not exist");
            }
            catch (ObjectDoesNotExistInRepositoryException e) when (e.Message.Contains("person"))
            {
                this.writeStrategy.Write($"The person({person}) does not exist");
            }
        }

        public void CreateAccomodation(AccomodationModel accomodation)
        {
            try
            {
                this.accomodationService.CreateAccomodation(accomodation.ToBusiness());
            }
            catch (AccomodationAlreadyExistException)
            {
                this.writeStrategy.Write("This accomodation already exist");
            }
            catch (ArgumentNullException exception)
            {
                var parameter = exception.GetParameter();
                this.writeStrategy.Write($"It is not possible to create an accomodation without {parameter}");
            }
        }

        public IEnumerable<AccomodationModel> GetAvailableAccomodations()
        {
            var accomodations = this.accomodationRepository.GetAvailableAccomodations();
            foreach (var accomodation in accomodations)
                yield return accomodation.ToModel();
        }

        public IEnumerable<PersonModel> GetPersons()
        {
            var persons = this.personRepository.GetAll();
            foreach (var person in persons)
                yield return person.ToModel();
        }

        public void CreatePerson(PersonModel person)
        {
            try
            {
                this.personService.CreatePerson(person.ToBusiness());
            }
            catch (PersonArleadyExistException)
            {
                this.writeStrategy.Write("This person already exist");
            }
            catch (ArgumentNullException exception)
            {
                var parameter = exception.GetParameter();
                this.writeStrategy.Write($"It is not possible to create a person without {parameter}");
            }
        }

        public void SetPersonAsProspect(PersonModel person, AccomodationModel accomodation)
        {
            try
            {
                this.prospectService.SetPersonAsProspect(person.ToBusiness(), accomodation.ToBusiness());
            }
            catch (AccomodationAlreadySold)
            {
                this.writeStrategy.Write("This accomodation is already sold");
            }
        }
    }
}
