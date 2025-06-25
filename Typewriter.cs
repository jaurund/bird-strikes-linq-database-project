using System;
using System.Threading;
Console.OutputEncoding = System.Text.Encoding.UTF8;


// This code is part of a text effects library that simulates a typewriter effect in the console.
public class TextEffects
{
    private static Random rand = new Random();

    public static double SpeedMultiplier { get; set; } = 1.0;

    public static void TypeWriter(string text, int baseDelay = 17) //This class adds a typewriter effect to the console output.
    {
        bool slowMode = false;

        for (int i = 0; i < text.Length; i++)
        {
            if (text.Substring(i).StartsWith("<slow>"))
            {
                slowMode = true;
                i += "<slow>".Length - 1;
                continue;
            }
            if (text.Substring(i).StartsWith("</slow>"))
            {
                slowMode = false;
                i += "</slow>".Length - 1;
                continue;
            }

            Console.Write(text[i]);

            int delay = (int)(baseDelay * SpeedMultiplier);
            if (slowMode)
            {
                delay *= 10; // slow mode = 4x base delay
            }
            if (text[i] == '.' || text[i] == ',' || text[i] == '!' || text[i] == '?')
            {
                delay *= 6; // punctuation in slow mode = 6x base delay
            }
            else if (char.IsWhiteSpace(text[i]))
            {
                delay *= 2; // whitespace in slow mode = 2x base delay
            }
            else if (!slowMode)
            {
                delay = rand.Next(delay, delay + 25);
            }

            Thread.Sleep(delay);
        }
        Console.WriteLine();
    }
}
