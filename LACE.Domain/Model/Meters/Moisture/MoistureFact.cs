using LACE.Domain.State.Abstractions;

namespace LACE.Domain.Model.Meters.Moisture
{
    public class MoistureFact : IFact
    {
        public MoistureFact(decimal percentage)
        {
            Percentage = percentage;
        }

        public decimal Percentage { get; set; }
    }
}
