string text = @"In object-oriented programming, encapsulation is a fundamental principle that involves bundling data and methods that operate on that data within a single unit or class. This concept allows for the hiding of implementation details from the outside world and exposing only the necessary interfaces for interacting with the object. By encapsulating data and methods together, we promote code reusability, maintainability, and flexibility.One of the key benefits of encapsulation is the ability to enforce access control on the members of a class. This means we can specify which parts of the class are accessible to the outside world and which are not. By using access modifiers such as public, private, and protected, we can control the visibility of members, ensuring that they are only accessed in appropriate ways. For example, we may have a class representing a bank account with properties such as balance and methods for depositing and withdrawing funds. By making the balance property private and providing public methods for depositing and withdrawing funds, we encapsulate the internal state of the account and ensure that it can only be modified in a controlled manner. Encapsulation also allows us to enforce data validation and maintain invariants within our classes. By providing controlled access to data through methods, we can ensure that it is always in a valid state. For instance, when setting the balance of a bank account, we can check that the new balance is not negative before updating the internal state of the object. Overall, encapsulation is a powerful concept in object-oriented programming that promotes modularity, reusability, and maintainability. By bundling data and methods together within a class and controlling access to them, we can create more robust and flexible software systems.";

//- Display the word count of this string
//- Display the sentence count of this string
//- Display how often the word "encapsulation" appears in this string 
//- Display this string in reverse, without using any C# language feature. (Create your own algorith)
//- In the given string, replace all occurances of "object-oriented programming" with "OOP" and display the new string

int wordCount = text
    .Split(new[] { ' ', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
    .Length;

int sentenceCount = text
    .Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
    .Length;

int encapsulationCount = text
    .Split(["encapsulation"], StringSplitOptions.RemoveEmptyEntries)
    .Length - 1;

string replacedText = text.Replace("object-oriented programming", "OOP");
string reversedText = ReverseString(text);

DisplayResults();

string ReverseString(string text)
{
    var list = text.ToList();

    for (int i = 0; i < list.Count / 2; i++)
    {
        var temp = list[i];
        list[i] = list[list.Count - i - 1];
        list[list.Count - i - 1] = temp;
    }

    return string.Join("", list);
}

void DisplayResults()
{
    Console.WriteLine("Word Count: " + wordCount);
    Console.WriteLine("Sentence Count: " + sentenceCount);
    Console.WriteLine("Occurrences of 'encapsulation': " + encapsulationCount);
    Console.WriteLine();
    Console.WriteLine("Replaced Text: ");
    Console.WriteLine(replacedText);
    Console.WriteLine();
    Console.WriteLine("Reversed Text: ");
    Console.WriteLine(reversedText);
    Console.ReadKey();
}
