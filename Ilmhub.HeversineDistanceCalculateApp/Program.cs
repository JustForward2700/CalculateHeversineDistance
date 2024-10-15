using Ilmhub.HeversineDistanceCalculateApp;

System.Console.WriteLine("1-pointni koordinatalarin verugul bilan ajratib kiriting: ");
Coordinate pointOne = new Coordinate(Console.ReadLine());
System.Console.WriteLine("2-pointni koordinatalarin verugul bilan ajratib kiriting: ");
Coordinate pointTwo = new Coordinate(Console.ReadLine());
double distance = pointOne.GetHaversineDistance(pointTwo);
Console.WriteLine($"Natija: 1 va 2 pointlar orasidagi masofa {distance} Metr!");










