namespace LACE.Domain.Validation.Abstractions
{
    public interface IValidator<TType>
    {
        bool Validate(TType input);
    }
}
