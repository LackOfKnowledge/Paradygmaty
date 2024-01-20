class Program
{
    static void Main()
    {
        try
        {
            //Tworzmy nowy obiekt klasy LinearSystem
            LinearSystem system = new LinearSystem();
            //Wczytujemy dane od użytkownika
            system.ReadFromConsole();
            //Rozwiązujemy równanie
            system.SolveByGaussSeidel();
            //Wyświetlamy rozwiązanie
            Console.WriteLine("Rozwiązanie:");
            for (int i = 0; i < system.X.Length; i++)
            {
                Console.WriteLine("x{0} = {1}", i + 1, system.X[i]);
            }
        }
        catch (Exception ex)
        {
            //Ewentualna obsługa błędu
            Console.WriteLine("Wystąpił błąd: " + ex.Message);
        }
    }
}
