using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Scores
    {
        private static int score = 0;
       
        public static int Score
        {
            get { return score; }
            set { score = value; }
        }
    }
}
