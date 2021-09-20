using System;
using System.Collections.Generic;

namespace Zasobnik
{
    class Program
    {
        Stack<char> s = new Stack<char>();
        
        static void Main()
        {
            Program f = new Program();
            f.BracketCheck();
        }

        public void BracketCheck()
        {
            string input;
            char[] charAr;
            bool error = false;

           // string[] tester = { "xxx((xx))", "xxx({xx}})xx" };

            Console.WriteLine("Awaiting input...");
            input = Console.ReadLine();
            Console.Clear();
            charAr = input.ToCharArray();

            for (int i = 0; i < charAr.Length; i++)
            {
                if (charAr[i] == '(' || charAr[i] == '{' || charAr[i] == '[' )
                {
                    s.Push(charAr[i]);
                }
                else if (charAr[i] == ']' || charAr[i] == '}' || charAr[i] == ')')
                {
                    try
                    {
                        switch (s.Peek())
                        {
                            case '(':
                                if (charAr[i] == ')') s.Pop();
                                else Err(i);
                                break;
                            case '[':
                                if (charAr[i] == ']') s.Pop();
                                else Err(i);
                                break;
                            case '{':
                                if (charAr[i] == '}') s.Pop();
                                else Err(i);
                                break;
                            default:
                                Console.ReadLine();
                                break;
                        }
                    }
                    catch
                    {
                        Err(i);                    
                    }
                }               
            }

            if (s.IsEmpty() && error == false)
            {
                Console.WriteLine(input);
                Console.WriteLine("Everything OK");
            }
            Console.ReadLine();

            void Err(int exprLength)
            {
                error = true;
                char[] errorPointer = new char[++exprLength];
                for (int i = 0; i < exprLength; i++)
                {
                    errorPointer[i] = '-';
                }
                errorPointer[exprLength -1] = '^';
                Console.WriteLine(input);
                foreach (var item in errorPointer)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
                Console.WriteLine("Invalid bracket at " + exprLength);
            }

        }
    }

    public class Stack<T>
    {
        public List<T> LIFO;
        public Stack()
        {
            LIFO = new List<T>();
        }
        public void Push(T c) // adds a char to the top of the stack
        {
            LIFO.Add(c);
        }

        public T Pop() // returns and removes a char from the top of the stack
        {
            int index = LIFO.Count - 1;
            T retChar = LIFO[index];
            LIFO.RemoveAt(index);
            return retChar;
        }

        public T Peek() // returns a char from the top of the stack without removing it
        {
            return LIFO[LIFO.Count - 1];
        }

        public bool IsEmpty() // returns true if the stack is empty and false if it contains at least 1 element
        {
            if (LIFO.Count == 0) return true;
            else return false;
        }

        public void PrintStack(bool lines = true) // prints out all elements of the stack
        {
            foreach (var item in LIFO)
            {
                if (lines) Console.WriteLine(item);
                else Console.Write(item);

            }
        }
    }

}
