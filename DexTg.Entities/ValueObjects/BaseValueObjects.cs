namespace DexTg.Entities.ValueObjects
{
    ///TODO: как сравнивать эти объекты (DeepClone, DeepComparse)
    public abstract class BaseValueObjects
    {
        public override bool Equals(object? obj)
        {

            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
