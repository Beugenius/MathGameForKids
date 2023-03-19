using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
	/// <summary>
	/// ScoreCard class for representing a user and their score from a game. 
	/// </summary>
	public class ScoreCard
	{
		/// <summary>
		/// User's name to be saved
		/// </summary>
		public string NameString { get; set; }
		/// <summary>
		/// Users age to be saved
		/// </summary>
		public int AgeInt { get; set; }
		/// <summary>
		/// Users score to be saved
		/// </summary>
		public int ScoreInt { get; set; }
		/// <summary>
		/// Users time taken to complete game to be saved
		/// </summary>
		public int TimeInt { get; set; }

	}
}
