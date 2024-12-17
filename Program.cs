using System.Diagnostics.CodeAnalysis;

namespace LinqSetOperators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Concat
            var listForConcat = new List<int> { 1, 2, 3 };
            var listForConcat2 = new List<int> { 3, 4, 5 };

            var concatResult = listForConcat.Concat(listForConcat2);

            foreach (var number in concatResult)
            {
                //Console.WriteLine(number);
            }

            #endregion

            #region Union
            var listForUnion = new List<Person>
            {
                new Person { Id = 1, Name = "Alice" },
                new Person { Id = 2, Name = "Bob" }
            };
            var listForUnion2 = new List<Person>
            {
                new Person { Id = 2, Name = "Bob" },
                new Person { Id = 3, Name = "Charlie" }
             };

            //var unionByResult = listForUnion.Union(listForUnion2);
            var unionByResult = listForUnion.UnionBy(listForUnion2, c => c.Id);

            foreach (var person in unionByResult)
            {
                //Console.WriteLine($"{person.Id} - {person.Name}");
            }


            string[] seq11 = { "A", "B", "C" };
            string[] seq22 = { "a", "b", "c" };

            var unionLetters = seq11.UnionBy(seq22, x => x.ToLower());

            foreach (var item in unionLetters)
            {
                // Console.WriteLine(item);
            }


            #endregion

            #region Intersect

            var seq1 = new List<int> { 1, 2, 3 };
            var seq2 = new List<int> { 3, 4, 5 };

            var intersectItems = seq1.Intersect(seq2);

            foreach (var item in intersectItems)
            {
                //Console.WriteLine(item);
            }


            var listForIntersect = new List<Person>
            {
                new Person { Id = 1, Name = "Alice" },
                new Person { Id = 2, Name = "Bob" }
            };
            var listForIntersect2 = new List<Person>
            {
                new Person { Id = 2, Name = "Bob" },
                new Person { Id = 3, Name = "Charlie" }
             };

            var intersectByResult = listForIntersect.IntersectBy(listForIntersect2.Select(c => c.Id), c => c.Id);

            foreach (var person in intersectByResult)
            {
                //Console.WriteLine($"{person.Id} - {person.Name}");
            }

            #endregion

            #region Except
            var listForExcept = new List<int> { 1, 2, 3 };
            var listForExcept2 = new List<int> { 3, 4, 5 };

            var exceptResult = listForExcept.Except(listForExcept2);

            foreach (var number in exceptResult)
            {
                //Console.WriteLine(number);
            }



            var exceptBy1 = new List<Person>
            {
                new Person { Id = 1, Name = "zidan" },
                new Person { Id = 2, Name = "hamza" }
            };

            var exceptBy2 = new List<Person>
            {
                new Person { Id = 2, Name = "hamza" },
                new Person { Id = 3, Name = "eslam" }
            };

            var exceptByResult = exceptBy1.ExceptBy(exceptBy2.Select(c => c.Id), person => person.Id);

            foreach (var person in exceptByResult)
            {
                //Console.WriteLine($"{person.Id} - {person.Name}");
            }
            #endregion

        }
    }

    class Person : IEqualityComparer<Person>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Equals(Person? x, Person? y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Person obj)
        {
            return Id.GetHashCode();
        }
    }
}
