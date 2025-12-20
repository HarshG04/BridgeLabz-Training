using System;

class AccessModifier
{
    static void Main()
    {
        Console.WriteLine("===== ACCESS MODIFIERS DEMO =====");

        PublicExample pubObj = new PublicExample();
        pubObj.ShowPublic();

        PrivateExample privObj = new PrivateExample();
        privObj.AccessPrivate();

        ProtectedChild protObj = new ProtectedChild();
        protObj.ShowProtected();

        InternalExample intObj = new InternalExample();
        intObj.ShowInternal();

        ProtectedInternalChild picObj = new ProtectedInternalChild();
        picObj.ShowProtectedInternal();

 
    }
}

/* =========================
   PUBLIC ACCESS MODIFIER
   ========================= */
class PublicExample
{
    public int publicValue = 10;

    public void ShowPublic()
    {
        Console.WriteLine("\n[PUBLIC]");
        Console.WriteLine("Public value accessible everywhere: " + publicValue);
    }
}

/* =========================
   PRIVATE ACCESS MODIFIER
   ========================= */
class PrivateExample
{
    private int privateValue = 20;

    public void AccessPrivate()
    {
        Console.WriteLine("\n[PRIVATE]");
        Console.WriteLine("Private value accessed inside same class: " + privateValue);
    }
}

/* =========================
   PROTECTED ACCESS MODIFIER
   ========================= */
class ProtectedParent
{
    protected int protectedValue = 30;
}

class ProtectedChild : ProtectedParent
{
    public void ShowProtected()
    {
        Console.WriteLine("\n[PROTECTED]");
        Console.WriteLine("Protected value accessed in child class: " + protectedValue);
    }
}

/* =========================
   INTERNAL ACCESS MODIFIER
   ========================= */
class InternalExample
{
    internal int internalValue = 40;

    internal void ShowInternal()
    {
        Console.WriteLine("\n[INTERNAL]");
        Console.WriteLine("Internal value accessible in same project: " + internalValue);
    }
}

/* =========================
   PROTECTED INTERNAL
   ========================= */
class ProtectedInternalParent
{
    protected internal int piValue = 50;
}

class ProtectedInternalChild : ProtectedInternalParent
{
    public void ShowProtectedInternal()
    {
        Console.WriteLine("\n[PROTECTED INTERNAL]");
        Console.WriteLine("Protected internal value accessed: " + piValue);
    }
}
