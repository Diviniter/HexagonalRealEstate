namespace HexagonalRealEstate.Domain.General
{
    public class StringValidator<T>
    {
        protected readonly string _value;

        protected StringValidator(string value)
        {
            this._value = value;
        }

        public override bool Equals(object obj)
        {
            var aString = obj as StringValidator<T>;

            if (ReferenceEquals(aString, null))
                return false;

            return this._value == aString._value;
        }

        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        public override string ToString()
        {
            return this._value;
        }
    }
}
