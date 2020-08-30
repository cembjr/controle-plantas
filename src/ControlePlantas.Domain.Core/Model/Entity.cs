using System;
using System.ComponentModel.DataAnnotations.Schema;
using ControlePlantas.Domain.Core;
using FluentValidation;
using FluentValidation.Results;

namespace ControlePlantas.Domain.Core
{
    public abstract class Entity<T> : AbstractValidator<T> where T : class
    {
        protected Entity() => ValidationResult = new ValidationResult();

        public Guid Id { get; protected set; }

        public DateTime DataCadastro { get; protected set; }

        protected abstract T Validar();

        public void ValidateAndThrow()
        {
            if (!IsValid)
                throw new DomainException(ValidationResult.Errors);
        }

        [NotMapped]
        public bool IsValid
        {
            get
            {
                ValidationResult = Validate(Validar());
                return ValidationResult.IsValid;
            }
        }

        [NotMapped]
        public ValidationResult ValidationResult { get; protected set; }

        [NotMapped]
        public new CascadeMode CascadeMode { get; set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id = { Id } ]";
        }

    }
}

