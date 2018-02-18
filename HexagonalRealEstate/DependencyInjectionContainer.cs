using HexagonalRealEstate.Domain.AccomodationDomain.Repositories;
using HexagonalRealEstate.Domain.AccomodationDomain.Service;
using HexagonalRealEstate.Domain.ClientDomain.Services;
using HexagonalRealEstate.Domain.PersonDomain.Repositories;
using HexagonalRealEstate.Domain.PersonDomain.Services;
using HexagonalRealEstate.Domain.ProspectDomain.Services;
using HexagonalRealEstate.Infrastructure.Dependencies.DataAccessLayer.Repositories;
using HexagonalRealEstate.Infrastructure.Dependencies.Notifications;
using HexagonalRealEstate.Infrastructure.View;
using HexagonalRealEstate.Infrastructure.View.Controllers;
using Unity;

namespace HexagonalRealEstate
{
    public class DependencyInjectionContainer
    {
        private static UnityContainer _container;
        public static UnityContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = new UnityContainer();
                    _container.RegisterType<ClientService, ClientServiceImpl>();
                    _container.RegisterType<ProspectService, ProspectServiceImpl>();
                    _container.RegisterType<PersonService, PersonServiceImpl>();
                    _container.RegisterType<AccomodationService, AccomodationServiceImpl>();

                    _container.RegisterType<Controller, ControllerImpl>();
                    _container.RegisterType<WriteStrategy, ConsoleStrategy>();

                    _container.RegisterType<ProspectNotificationService, ProspectNotificationServiceImpl>();

                    _container.RegisterType<AccomodationRepository, AccomodationRepositoryImpl>();
                    _container.RegisterType<PersonRepository, PersonRepositoryImpl>();

                    _container.RegisterType<PersonQuery, PersonQueryImpl>();
                    _container.RegisterType<AccomodationQuery, AccomodationQueryImpl>();
                    _container.RegisterType<PersonQueryExtended, PersonQueryImpl>();
                    _container.RegisterType<AccomodationQueryExtended, AccomodationQueryImpl>();
                }
                return _container;
            }
        }
    }
}
