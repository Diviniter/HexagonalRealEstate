namespace HexagonalRealEstate.Infrastructure.View.Models
{
    public class PersonModel
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.Name}";
        }
    }
}
