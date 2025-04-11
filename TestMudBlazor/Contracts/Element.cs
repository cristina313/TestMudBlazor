namespace TestMudBlazor.Contracts;

public class Element
{
    public int Position { get; set; }
    public string Name { get; set; }
    public int Number { get; set; }


    public string Sign { get; set; }


    public Element(int number, string name, string sign, int position)
    {
        Number = number;
        Name = name;
        Sign = sign;
        Position = position;
    }

    public override string ToString()
    {
        return $"{Sign} - {Name}";
    }
}
