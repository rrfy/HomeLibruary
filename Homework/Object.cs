using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal class Object
    {
        int Id;
        string Type;
        string Name;
        string Author;
        int Year;

        public Object(int id, string type, string name, string author, int year)
        {
            Id = id;
            Type = type;
            Name = name;
            Author = author;
            Year = year;
        }
        public int id { get => Id; set => Id = value; }
        public string type { get => Type; set => Type = value; }
        public string name { get => Name; set => Name = value; }
        public string author { get => Author; set => Author = value; }
        public int year { get => Year; set => Year = value; }

        public override bool Equals(object obj)
        {
            return obj is Object @object &&
                   Id == @object.Id &&
                   Type == @object.Type &&
                   Name == @object.Name &&
                   Author == @object.Author &&
                   Year == @object.Year &&
                   id == @object.id &&
                   type == @object.type &&
                   name == @object.name &&
                   author == @object.author &&
                   year == @object.year;
        }

        public override int GetHashCode()
        {
            int hashCode = -1263061099;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Author);
            hashCode = hashCode * -1521134295 + Year.GetHashCode();
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(author);
            hashCode = hashCode * -1521134295 + year.GetHashCode();
            return hashCode;
        }
    }
}
