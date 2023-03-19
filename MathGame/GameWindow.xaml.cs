using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MathGame
{
	/// <summary>
	/// Interaction logic for GameWindow.xaml
	/// </summary>
	public partial class GameWindow : Window
	{
		/// <summary>
		/// Current game 
		/// </summary>
		private Game CurrentGame;
		/// <summary>
		/// Timer to count time elapsed 
		/// </summary>
		DispatcherTimer GameTimer;
		/// <summary>
		/// Integer tracker of seconds passed 
		/// </summary>
		private int SecondsPassedInt = 1;
		/// <summary>
		/// Bool to indicate whether the game has started 
		/// </summary>
		public bool GameStartedBool = false;
		/// <summary>
		/// Soundplayer to play correct sound if user guesses correctly
		/// </summary>
		private SoundPlayer CorrectSound;
		/// <summary>
		/// Soundplayer to play incorrect sound if user guesses incorrectly 
		/// </summary>
		private SoundPlayer IncorrectSound;
		/// <summary>
		/// GameWindow constructor 
		/// </summary>
		/// <param name="game">Instance of the current game passed in from main</param>
		public GameWindow(Game game)
		{
			try
			{
				InitializeComponent();
				CurrentGame = game;
				GameTimer = new DispatcherTimer();
				GameTimer.Interval = TimeSpan.FromSeconds(1);
				GameTimer.Tick += new EventHandler(Timer);
				CorrectSound = new SoundPlayer("Correct.wav");
				IncorrectSound = new SoundPlayer("Incorrect.wav");
			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				HandleException(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
			}
		}
		/// <summary>
		/// Starts the game and sets up the UI components to display 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StartGameButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				// Set UI components to visible after game has started
				GameStartedBool = true;
				StartGameButton.Visibility = Visibility.Hidden;
				DisplayProblemLabel.Visibility = Visibility.Visible;
				UserAnswerTextBox.Visibility = Visibility.Visible;
				SubmitAnswerButton.Visibility = Visibility.Visible;
				GameStatsGroupBox.Visibility = Visibility.Visible;
				// Set up game
				SetupProblem();
				// Start timer 
				GameTimer.Start();
				// Have the text box be empty and focused 
				UserAnswerTextBox.Text = string.Empty;
				UserAnswerTextBox.Focus();
			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				HandleException(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
			}
		}
		/// <summary>
		/// Method for incrementing timer every second
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <exception cref="Exception"></exception>
		void Timer(object sender, EventArgs e)
		{
			try
			{
				TimerLabel.Content = SecondsPassedInt;
				++SecondsPassedInt;
			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}
		/// <summary>
		/// Method for when user submits an answer
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SubmitAnswerButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				// int to store user answer 
				int userAnswerInt;
				// check if user input is valid 
				if (int.TryParse(UserAnswerTextBox.Text, out userAnswerInt))
				{
					// check if answer correct 
					if (CurrentGame.IsCorrect(userAnswerInt))
					{
						// play correct sound
						CorrectSound.Play();
						// display correct guess
						ErrorLabel.Foreground = Brushes.Green;
						ErrorLabel.Content = "Good job! That's right!";
						// update problems guessed correctly
						CurrentGame.UserGuessedCorrect();
					}
					// else incorrect answer 
					else
					{
						// play incorrect sound
						IncorrectSound.Play();
						// display invalid guess 
						ErrorLabel.Foreground = Brushes.Red;
						ErrorLabel.Content = "Uh oh! Better luck next time!";
					}
					if (CurrentGame.ProblemIndexInt < 9)
					{
						// Go to the next problem
						CurrentGame.NextProblem();
						// Set up the problem 
						SetupProblem();
						// Have the text box be focused 
						UserAnswerTextBox.Text = string.Empty;
						UserAnswerTextBox.Focus();
						// set up the game stats 
						ProblemNumberLabel.Content = CurrentGame.ProblemIndexInt + 1;
						GuessedRightLabel.Content = CurrentGame.ProblemsGuessedCorrectlyInt;
						GuessedWrongLabel.Content = CurrentGame.ProblemIndexInt - CurrentGame.ProblemsGuessedCorrectlyInt;
					}
					else
					{
						GameTimer.Stop();
						// finish the game 
						CurrentGame.FinishGame(SecondsPassedInt);
						this.Hide();
						var highScoreWindow = new HighScoreWindow(CurrentGame, true);
						highScoreWindow.ShowDialog();
						this.Close();
					}
				}
				// user input invalid 
				else
				{
					ErrorLabel.Content = "Type your answer in the box! :)";
					// Have the text box be focused 
					UserAnswerTextBox.Focus();
				}
			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				HandleException(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
			}
		}
		/// <summary>
		/// Method that gets the problem string from the problem in the game class and displays it to the user 
		/// </summary>
		/// <exception cref="Exception"></exception>
		private void SetupProblem()
		{
			try
			{
				DisplayProblemLabel.Content = CurrentGame.GetProblemString();
			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}

		/// <summary>
		/// Method that validates user input so that nothing other than numbers, enter, and backspace or delete is allowed to be entered
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UserAnswerTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				// Only allow numbers to be entered -- copied from lecture! 
				if (!((e.Key >= Key.D0 && e.Key <= Key.D9) || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
				{
					// Allow the  user to use the backspace and delete keys
					if (!(e.Key == Key.Back || e.Key == Key.Delete))
					{
						// No other keys allowed besides numbers, backspace, and delete
						// allow submission with enter key
						if (e.Key == Key.Enter)
						{
							SubmitAnswerButton_Click(sender, e);
						}
						e.Handled = true;
					}
				}
			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				HandleException(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
			}
		}
		/// <summary>
		/// Method that displays to the user that an exception has occurred
		/// </summary>
		/// <param name="classString">Name of class where exception thrown</param>
		/// <param name="methodString">Name of method where exception throw</param>
		/// <param name="messageString">Message passed up from where exception thrown</param>
		private void HandleException(string classString, string methodString, string messageString)
		{
			try
			{
				MessageBox.Show("Uhoh! Something went wrong. Please check everything is entered correctly and try again! :)");
			}
			catch (Exception ex)
			{
				MessageBox.Show(classString + "." + methodString + " -> " + messageString); 
			}
		}
	}
}
