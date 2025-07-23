var students = new[]
{
    "Arlennys Maria Garcia Reyes",
    "Augusto Martinez Abreu",
    "Jeffry Diaz",
    "Dorley El Roi Tessa",
    "Oscar Roger Fanfan Nuñez",
    "Gary Modesto Gomez Maldonado",
    // "Bryant Tejeda Florimon",
    // "Carlo Manuel Cabrera Cabral",
    "Wilnorvel Alexander Silverne",
    "Luis Antonio Vargas Vizcaino"
};

var random = new Random();
var randomIndex = random.Next(0, students.Length);

var chosen = students[randomIndex];

Console.WriteLine($"{chosen} is the chosen!");