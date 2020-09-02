using LACE.Core.Abstractions.Model;
using LACE.Domain.Extensions;

namespace LACE.Domain.State
{
    class FactKey : IFactKey
    {
        public FactKey()
        {
        }

        public FactKey(string guid)
        {
            Guid = guid;
        }

        public string Guid { get; }

        public bool Equals(IFactKey other)
        {
            // Switch expression: compare in case of FactKey, else return false;
            return other switch
            {
                FactKey otherFactKey => Guid.EmptyInsensitiveEquals(otherFactKey.Guid),
                _ => false
            };
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((FactKey) obj);
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }
    }
}
