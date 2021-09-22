// Dijkstra
using System;

public class DistanceCalculation
{
    int MinDistance(int[] dist,
                bool[] sptSet, int V)
    {
        // Initialize min value
        int min = int.MaxValue, min_index = -1;

        for (int v = 0; v < V; v++)
            if (sptSet[v] == false && dist[v] <= min)
            {
                min = dist[v];
                min_index = v;
            }

        return min_index;
    }

    public int GetMinimalDistance(int[,] dist, int cityIndex)
    {
        cityIndex = cityIndex - 1;

        var numberOfCities = (int)Math.Sqrt(dist.Length);
        int[] distances = new int[numberOfCities];
        var minimal = new bool[numberOfCities];

        for (var i = 0; i < numberOfCities; i++)
        {
            distances[i] = int.MaxValue;
            minimal[i] = false;
        }

        distances[0] = 0;

        for (var i = 0; i < numberOfCities; i++)
        {
            var index = MinDistance(distances, minimal, numberOfCities);
            minimal[index] = true;

            for (var u = 0; u < numberOfCities; u++)
            {
                if (!minimal[u] && dist[index, u] != 0 &&
                    distances[index] != int.MaxValue && distances[index] + dist[index, u] < distances[u])
                    distances[u] = distances[index] + dist[index, u];

            }
        }

        return distances[cityIndex];
    }


    public static void Main()
    {

        int[,] graph = new int[,] {

            //                        1 ,2, 3, 4, 5, 6, 7, 8,   9  
                                    { 0, 4, 0, 0, 0, 0, 0, 8,   0 }, //01
                                    { 4, 0, 8, 0, 0, 0, 0, 11,  0 }, //02
                                    { 0, 8, 0, 7, 0, 4, 0, 0,   2 }, //03
                                    { 0, 0, 7, 0, 9, 14, 0, 0,  0 }, //04
                                    { 0, 0, 0, 9, 0, 10, 0, 0,  0 }, //05
                                    { 0, 0, 4, 14, 10, 0, 2, 0, 0 }, //06
                                    { 0, 0, 0, 0, 0, 2, 0, 1,   6 }, //07
                                    { 8, 11, 0, 0, 0, 0, 1, 0,  7 }, //08
                                    { 0, 0, 2, 0, 0, 0, 6, 7,   0 } //09
                                 };

        int[,] graph2 = new int[,] {

            //                        1 ,2, 3, 4, 5, 6, 7, 8,  9  
                                    { 0, 2, 5, 2, 0, 0, 0, 0, 0},
                                    { 2, 0, 3, 0, 1, 0, 0, 0, 0},
                                    { 5, 3, 0, 3, 1, 1, 0, 1, 0},
                                    { 2, 0, 3, 0, 0, 0, 2, 0, 0},
                                    { 0, 1, 1, 0, 0, 0, 0, 0, 7},
                                    { 0, 0, 1, 0, 0, 0, 2, 3, 0},
                                    { 0, 0, 0, 2, 0, 2, 0, 0, 0},
                                    { 0, 0, 1, 0, 0, 3, 0, 0, 1},
                                    { 0, 0, 0, 0, 7, 0, 0, 1, 0 }
                                                                     };

        var lv = new DistanceCalculation();
        Console.WriteLine(lv.GetMinimalDistance(graph2, 9));
        Console.Read();
    }


}
