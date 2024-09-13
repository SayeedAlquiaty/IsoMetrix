using Microsoft.Extensions.DependencyInjection;
using MyApp.Services;
using System.Collections.Generic;

var serviceProvider = new ServiceCollection()
    .AddScoped<IStringCalculator, StringCalculator>()
    .AddScoped(typeof(IMyLinkedList<>), typeof(MyLinkedList<>))
    .BuildServiceProvider();

// Example of using the services
var stringCalculator = serviceProvider.GetService<IStringCalculator>();
Console.WriteLine($"Result of adding '1,2,3': {stringCalculator.Add("1,2,3")}");

var linkedList = serviceProvider.GetService<IMyLinkedList<int>>();
linkedList.Insert(1, 0);
linkedList.Insert(2, 1);
linkedList.PrintList();
