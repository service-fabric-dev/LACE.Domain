namespace LACE.Domain.Configuration.Abstractions
{
    // ReSharper disable once TypeParameterCanBeVariant
    public interface IConfigurationLoader<TConfigurationPointer>
        where TConfigurationPointer : IConfigurationPointer
    {
        TConfiguration GetConfiguration<TConfiguration>(TConfigurationPointer pointer) where TConfiguration : IConfiguration;
    }
}