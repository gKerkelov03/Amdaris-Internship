using RepositoryPattern.Entities;
using RepositoryPattern.Repositories;

var workersRepository = new WorkersRepository();
Worker worker1 = new Worker("Georgi", 20, "Programmer");
Worker worker2 = new Worker("Pesho", 21, "Barber");
Worker worker3 = new Worker("Neli", 19, "Nail artist");

workersRepository.Add(worker1);
workersRepository.Add(worker2);
workersRepository.Add(worker3);

Console.WriteLine("All workers before manipulations: ");
workersRepository.ForEach(worker => Console.WriteLine($"{worker.Name}"));

workersRepository.RemoveById(worker1.Id);
workersRepository.Remove(worker2);
worker3.Name = "Neli Ivanova";
workersRepository.Update(worker3);


Console.WriteLine("All workers after manipulations: ");
workersRepository.ForEach(worker => Console.WriteLine($"{worker.Name}"));

