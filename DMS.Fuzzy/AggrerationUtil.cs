using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Fuzzy
{
    public class AggrerationUtil
    {
        public IEnumerable<IEnumerable<T>> Permutation<T>(IEnumerable<T> input)
        {
            if (input == null || !input.Any()) yield break;
            if (input.Count() == 1) yield return input;
            foreach (var item in input)
            {
                var next = input.Where(l => !l.Equals(item)).ToList();
                foreach (var perm in Permutation(next))
                {
                    yield return (new List<T> { item }).Concat(perm);
                }
            }
        }
    }
}
