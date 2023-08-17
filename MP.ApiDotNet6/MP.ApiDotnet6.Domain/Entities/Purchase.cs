using MP.ApiDotnet6.Domain.Validations;

namespace MP.ApiDotnet6.Domain.Entities
{
    public class Purchase
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person? Person { get; set; }
        public Product? Product { get; set; }

        public Purchase(int productId, int personId, DateTime? date)
        {
            Validation(productId, personId, date);
        }

        public Purchase(int id, int productId, int personId, DateTime? date)
        {
            DomainValidationException.When(id < 0, "Id informado é inválido");
            Id = id;
            Validation(productId, personId, date);
        }

        private void Validation(int productId, int personId, DateTime? date)
        {
            DomainValidationException.When(productId < 0, "O id do produto deve ser válido");
            DomainValidationException.When(personId < 0, "O id da produto deve ser válido");
            DomainValidationException.When(!date.HasValue, "A data precisa ser preenchida corretamente");
            ProductId = productId;
            PersonId = personId;
            Date = date.Value;
        }
    }
}
