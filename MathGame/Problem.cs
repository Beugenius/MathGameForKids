using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    /// <summary>
    /// Problem class that represents a problem to be displayed to the user. 
    /// </summary>
    public class Problem
    {
        /// <summary>
        /// The first number in the problem 
        /// </summary>
        public int FirstNumberInt;
        /// <summary>
        /// The second number in the problem 
        /// </summary>
        public int SecondNumberInt;
        /// <summary>
        /// The solution to the problem
        /// </summary>
        public int SolutionInt;
        /// <summary>
        /// The string representation of the problem to be asked
        /// </summary>
        public string ProblemString; 
    }
}
