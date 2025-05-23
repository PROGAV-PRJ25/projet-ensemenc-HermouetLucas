// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;

Console.WriteLine("Hello, World!");
//CODE TEST PAS TOUCHE
Maladie[] t = new Maladie[8];
t[1] = new Maladie("Oïdium");
t[2] = new Maladie("Oïdium");
t[3] = new Maladie("Oïdium");
t[4] = null;
t[5] = new Maladie("Oïdium");
t[6] = null;
t[7] = new Maladie("Oïdium");

foreach(Maladie m in t){
    Console.WriteLine("Hello");
}