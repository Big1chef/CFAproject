using Nest;
using System;
using System.Collections.Generic;

namespace CFA.Services
{
    public class ScoreService : IScoreService
    {
        public int Add(string input, int score, int level)
        {
            Stack<char> group = new Stack<char>();


            // group starts
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{')
                {
                    group.Push('{');
                    level++;
                    continue;
                }
                else if (input[i] == '}')
                {

                    score = score + level;
                    //in case start with }
                    if (group.Count == 0)
                    {
                        level--;
                        continue;
                    }
                    group.Pop();
                    level--;
                    continue;
                }
                // after ! should be ignored
                else if (input[i] == '!')
                {
                    if (i <= input.Length - 2)
                    {
                        return score;
                    }
                    i++;
                    continue;
                }
                // garbage
                else if (input[i] == '<')
                {
                    i++;
                    i = Garbage(input, i, input.Length);
                }
                else
                {
                    continue;
                }
            }
            if(group.Count == 0 && level == 0)
            {
                return score;
            }
            return -1;
        }

        public int Garbage(string input , int current, int len)
        {
            while (input[current] != '>' && current <= len - 1)
            {
                if (input[current] == '!')
                {
                    current = current + 2;
                    continue;
                }

                current++;
            }

            if (input[current] == '>' && current <= len - 1)
            {
                return current;
            }
            if (current > len - 1)
            {
                return -1;
            }

            return -2;
        }
    }
}
