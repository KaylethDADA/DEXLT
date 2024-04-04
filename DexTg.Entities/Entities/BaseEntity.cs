namespace Domain.Entities
{
    /// <summary>
    /// Базовый абстрактный класс сущности.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Уникальный идентификатор сущности.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Переопределение метода для сравнения с другим объектом.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj is not BaseEntity entity)
                return false;

            //id == entity.id
            return GetHashCode() == entity.GetHashCode();
        }
        /// <summary>
        /// Переопределение метода для получения хэш-кода объекта.
        /// </summary>
        /// <returns></returns>
        /// TODO: Либо написать свой GetHashCode но ххпхпхп
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

