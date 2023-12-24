using System;

namespace AAE2023_Music_Player;

public class LevenshteinDistance
{
    // αυτή τη μαλακία δεν ξέρω καν γιατί την έκανα tbh, κανείς μας δεν ξέρει τίποτα απο Δυναμικό Προγραμματισμό (αν κάποιος ξέρει Μπράβο του)
    // χρειαζόμουν κάτι για search, ξέμεινε από τη προηγούμενη εργασία, το έβαλα, μάθετε τα σχόλια του chat απέξω μπας και καταλάβετε τι και πως, online θα είναι anyway
    
    // constructor(ας)
    
    public LevenshteinDistance()
    {

    }
    
    // public method
    
    public int Calculate(string s1, string s2)
    {
        return StringDistance(s1, s2);
    }
    
    
    // private static method to do the calculation using the dynamic programming algorithm of Levenshtein Distance
    
    private static int StringDistance(string s1, string s2)
    {
        int[,] d = new int[s1.Length + 1, s2.Length + 1];

        //This loop initializes the first column of the 2D array d with values from 0 to the length of s1.
        //It represents the cost of transforming an empty string to the corresponding prefix of s1.
        for (int i = 0; i <= s1.Length; i++)
            d[i, 0] = i;
        //Similarly, this loop initializes the first row of the 2D array d with values from 0 to the length of s2.
        //It represents the cost of transforming an empty string to the corresponding prefix of s2.
        for (int j = 0; j <= s2.Length; j++)
            d[0, j] = j;
        //These nested loops iterate over the 2D array d starting from the second row and second column.
        // The variable cost is set to 0 if the characters at the current positions in s1 and s2 are the same; otherwise, it is set to 1.
        // The value at position (i, j) in the array is then calculated based on the minimum of three possible operations:
        // 1. Deletion from s1 (top element): d[i - 1, j] + 1
        // 2. Insertion into s1 (left element): d[i, j - 1] + 1
        // 3. Substitution or match (diagonal element): d[i - 1, j - 1] + cost
        for (int i = 1; i <= s1.Length; i++)
        {
            for (int j = 1; j <= s2.Length; j++)
            {
                int cost = (s1[i - 1] == s2[j - 1]) ? 0 : 1;
                d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
            }
        }
        // Finally, the method returns the bottom-right element of the 2D array d,
        // which represents the minimum edit distance between the two input strings s1 and s2.
        return d[s1.Length, s2.Length];
    }

}