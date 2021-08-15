// ReSharper disable file CommentTypo

using System;
using System.IO;
using System.Linq;

namespace task_3
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        private static void Main()
        {
            /*
             * For the purposes of this task, a word will be taken to be any group of alphanumeric characters separated
             * by non-alphanumeric characters. This means that supercalifragilisticexpialidocious is a word, as is
             * programmingtask3, but programming_task_3 is 3 separate words. 'this.' is a 4-letter word, and
             * 'this16letterword' is indeed 16 letters long. Double spaces, or repeated punctuation will not count as
             * having any extra empty words. I hope that clears stuff up a little.
             */
            string text;
            try
            {
                text = File.ReadAllText(
                    $"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}/in.txt");
                // ^ Thank you to [this SO answer](https://stackoverflow.com/a/11882118)
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Failed to get project directory");
                Environment.Exit(1);
                return;
            }
            var characters = text.ToCharArray().Select(character => char.IsLetterOrDigit(character) ? character : '-');
            text = new string(characters.ToArray());
            // ^ Replace all non-alphanumeric characters in the list with - so it's easier to split them
            var words = Array.FindAll(text.Split('-'), word => word != "");
            // ^ Get all non-empty words

            Console.WriteLine($"There are {words.Length} words in the file");

            var averageLength = words.Select(word => (double)word.Length).Sum() / words.Length;
            Console.WriteLine($"The average length of a word in the file is {averageLength}");

            var sameWordGroups = words.GroupBy(word => word.ToLower()).ToArray();
            Array.Sort(sameWordGroups, (group1, group2) => group2.Count() - group1.Count());
            var sameWords = sameWordGroups.Select(group => $"{group.Key}: {group.Count()}");
            Console.WriteLine("The words used (along with their frequencies) are as follows. These are lowercase and in order of number of uses (highest first): " + string.Join(", ", sameWords));
            
            var sameStartLetterGroups = words.GroupBy(word => word.ToLower().ToCharArray()[0]).ToArray();
            Array.Sort(sameStartLetterGroups, (group1, group2) => group1.Key - group2.Key);
            var sameStartLetters = sameStartLetterGroups.Select(group => $"{group.Key}: {group.Count()}");
            Console.WriteLine("The start characters of words with frequencies are as follows (alphabetical order): " + string.Join(", ", sameStartLetters));
        }
    }
}