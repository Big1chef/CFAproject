using System;
using System.Collections.Generic;
using System.Text;

namespace CFA.Services
{
    public interface IScoreService
    {
        int Add(string input, int score, int level);
        int Garbage(string input, int current, int len);
    }
}
