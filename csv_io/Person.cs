class Person
{
    private string name;
    private string nickName;
    private string position;

    public Person(string name, string nickName, string position)
    {
        this.name = name;
        this.nickName = nickName;
        this.position = position;
    }

    public string GetPersonInfo()
    {
        return String.Format("{0},{1},{2}", this.name, this.nickName, this.position);
    }

    public static string InputPersonInfo()
    {
        Console.WriteLine("Please input name, nickname and position: ");
        Person person = new Person(
            Console.ReadLine(),
            Console.ReadLine(),
            Console.ReadLine()
        );

        return person.GetPersonInfo();
    }
}