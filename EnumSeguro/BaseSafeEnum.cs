using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EnumSeguro
{
    public abstract class BaseSafeEnum<T> : IBaseSafeEnum, IEquatable<BaseSafeEnum<T>> where T : IBaseSafeEnum
    {
        public object Id { get; }
        public string Description { get; }

        protected BaseSafeEnum(object id, string description)
        {
            Id = id;
            Description = description;
        }

        public static IEnumerable<T> GetAll()
            => typeof(T).GetFields().Where(x => x.IsStatic)
                            .ToList().ConvertAll<T>((FieldInfo fi) => (T)fi.GetValue(null));

        public static T GetById(object id)
            => GetAll().FirstOrDefault(x => x.Id.Equals(id));

        public override bool Equals(object obj)
            => Equals(obj as BaseSafeEnum<T>);

        public bool Equals(BaseSafeEnum<T> other)
            => other != null &&
                    EqualityComparer<object>.Default.Equals(Id, other.Id);
        
        public static bool operator ==(BaseSafeEnum<T> left, BaseSafeEnum<T> right)
            => EqualityComparer<BaseSafeEnum<T>>.Default.Equals(left, right);        

        public static bool operator !=(BaseSafeEnum<T> left, BaseSafeEnum<T> right)
            => !(left == right);

        public override int GetHashCode()
            => HashCode.Combine(Id, Description);
    }
}