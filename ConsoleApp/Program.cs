var obj1 = new Person() { Name = "Person 1" };
var obj2 = new Person() { Name = "Person 2" };
var obj3 = new Person() { Name = "Person 3" };

var propInfo = obj1.GetType().GetProperty("Name");
var value = propInfo.GetValue(obj1);
Console.WriteLine(value);

class Person
{
    public string Name { get; set; }
}
