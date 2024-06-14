using System.Text.Json;

namespace Domain.ValueObjects
{
    ///TODO: как сравнивать эти объекты (DeepClone, DeepComparse)
    public abstract class BaseValueObjects
    {
        /// <summary>
        /// Переопределение метода для сравнения с другим объектом.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {

            if (obj is not BaseValueObjects entity || entity == null)
                return false;

            var serialEnti = Serialize(entity);
            var serialThis = Serialize(this);

            if (string.Compare(serialEnti, serialThis) != 0)
                return false;

            return true;
        }
        /// <summary>
        /// Переопределение метода для получения хэш-кода объекта.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Serialize(this).GetHashCode();
        }
        /// <summary>
        /// Сериализация данных в json формат 
        /// </summary>
        /// <param name="valueObjects"></param>
        /// <returns></returns>
        private string Serialize(BaseValueObjects valueObjects)
        {
            var serializedObjects = JsonSerializer.Serialize(valueObjects);
            return serializedObjects;
        }
    }
}
