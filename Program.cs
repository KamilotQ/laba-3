using System;
using System.IO;

namespace L3
{
    public class Program
    {
        static void Main()
        {
            Program p = new Program();
            string task;
            do
            {
                Console.WriteLine("\nWhat task do you need?\nPrint '0' to exit.");
                task = Console.ReadLine();
                switch (task)
                {
                    case "0": break;
                    case "1": p.first(); break;
                    case "2": p.second(); break;
                    case "3": p.third(); break;
                    default: Console.WriteLine("Try again. (tasks '1', '2', '3' are available and '0' to exit)"); break;
                }
            } while (task != "0");

        }
        public void first()
        {
            Console.WriteLine("\n\t\t1\n\n");
            string sen = "";
            while (sen.Length == 0)
            {
                Console.WriteLine("Enter a sentence:");
                sen = Console.ReadLine();
            }
            char[] s = sen.ToCharArray();
            string[] se = sen.Split();
            int r = s.Length;
            int m = se.Length;
            int kil = 0;
            bool ok = false;
            int u = 0;
            int[] tempi = new int[se.Length];
            for (int i = 0; i < r; i++) if (char.IsNumber(s[i])) kil++;
            for (int i = 0; i < m; i++)
            {
                char[] temp = se[i].ToCharArray();
                for (int j = 0; j < se[i].Length; j++)
                {
                    if ((char.IsLetter(temp[j]))&&(!ok))
                    {
                        ok = true;
                        switch (temp[j])
                        {
                            case 'a': break;
                            case 'e': break;
                            case 'i': break;
                            case 'o': break;
                            case 'u': break;
                            case 'A': break;
                            case 'E': break;
                            case 'I': break;
                            case 'O': break;
                            case 'U': break;
                            default: tempi[u] = i;  u++;  break;
                        }
                    }
                }
                ok = false;
            }
            Console.WriteLine("\nThe number(s) in the text:  " + kil);
            Console.WriteLine("\nThe word(s) that begin with consonant:  ");
            for (int i = 0; i < u; i++)
            {
                Console.WriteLine(se[tempi[i]]);
            }
            Console.WriteLine("______________________________________________________________________________\n");
        }
        public void second()
        {
            Console.WriteLine("\n\n\n\t\t2\n\n");
            var fileStream = new FileStream(@"1.txt", FileMode.Open);
            using var f = new StreamReader(fileStream);
            string mains = f.ReadLine();
            Console.WriteLine(mains);
            char[] temps = mains.ToCharArray();
            int a_c = 0, e_c = 0, i_c = 0, o_c = 0, u_c = 0;
            int l = mains.Length;
            for (int i = 0; i < l; i++)
            {
                switch (temps[i])
                {
                    case 'a': a_c++;  break;
                    case 'e': e_c++;  break;
                    case 'i': i_c++;  break;
                    case 'o': o_c++;  break;
                    case 'u': u_c++;  break;
                    case 'A': a_c++;  break;
                    case 'E': e_c++;  break;
                    case 'I': i_c++;  break;
                    case 'O': o_c++;  break;
                    case 'U': u_c++;  break;
                    default: break;
                }
            }
            Console.WriteLine("\nThe number of specific vowel letters in the text: ");
            Console.WriteLine("\nAa = " + a_c + "     Ee = " + e_c + "     Ii = " + i_c + "     Oo = " + o_c + "     Uu = " + u_c);
            f.Close();
            Console.WriteLine("______________________________________________________________________________\n");
        }
        public void third()
        {
            Console.WriteLine("\n\n\n\t\t3\n\n");

            var fileStream = new FileStream(@"input.txt", FileMode.Open);
            using var f = new StreamReader(fileStream);
            StreamWriter p = new StreamWriter("output.txt");
            string mains = f.ReadLine();
            Console.WriteLine(mains);
            p.WriteLine(mains + "\n");
            string[] se = mains.Split();
            int m = se.Length;
            bool word = false;
            int k = 0;
            int nuz = 0;
            int[] tempi = new int[se.Length];
            int u = 0;
            for (int i = 0; i < m; i++)
            {
                char[] temp = se[i].ToCharArray();
                for (int j = 0; j < se[i].Length; j++)
                {
                    if (char.IsLetter(temp[j]))
                    {
                        switch (temp[j])
                        {
                            case 'a': break;
                            case 'e': break;
                            case 'i': break;
                            case 'o': break;
                            case 'u': break;
                            case 'A': break;
                            case 'E': break;
                            case 'I': break;
                            case 'O': break;
                            case 'U': break;
                            default: nuz++; break;
                        }
                    }
                }
                if (!(nuz%2==0))
                {
                    tempi[u] = i;
                    u++;
                }
                nuz = 0;
            }
            Console.WriteLine("\n\n\nAfter deleting words with the odd number of consonants: \n");
            p.WriteLine("\n");
            int som = 0;
            for (int i = 0; i < m; i++)
            {
                if (!Array.Exists(tempi, som => som == i))
                {
                    Console.Write(se[i] + " ");
                    p.Write(se[i] + " ");
                }
            }
            int[] tempe = new int[se.Length];
            int y = 0;
            bool ok = false;
            for (int i = 0; i < m; i++)
            {
                char[] temp = se[i].ToCharArray();
                string ex = "";
                for (int j = 0; j < se[i].Length; j++)
                {
                    if (char.IsLetterOrDigit(temp[j])) ex += temp[j];
                }
                if (ex.Length > 0)
                {

                    string first = ex.Substring(0, ex.Length / 2);
                    char[] arr = ex.ToCharArray();

                    Array.Reverse(arr);

                    string tei = new string(arr);
                    string second = tei.Substring(0, tei.Length / 2);

                    if (first.Equals(second))
                    {
                        ok = true;
                        tempe[y] = i;
                        y++;
                    }

                }
            }
            Array.Resize(ref tempe, y);
            Console.WriteLine("\n\n\n\nAfter deleting palindromes: \n");
            p.WriteLine("\n");
            if (ok)
            {
                for (int i = 0; i < m; i++)
                {
                    if (!Array.Exists(tempe, om => om == i))
                    {
                        Console.Write(se[i] + " ");
                        p.Write(se[i] + " ");
                    }
                }
            }
            else Console.WriteLine(mains);
            f.Close();
            p.Close();
            Console.WriteLine("\n______________________________________________________________________________\n");
        }
    }
}
