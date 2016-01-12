using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchExtensions
{
    public static class MatchExtension
    {
        public static void Match<T>(T operand, List<KeyValuePair<  Func<T, bool>,Action<T>>> matches)
        {
            foreach (var match in matches)
            {
                var condition = match.Key;
                var code = match.Value;
                if (condition(operand))
                {
                    code(operand);
                    break;
                }
            }
        }

        public static void Match<T>(T operand, IEnumerable<Case<T>> matches)
        {
            foreach (var match in matches)
            {
                if (match.Condition(operand))
                {
                    match.Code(operand);
                    break;
                }
            }
        }

        public static Case<T> Case<T>(Func<T, bool> condition, Action<T> code)
        {
            return new Case<T> {Condition = condition,Code = code};
        }

        public static Default<T> Default<T>(Action<T> code)
        {
            return new Default<T> {Code = code};
        }
    }

    public class Case<T>
    {
        public Func<T,bool> Condition { get; set; }
        public Action<T> Code { get; set; }
    }

    public class Default<T>:Case<T>
    {
        public Default()
        {
            Condition = x => true;
        }  
    }
}
