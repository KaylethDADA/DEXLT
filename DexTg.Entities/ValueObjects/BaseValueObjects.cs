using System.Text.Json;

namespace DexTg.Entities.ValueObjects
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

            //if (obj is not BaseValueObjects entity)
            //{
            //    return false;
            //}

            //if (entity == null)
            //{
            //    return false;
            //}

            if (obj is not BaseValueObjects entity || entity == null)
                return false;

            var serialEnti = Serialize(entity);
            var serialThis = Serialize(this);

            ///TODO: Разобраться в String.Compare
            if (String.Compare(serialEnti, serialThis) != 0)
                return false;

            ///TODO: Написать сравнение через рефлексию через DeepCompare
            return true;
        }
        /// <summary>
        /// Переопределение метода для получения хэш-кода объекта.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            //TODO:Реализовать getHashCode
            //У стринги получать код легче получить + 
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
