using System;

namespace ConsoleApp
{
    class ArrayStack
    {
        private string[] stack;
        private int top;

        public ArrayStack(int size)
        {
            stack = new string[size];
            top = -1;
        }

        // Push (Add action)
        public void Push(string action)
        {
            if (top == stack.Length - 1)
            {
                Console.WriteLine("Stack Overflow");
                return;
            }

            top++;
            stack[top] = action;
            Console.WriteLine($"Action Performed: {action}");
            Display();
        }

        // Pop (Undo)
        public void Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Nothing to undo (Stack is empty)");
                return;
            }

            Console.WriteLine($"Undo Action: {stack[top]}");
            top--;
            Display();
        }

        // Display current state
        public void Display()
        {
            Console.Write("Current State: ");

            if (top == -1)
            {
                Console.WriteLine("Empty");
                return;
            }

            for (int i = 0; i <= top; i++)
            {
                Console.Write(stack[i] + " | ");
            }
            Console.WriteLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayStack editor = new ArrayStack(10);

            // Sample Input
            editor.Push("Type A");
            editor.Push("Type B");
            editor.Push("Type C");

            editor.Pop(); // Undo C
            editor.Pop(); // Undo B

            Console.ReadLine();
        }
    }
}
