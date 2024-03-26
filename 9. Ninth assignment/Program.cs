
using System.Collections;

IEnumerable<int> sequence1 = Enumerable.Range(1, 50);
IEnumerable<int> sequence2 = Enumerable.Repeat(10, 50);
IEnumerable<int> sequence3 = Enumerable.Range(30, 40);
IEnumerable<Model> models1 = [
    new Model() { Name = "gosho", Age = 20 },
    new Model() { Name = "pesho", Age = 19 },
    new Model() { Name = "stancho", Age = 20 },
    new Model() { Name = "mitko", Age = 19 }
];
IEnumerable<Model> models2 = [
    new Model() { Name = "gosho", Age = 20 },
    new Model() { Name = "pesho", Age = 19 },
    new Model() { Name = "delqn", Age = 20 },
    new Model() { Name = "stanislav", Age = 19 }
];

Console.WriteLine("Sequence1: ");
Console.WriteLine(string.Join(",", sequence1));
Console.WriteLine("Sequence2: ");
Console.WriteLine(string.Join(",", sequence2));
Console.WriteLine("Sequence3: ");
Console.WriteLine(string.Join(",", sequence3));

var joinQuery = models1.Join(models2,
    (model1) => model1.Name,
    (model2) => model2.Name,
    (model1, model2) => $"we joined model with name {model1.Name} and model with name {model2.Name}\n");

Console.WriteLine("\nJoin Result:");
PrintSequence(joinQuery);


var zipQuery = sequence1.Zip(sequence3, (x, y) => x + y);
Console.WriteLine("\nZip Result:");
PrintSequence(zipQuery);

var groupByQuery = sequence1.GroupBy(x => x % 2 == 0 ? "Even" : "Odd");
Console.WriteLine("\nGroupBy Result:");
foreach (var group in groupByQuery)
{
    Console.WriteLine($"Key: {group.Key}, Values: {string.Join(", ", group)}");
}

var groupJoinQuery = models1.GroupJoin(
    models2,
    model1 => new { model1.Name },
    model2 => new { model2.Name },
    (model1, matchingModels) => new
    {
        Model1 = model1,
        MatchingModels2 = matchingModels
    }
);

var concatQuery = sequence1.Concat(sequence2);
Console.WriteLine("\nConcat Result:");
PrintSequence(concatQuery);

var unionQuery = sequence1.Union(sequence3);
Console.WriteLine("\nUnion Result:");
PrintSequence(unionQuery);


var intersectQuery = sequence1.Intersect(sequence3);
Console.WriteLine("\nIntersect Result:");
PrintSequence(intersectQuery);

var exceptQuery = sequence3.Except(sequence1);
Console.WriteLine("\nExcept Result:");
PrintSequence(exceptQuery);


IEnumerable<object> mixedList = [1, "two", 3, "four", 5];
var ofTypeQuery = mixedList.OfType<int>();
Console.WriteLine("\nOfType Result:");
PrintSequence(ofTypeQuery);


IEnumerable<object> objects = [1, 2, 3, 4, 5];
var castQuery = objects.Cast<int>();
Console.WriteLine("\nCast Result:");
PrintSequence(castQuery);


var toLookupQuery = sequence1.ToLookup(x => x % 2 == 0 ? "Even" : "Odd");
Console.WriteLine("\nToLookup Result:");
foreach (var group in toLookupQuery)
{
    Console.WriteLine($"Key: {group.Key}, Values: {string.Join(", ", group)}");
}


var dictionary = sequence1.ToDictionary(key => key, value => $"Item{value}");
Console.WriteLine("\nToDictionary Result:");
foreach (var kvp in dictionary)
{
    Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
}


var aggregateResult = sequence1.Aggregate((acc, curr) => acc + curr);
Console.WriteLine($"\nAggregate Result: {aggregateResult}");


bool sequenceEqualResult = sequence1.SequenceEqual(sequence2);
Console.WriteLine($"\nSequenceEqual Result: {sequenceEqualResult}");


int elementAtResult = sequence1.ElementAt(2);
Console.WriteLine($"\nElementAt Result: {elementAtResult}");

void PrintSequence<T>(IEnumerable<T> sequence)
{
    foreach (var item in sequence)
    {
        Console.Write($"{item} ");
    }

    Console.WriteLine();
}
