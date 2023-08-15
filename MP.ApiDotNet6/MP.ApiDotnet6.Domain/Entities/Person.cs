﻿using MP.ApiDotnet6.Domain.Validations;

namespace MP.ApiDotnet6.Domain.Entities
{
    public sealed class Person
    {
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public string? Document { get; private set; }
        public string? Phone { get; private set; }

        public Person(string document, string name, string phone)
        {
            Validation(document, name, phone);
        }

        public Person(int id, string name, string document, string phone)
        {
            DomainValidationException.When(id < 0, "Id deve ser maior que zero");
            Id = id;
            Validation(document, name, phone);
        }

        private void Validation(string document, string name, string phone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado.");
            DomainValidationException.When(string.IsNullOrEmpty(document), "O Documento deve ser informado.");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "Telefone deve ser informado.");
            Name = name;
            Document = document;
            Phone = phone;
        }
    }
}
