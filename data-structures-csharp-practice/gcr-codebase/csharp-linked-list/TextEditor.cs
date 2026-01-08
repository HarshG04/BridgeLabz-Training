using System;

class TextState
{
    public string content;
    public TextState prev;
    public TextState next;

    public TextState(string text)
    {
        content = text;
        prev = null;
        next = null;
    }
}

class TextEditor
{
    private TextState head = null;
    private TextState current = null;
    private int count = 0;
    private int limit = 10;

    // ---------- Add New State ----------
    public void AddState()
    {
        Console.Write("Enter new text: ");
        string text = Console.ReadLine();

        TextState newState = new TextState(text);

        // If first entry
        if (head == null)
        {
            head = newState;
            current = newState;
            count = 1;
            return;
        }

        // Remove all redo states after current
        TextState temp = current.next;
        while (temp != null)
        {
            TextState del = temp;
            temp = temp.next;
            del = null;
            count--;
        }
        current.next = null;

        // Append at end
        current.next = newState;
        newState.prev = current;
        current = newState;
        count++;

        // Enforce max size 10
        while (count > limit)
        {
            head = head.next;
            head.prev = null;
            count--;
        }
    }

    // ---------- Undo ----------
    public void Undo()
    {
        if (current == null || current.prev == null)
        {
            Console.WriteLine("No more undo available.");
            return;
        }

        current = current.prev;
        Console.WriteLine("Undo done.");
    }

    // ---------- Redo ----------
    public void Redo()
    {
        if (current == null || current.next == null)
        {
            Console.WriteLine("No more redo available.");
            return;
        }

        current = current.next;
        Console.WriteLine("Redo done.");
    }

    // ---------- Show Current ----------
    public void ShowCurrent()
    {
        if (current == null)
        {
            Console.WriteLine("Editor is empty.");
            return;
        }

        Console.WriteLine("\nCurrent Text: " + current.content);
    }
}

class Program
{
    static void Main()
    {
        TextEditor editor = new TextEditor();

        while (true)
        {
            Console.WriteLine("\n===== TEXT EDITOR =====");
            Console.WriteLine("1. Type / Add Text State");
            Console.WriteLine("2. Undo");
            Console.WriteLine("3. Redo");
            Console.WriteLine("4. Show Current Text");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            int ch = Convert.ToInt32(Console.ReadLine());

            switch (ch)
            {
                case 1: editor.AddState(); break;
                case 2: editor.Undo(); break;
                case 3: editor.Redo(); break;
                case 4: editor.ShowCurrent(); break;
                case 5: return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }
}
