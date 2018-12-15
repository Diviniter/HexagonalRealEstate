namespace HexagonalRealEstate.ViewsModels
{
    public class PersonModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {Name}";
        }
    }
}
