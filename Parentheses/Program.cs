using System;
using System.Collections.Generic;

public class Solution
{
    public bool IsValid(string s)
    {
        var stack = new Stack<char>();
        var parentheses = new Dictionary<char, char> {
            { ')', '(' },
            { '}', '{' },
            { ']', '[' }
        };

        foreach (char c in s)
        {
            if (parentheses.ContainsValue(c))
            {
                stack.Push(c);
            }
            else if (parentheses.ContainsKey(c))
            {
                if (stack.Count == 0 || stack.Pop() != parentheses[c])
                {
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();

        // Test cases
        Console.WriteLine(solution.IsValid("()"));         // Output: True
        Console.WriteLine(solution.IsValid("()[]{}"));     // Output: True
        Console.WriteLine(solution.IsValid("(]"));         // Output: False
        Console.WriteLine(solution.IsValid("([])"));       // Output: True
    }
}
