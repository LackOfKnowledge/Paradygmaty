// OPIS
//Metoda Gaussa-Seidela to iteracyjna metoda numeryczna do rozwiązywania układów równań liniowych.
//W każdej iteracji, dla każdego równania, obliczamy nową wartość nieznanej na podstawie aktualnych wartości pozostałych niewiadomych.
//Iteracje kontynuujemy do momentu, gdy różnica mięcy kolejnymi przybliżeniami rozwiązania stanie się mniejsza od zadanej tolerancji błędu.
//W tym przypadku jest to przedstawione w duchu programowania imperatywno-strukturalnego.

namespace GaussSeidel_IS
{
    class Program
    {
        // Metoda do wczytywania danych od użytkownika
        static void ReadData(out double[,] A, out double[] B, out int n)
        {
            Console.WriteLine("Podaj liczbę równań:");
            n = int.Parse(Console.ReadLine());

            A = new double[n, n];
            B = new double[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Podaj {n} współczynniki równania {i + 1}:");
                for (int j = 0; j < n; j++)
                {
                    A[i, j] = double.Parse(Console.ReadLine());
                }
                Console.WriteLine("Podaj wyraz wolny:");
                B[i] = double.Parse(Console.ReadLine());
            }
        }

        // Metoda do rozwiązania układu równań za pomocą metody Gaussa-Seidela
        static void SolveByGaussSeidel(double[,] A, double[] B, double[] X, int n, double eps)
        {
            while (true)
            {
                double[] newX = new double[n];
                for (int i = 0; i < n; i++)
                {
                    double sum = B[i];
                    for (int j = 0; j < n; j++)
                    {
                        if (i != j)
                            sum -= A[i, j] * newX[j];
                    }
                    newX[i] = sum / A[i, i];
                }

                double norm = 0;
                for (int i = 0; i < n; i++)
                {
                    norm += Math.Abs(newX[i] - X[i]);
                }

                if (norm < eps)
                    break;

                X = newX;
            }
        }

        // Metoda do wyświetlania rozwiązania
        static void PrintSolution(double[] X, int n)
        {
            Console.WriteLine("Rozwiązanie:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("x{0} = {1}", i + 1, X[i]);
            }
        }

        static void Main()
        {
            try
            {
                ReadData(out double[,] A, out double[] B, out int n);  // Wczytujemy dane od użytkownika

                double[] X = new double[n];
                double eps = 0.001;

                SolveByGaussSeidel(A, B, X, n, eps);  // Rozwiązujemy układ równań

                PrintSolution(X, n);  // Wyświetlamy rozwiązanie
            }
            catch (Exception ex)
            {
                // Obsługujemy błędy, wyświetlając komunikat o błędzie
                Console.WriteLine("Wystąpił błąd: " + ex.Message);
            }
        }
    }
}