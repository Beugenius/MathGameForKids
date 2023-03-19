using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using System.Media;

namespace MathGame
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		/// <summary>
		/// Instance of the current game 
		/// </summary>
		public Game CurrentGame;
		/// <summary>
		/// Instance of the HighScores. Used to access the list of scores 
		/// </summary>
		public HighScores Scores;
		/// <summary>
		/// Soundplayer to play happy sound when game has started successfully 
		/// </summary>
		public SoundPlayer GameStarted;
		/// <summary>
		/// Constructor for the main window. Initializes game values and soundplayer. 
		/// </summary>
		public MainWindow()
		{
			try
			{
				InitializeComponent();
				CurrentGame = new();
				GameStarted = new SoundPlayer("GameStarted.wav");
			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				HandleException(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
			}
		}
		/// <summary>
		/// Method that handles user clicking start game. Checks user input and displays error labels if invalid input. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BeginGameButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				// clear error labels 
				ClearErrorLabels();
				CurrentGame.User.NameString = EnterNameTextBox.Text;
				int UserAgeInt = 3;
				bool IntParsedBool = int.TryParse(EnterAgeTextBox.Text, out UserAgeInt);
				// store user selections (name, age, game type) 
				if (CurrentGame.User.NameString == string.Empty)
				{
					NameAndAgeErrorLabel.Content = "Please enter your name to begin playing!";
				}
				else if (IntParsedBool == false || UserAgeInt < 3 || UserAgeInt > 10)
				{
					NameAndAgeErrorLabel.Content = IntParsedBool ? "Age must be between 3 and 10" : "Please enter your age to begin playing!";
				}
				else
				{
					CurrentGame.User.AgeInt = UserAgeInt;
					// set up game with game type 
					GetGameType();
					// Make sure user has made a selection
					if (CurrentGame.GameTypeEnum == Game.GameType.None)
					{
						SelectGameErrorLabel.Content = "Please select a game type";
					}
					else
					{
						// Play start sound
						GameStarted.Play();
						// clear error labels 
						ClearErrorLabels();
						// set up the game depending on the game type selected 
						CurrentGame.SetUpGameByTypeSelected();
						// open game window
						GameWindow gameWindow = new(CurrentGame);
						this.Hide();
						gameWindow.ShowDialog();
						this.Show();
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
		/// Method that handles user input for the EnterAgeTextBox. Guarantees only numbers, enter, and backspace/delete is allowed. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EnterAgeTextBox_KeyDown(object sender, KeyEventArgs e)
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
							BeginGameButton_Click(sender, e);
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
		/// Method that handles user input for the EnterNameTextBox. Guarantees only numbers, enter, and backspace/delete is allowed. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EnterNameTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				// Only allow letters to be entered 
				if (!(e.Key >= Key.A && e.Key <= Key.Z))
				{
					// Allow the  user to use the backspace and delete keys
					if (!(e.Key == Key.Back || e.Key == Key.Delete))
					{
						// No other keys allowed besides numbers, backspace, and delete
						// allow submission with enter key
						if (e.Key == Key.Enter)
						{
							BeginGameButton_Click(sender, e);
						}
						else if (e.Key == Key.Tab)
						{
							EnterAgeTextBox.Focus();
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
		/// Sets the game type based off of the user input. If radio button not selected, default to GameType.None. 
		/// </summary>
		/// <exception cref="Exception"></exception>
		private void GetGameType()
		{
			try
			{
				if (RadioButtonAdd.IsChecked == true)
				{
					CurrentGame.GameTypeEnum = Game.GameType.Add;
				}
				else if (RadioButtonSubtract.IsChecked == true)
				{
					CurrentGame.GameTypeEnum = Game.GameType.Subtract;
				}
				else if (RadioButtonMultiply.IsChecked == true)
				{
					CurrentGame.GameTypeEnum = Game.GameType.Multiply;
				}
				else if (RadioButtonDivide.IsChecked == true)
				{
					CurrentGame.GameTypeEnum = Game.GameType.Divide;
				}
				else
				{
					CurrentGame.GameTypeEnum = Game.GameType.None;
				}
			}
			catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}
		/// <summary>
		/// Clears the error labels from the UI
		/// </summary>
		/// <exception cref="Exception"></exception>
		private void ClearErrorLabels()
		{
			try
			{
				NameAndAgeErrorLabel.Content = string.Empty;
				SelectGameErrorLabel.Content = string.Empty;
			}
			catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}
		/// <summary>
		/// Method that allows the enter key to start the game from anywhere on the window by pressing enter 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainGrid_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				// allow submission with enter key
				if (e.Key == Key.Enter)
				{
					BeginGameButton_Click(sender, e);
				}

			}
			catch (Exception ex)
			{
				// Throw the exception with a message 
				HandleException(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
			}
		}
		/// <summary>
		/// Method that opens the highscores window when the high scores button is clicked. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HighScoresButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				ClearErrorLabels();
				this.Hide();
				HighScoreWindow HighScoresWin = new(CurrentGame);
				HighScoresWin.ShowDialog();
				this.Show();
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
