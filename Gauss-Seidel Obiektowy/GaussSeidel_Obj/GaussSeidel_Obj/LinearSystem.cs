public class LinearSystem
{
    // Macierz A, wektor B i wektor X to dane układu równań
    public double[,] A { get; set; }
    public double[] B { get; set; }
    public double[] X { get; set; }
    // Eps to tolerancja błędu dla metody Gaussa-Seidela
    public double Eps { get; set; }

    // Metoda do wczytywania danych od użytkownika
    public void ReadFromConsole()
    {
        Console.WriteLine("Podaj liczbę równań:");
        string input = Console.ReadLine();
        // Sprawdzamy, czy dane wejściowe są null
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }
        int n = int.Parse(input);

        A = new double[n, n];
        B = new double[n];
        X = new double[n];

        //Ustawienie tolerancji błędu na 0.001
        Eps = 0.001;

        // Dla każdego równania...
        for (int i = 0; i < n; i++)
        {
            // Prosimy użytkownika o podanie współczynników
            Console.WriteLine($"Podaj  {n} współczynniki równania {i + 1}:");
            for (int j = 0; j < n; j++)
            {
                input = Console.ReadLine();
                // Sprawdzamy, czy dane wejściowe są null
                if (input == null)
                {
                    throw new ArgumentNullException(nameof(input));
                }
                A[i, j] = double.Parse(input);
            }
            // Prosimy użytkownika o podanie wyrazu wolnego
            Console.WriteLine("Podaj wyraz wolny:");
            input = Console.ReadLine();
            // Sprawdzamy, czy dane wejściowe są null
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            B[i] = double.Parse(input);
        }
    }

    // Metoda do rozwiązania układu równań za pomocą metody Gaussa-Seidela
    public void SolveByGaussSeidel()
    {
        // Sprawdzamy, czy wektory B i X są null
        if (B == null || X == null)
        {
            throw new ArgumentNullException(B == null ? nameof(B) : nameof(X));
        }

        int n = B.Length;
        int maxIterations = 10000;  // Maksymalna liczba iteracji
        int iteration = 0;  // Aktualna liczba iteracji

        // Rozpoczynamy iteracje
        while (true)
        {
            double[] newX = new double[n];
            for (int i = 0; i < n; i++)
            {
                double sum = B[i];
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                        sum -= A[i, j] * X[j];  // Używamy starego X zamiast nowego
                }
                newX[i] = sum / A[i, i];
            }

            // Obliczamy normę różnicy między starym a nowym wektorem X
            double norm = 0;
            for (int i = 0; i < n; i++)
            {
                norm += Math.Abs(newX[i] - X[i]);
            }

            // Jeśli norma jest mniejsza od zadanej tolerancji lub osiągnęliśmy maksymalną liczbę iteracji, kończymy iteracje
            if (norm < Eps || iteration >= maxIterations)
            {
                if (iteration >= maxIterations)
                {
                    Console.WriteLine($"Osiągnięto maksymalną liczbę iteracji ({maxIterations}).");
                    Console.WriteLine($"Norma: {norm}");
                    Console.WriteLine($"Dokładność: {Eps}");
                }
                break;
            }

            // Aktualizujemy wektor X
            X = newX;
            iteration++;
        }
    }
}