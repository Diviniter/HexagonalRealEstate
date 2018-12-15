using Optional;

namespace HexagonalRealEstate.Domain.PersonDomain.Objects
{
    public class PersonId
    {
        public readonly Option<string> SurrogateId;

        public PersonId(Option<string> surrogateId)
        {
            this.SurrogateId = surrogateId;
        }

        public override int GetHashCode()
        {
            return this.SurrogateId.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var person = (Person)obj;
            return person.SurrogateId == this.SurrogateId;
        }
    }
}
