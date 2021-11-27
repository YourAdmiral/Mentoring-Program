ShowMessage(GetName());

string GetName()
{
    Console.WriteLine("Write your Name:");

    return Console.ReadLine();
}

void ShowMessage(string name)
{
    Console.WriteLine($"Hello {name}!");
}