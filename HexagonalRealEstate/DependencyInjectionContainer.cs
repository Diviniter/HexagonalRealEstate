using HexagonalRealEstate.Domain.Accomodation;
using HexagonalRealEstate.Domain.ClientDomain;
using HexagonalRealEstate.Domain.PersonDomain;
using HexagonalRealEstate.Domain.ProspectDomain;
using HexagonalRealEstate.Infrastructure.Dependencies;
using HexagonalRealEstate.Infrastructure.View;
using Unity;

namespace HexagonalRealEstate
{
    public class DependencyInjectionContainer
    {
        private static UnityContainer container;
        public static UnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = new UnityContainer();
                    container.RegisterType<ClientService, ClientServiceImpl>();
                    container.RegisterType<ProspectService, ProspectServiceImpl>();
                    container.RegisterType<PersonService, PersonServiceImpl>();
                    container.RegisterType<AccomodationService, AccomodationServiceImpl>();

                    container.RegisterType<Controller, ControllerImpl>();
                    container.RegisterType<WriteStrategy, ConsoleStrategy>();

                    container.RegisterType<ProspectNotificationService, ProspectNotificationServiceImpl>();
                    container.RegisterType<AccomodationRepository, AccomodationRepositoryImpl>();
                    container.RegisterType<PersonRepository, PersonRepositoryImpl>();
                }
                return container;
            }
        }
    }
}
