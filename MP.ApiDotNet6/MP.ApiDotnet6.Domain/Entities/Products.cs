using MP.ApiDotnet6.Domain.Validations;

namespace MP.ApiDotnet6.Domain.Entities
{
    public sealed class Products
    {
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public string? CodErp { get; private set; }
        public Decimal Price { get; private set; }

        public Products(string name, string codErp, Decimal price)
        {
            Validation(name, codErp, price);
        }
        public Products(int id, string name, string codErp, Decimal price)
        {
            DomainValidationException.When(id < 0, "O Id informado deve ser maior que zero");
            Id = id;
            Validation(name, codErp, price);
        }

        private void Validation(string name, string codErp, Decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(codErp), "O código do produto deve ser informado");
            DomainValidationException.When(price < 0, "O preço deve ser maior que zero");
            Name = name;
            CodErp = codErp;
            Price = price;
        }
    }
}
