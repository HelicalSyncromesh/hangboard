using System;

namespace Timer.Models
{
    public class History
    {
        public History(int last,DateTime dateOfLast,int best,DateTime dateOfBest)
        {
            Last = last;
            DateOfLast = dateOfLast;
            Best = best;
            DateOfBest = dateOfBest;
        }
        public int Last { get; }
        public DateTime DateOfLast { get; }
        public int Best { get; }
        public DateTime DateOfBest { get; }
    }
}