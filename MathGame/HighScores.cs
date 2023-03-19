using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
	/// <summary>
	/// HighScores class that holds all of the scores in a game
	/// </summary>
	public class HighScores
	{
		/// <summary>
		/// List of all scores in the game 
		/// </summary>
		public static List<ScoreCard> ScoreCards { get; set; } = new();
	}
}
