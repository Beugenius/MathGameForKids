using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
	/// <summary>
	/// The class that holds all of the game logic / represents the game 
	/// </summary>
	public class Game
	{
		/// <summary>
		/// Generated List of Problems to display to user
		/// </summary>
		public List<Problem> ProblemsList = new();
		/// <summary>
		/// User class that stores user information.
		/// Name, Age
		/// </summary>
		public User User = new();
		/// <summary>
		/// Nullable ScoreCard for saving users score and information 
		/// </summary>
		public ScoreCard? ScoreCard;
		/// <summary>
		/// List of top ten high scores used for high scores window 
		/// </summary>
		public List<ScoreCard> TopTenHighScores = new();
		/// <summary>
		/// Enumarator for declaring game type 
		/// </summary>
		public GameType GameTypeEnum;
		/// <summary>
		/// Integer for tracking index of current problem in the list 
		/// </summary>
		public int ProblemIndexInt = 0;
		/// <summary>
		/// Integer representation of problems user guessed correctly in current game 
		/// </summary>
		public int ProblemsGuessedCorrectlyInt = 0;
		/// <summary>
		/// Enum for type of game user wants to play 
		/// </summary>
		public enum GameType
		{
			Add,
			Subtract,
			Multiply,
			Divide,
			None
		}
		/// <summary>
		/// Called once game is over to add score cards, create top 10 scores list, and re-initalize game values if user plays again
		/// </summary>
		/// <param name="SecondsPassedInt">Representation of time elapsed for users game</param>
		/// <exception cref="Exception"></exception>
		public void FinishGame(int SecondsPassedInt)
		{
			try
			{
				SetAndAddScoreCard(SecondsPassedInt);
				SetTopTenHighScores();
				InitializeGameValues();
			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}
		/// <summary>
		/// Resets the game variables to initial state for next game played 
		/// </summary>
		/// <exception cref="Exception"></exception>
		private void InitializeGameValues()
		{
			try
			{
				ProblemIndexInt = 0;
				ProblemsGuessedCorrectlyInt = 0;
			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}
		/// <summary>
		/// Sets TopTenHighScores list based off score first and then time
		/// </summary>
		/// <exception cref="Exception"></exception>
		private void SetTopTenHighScores()
		{
			try
			{
				TopTenHighScores = HighScores.ScoreCards.OrderByDescending(x => x.ScoreInt).ThenBy(x => x.TimeInt).Take(10).ToList();
			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}
		/// <summary>
		/// Creates a new score card and adds it into the list of saved scores 'ScoreCards'
		/// </summary>
		/// <param name="secondsPassedInt"></param>
		/// <exception cref="Exception"></exception>
		private void SetAndAddScoreCard(int secondsPassedInt)
		{
			try
			{
				ScoreCard = new()
				{
					NameString = User.NameString,
					AgeInt = User.AgeInt,
					ScoreInt = ProblemsGuessedCorrectlyInt,
					TimeInt = secondsPassedInt
				};
				HighScores.ScoreCards.Add(ScoreCard);
			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}
		/// <summary>
		/// Sets the users information to an instance of User 
		/// </summary>
		/// <param name="NameString">String value for users name</param>
		/// <param name="AgeInt">Integer value for users age</param>
		/// <exception cref="Exception"></exception>
		public void SetUser(string NameString, int AgeInt)
		{
			try
			{
				User.NameString = NameString;
				User.AgeInt = AgeInt;
			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}
		/// <summary>
		/// Sets the game up by the type of game the user selected
		/// </summary>
		/// <exception cref="Exception"></exception>
		public void SetUpGameByTypeSelected()
		{
			try
			{
				ProblemsList = GetProblems(GameTypeEnum);
			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}
		/// <summary>
		/// Returns the string representation of the current problem 
		/// </summary>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public string GetProblemString()
		{
			try
			{
				return ProblemsList[ProblemIndexInt].ProblemString;
			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}
		/// <summary>
		/// Advances the problem list to the next problem 
		/// </summary>
		/// <exception cref="Exception"></exception>
		public void NextProblem()
		{
			try
			{
				++ProblemIndexInt;
			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}
		/// <summary>
		/// Increments ProblemsGuessedCorrectlyInt 
		/// </summary>
		/// <exception cref="Exception"></exception>
		public void UserGuessedCorrect()
		{
			try
			{
				++ProblemsGuessedCorrectlyInt;
			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}
		/// <summary>
		/// Returns whether or not the user's answer is correct 
		/// </summary>
		/// <param name="userAnswerInt">Integer for user's answer</param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public bool IsCorrect(int userAnswerInt)
		{
			try
			{
				if (userAnswerInt == ProblemsList[ProblemIndexInt].SolutionInt)
				{
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}
		/// <summary>
		/// Helper method to retrieve list of problems by game type 
		/// </summary>
		/// <param name="gameType">Enum representation of type of game</param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		private List<Problem> GetProblems(GameType gameType)
		{
			try
			{
				switch (gameType)
				{
					case GameType.Add:
						return GetAdditionProblems();
					case GameType.Subtract:
						return GetSubtractionProblems();
					case GameType.Multiply:
						return GetMultiplicationProblems();
					case GameType.Divide:
						return GetDivisionProblems();
					default:
						return new();
				}
			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}
		/// <summary>
		/// Gets the list of addition problems 
		/// </summary>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		private List<Problem> GetAdditionProblems()
		{
			try
			{
				List<Problem> ProblemsToReturn = new();
				for (int i = 0; i < 10; ++i)
				{
					Problem ProblemToAdd = new();
					ProblemToAdd.FirstNumberInt = new Random().Next(1, 10);
					ProblemToAdd.SecondNumberInt = new Random().Next(1, 10);
					ProblemToAdd.SolutionInt = ProblemToAdd.FirstNumberInt + ProblemToAdd.SecondNumberInt;
					ProblemToAdd.ProblemString = $"{ProblemToAdd.FirstNumberInt} + {ProblemToAdd.SecondNumberInt} = ";
					ProblemsToReturn.Add(ProblemToAdd);
				}
				return ProblemsToReturn;
			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}
		/// <summary>
		/// Returns the list of subtraction problems 
		/// </summary>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		private List<Problem> GetSubtractionProblems()
		{
			try
			{
				List<Problem> ProblemsToReturn = new();
				for (int i = 0; i < 10; ++i)
				{
					Problem ProblemToAdd = new();
					ProblemToAdd.FirstNumberInt = new Random().Next(1, 10);
					ProblemToAdd.SecondNumberInt = new Random().Next(1, 10);
					// if first number is larger than second, swap to avoid negative number 
					if (ProblemToAdd.FirstNumberInt < ProblemToAdd.SecondNumberInt)
					{
						int placeholder = ProblemToAdd.FirstNumberInt;
						ProblemToAdd.FirstNumberInt = ProblemToAdd.SecondNumberInt;
						ProblemToAdd.SecondNumberInt = placeholder;
					}
					ProblemToAdd.SolutionInt = ProblemToAdd.FirstNumberInt - ProblemToAdd.SecondNumberInt;
					ProblemToAdd.ProblemString = $"{ProblemToAdd.FirstNumberInt} - {ProblemToAdd.SecondNumberInt} = ";

					ProblemsToReturn.Add(ProblemToAdd);
				}
				return ProblemsToReturn;
			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}
		/// <summary>
		/// Returns the list of multiplication problems 
		/// </summary>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		private List<Problem> GetMultiplicationProblems()
		{
			try
			{
				List<Problem> ProblemsToReturn = new();
				for (int i = 0; i < 10; ++i)
				{
					Problem ProblemToAdd = new();
					ProblemToAdd.FirstNumberInt = new Random().Next(1, 10);
					ProblemToAdd.SecondNumberInt = new Random().Next(1, 10);
					ProblemToAdd.SolutionInt = ProblemToAdd.FirstNumberInt * ProblemToAdd.SecondNumberInt;
					ProblemToAdd.ProblemString = $"{ProblemToAdd.FirstNumberInt} * {ProblemToAdd.SecondNumberInt} = ";
					ProblemsToReturn.Add(ProblemToAdd);
				}
				return ProblemsToReturn;
			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}
		/// <summary>
		/// Returns the list of division problems 
		/// </summary>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		private List<Problem> GetDivisionProblems()
		{
			try
			{
				List<Problem> ProblemsToReturn = new();
				for (int i = 0; i < 10; ++i)
				{
					Problem ProblemToAdd = new();
					ProblemToAdd.SolutionInt = new Random().Next(1, 10);
					ProblemToAdd.SecondNumberInt = new Random().Next(1, 10);
					ProblemToAdd.FirstNumberInt = ProblemToAdd.SolutionInt * ProblemToAdd.SecondNumberInt;
					ProblemToAdd.ProblemString = $"{ProblemToAdd.FirstNumberInt} / {ProblemToAdd.SecondNumberInt} = ";

					ProblemsToReturn.Add(ProblemToAdd);
				}
				return ProblemsToReturn;
			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}
	}
}
