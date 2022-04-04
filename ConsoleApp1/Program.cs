// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

DataAccess data = new DataAccess();
Store store = new Store();

data.printUser();
Console.WriteLine("Hello, World!");
store.StatDelegate();

void printFromMain(string message)
{
    Console.WriteLine("hello delegate" +" : {0}",message);
}

store.DelegateImplement(printFromMain,"Main delegate");

store.DelegateInitInImplement(printFromMain, "another call back from implement");
