using System;
using System.Collections.Generic;
using System.Linq;
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

namespace MathGame
{
	/// <summary>
	/// Interaction logic for HighScoreWindow.xaml
	/// </summary>
	public partial class HighScoreWindow : Window
	{
		/// <summary>
		/// Private readonly copy of the game used for displaying high scores 
		/// </summary>
		private readonly Game _game;
		/// <summary>
		/// Boolean variable that determines whether or not the "Your Score" should display. 
		/// "Your Score" should not display if user goes to high score screen from main window.
		/// </summary>
		private bool UserScoreShouldDisplay;
		/// <summary>
		/// Constructor for the high score window that sets the instance of the game and whether or not to display the users current score. 
		/// </summary>
		/// <param name="Game"></param>
		/// <param name="DisplayUserScore"></param>
		public HighScoreWindow(Game Game, bool DisplayUserScore = false)
		{
			_game = Game;
			UserScoreShouldDisplay = DisplayUserScore;
			InitializeComponent();
			SetUpScores();
		}
		/// <summary>
		/// This method sets the labels for the entire page depending on the amount of highscores. 
		/// </summary>
		private void SetUpScores()
		{
			try
			{
				if (UserScoreShouldDisplay && _game.ScoreCard != null)
				{
					ScoreGroupBox.Visibility = Visibility.Visible;
					CurrentNameLabel.Content = _game.ScoreCard.NameString;
					CurrentAgeLabel.Content = _game.ScoreCard.AgeInt;
					CurrentCorrectLabel.Content = _game.ScoreCard.ScoreInt;
					CurrentIncorrectLabel.Content = 10 - _game.ScoreCard.ScoreInt;
					CurrentTimeLabel.Content = _game.ScoreCard.TimeInt;
				}
				else
				{
					ScoreGroupBox.Visibility = Visibility.Hidden;
				}
				switch (_game.TopTenHighScores.Count)
				{
					case 0:
						break;
					case 1:
						// Score 1
						NameLabel1.Content = _game.TopTenHighScores[0].NameString;
						AgeLabel1.Content = _game.TopTenHighScores[0].AgeInt;
						CorrectAnswersLabel1.Content = _game.TopTenHighScores[0].ScoreInt;
						IncorrectAnswersLabel1.Content = (10 - _game.TopTenHighScores[0].ScoreInt);
						TimeLabel1.Content = _game.TopTenHighScores[0].TimeInt;
						break;
					case 2:
						// Score 1
						NameLabel1.Content = _game.TopTenHighScores[0].NameString;
						AgeLabel1.Content = _game.TopTenHighScores[0].AgeInt;
						CorrectAnswersLabel1.Content = _game.TopTenHighScores[0].ScoreInt;
						IncorrectAnswersLabel1.Content = (10 - _game.TopTenHighScores[0].ScoreInt);
						TimeLabel1.Content = _game.TopTenHighScores[0].TimeInt;
						// Score 2
						NameLabel2.Content = _game.TopTenHighScores[1].NameString;
						AgeLabel2.Content = _game.TopTenHighScores[1].AgeInt;
						CorrectAnswersLabel2.Content = _game.TopTenHighScores[1].ScoreInt;
						IncorrectAnswersLabel2.Content = (10 - _game.TopTenHighScores[1].ScoreInt);
						TimeLabel2.Content = _game.TopTenHighScores[1].TimeInt;
						break;
					case 3:
						// Score 1
						NameLabel1.Content = _game.TopTenHighScores[0].NameString;
						AgeLabel1.Content = _game.TopTenHighScores[0].AgeInt;
						CorrectAnswersLabel1.Content = _game.TopTenHighScores[0].ScoreInt;
						IncorrectAnswersLabel1.Content = (10 - _game.TopTenHighScores[0].ScoreInt);
						TimeLabel1.Content = _game.TopTenHighScores[0].TimeInt;
						// Score 2
						NameLabel2.Content = _game.TopTenHighScores[1].NameString;
						AgeLabel2.Content = _game.TopTenHighScores[1].AgeInt;
						CorrectAnswersLabel2.Content = _game.TopTenHighScores[1].ScoreInt;
						IncorrectAnswersLabel2.Content = (10 - _game.TopTenHighScores[1].ScoreInt);
						TimeLabel2.Content = _game.TopTenHighScores[1].TimeInt;
						// Score 3
						NameLabel3.Content = _game.TopTenHighScores[2].NameString;
						AgeLabel3.Content = _game.TopTenHighScores[2].AgeInt;
						CorrectAnswersLabel3.Content = _game.TopTenHighScores[2].ScoreInt;
						IncorrectAnswersLabel3.Content = (10 - _game.TopTenHighScores[2].ScoreInt);
						TimeLabel3.Content = _game.TopTenHighScores[2].TimeInt;
						break;
					case 4:
						// Score 1
						NameLabel1.Content = _game.TopTenHighScores[0].NameString;
						AgeLabel1.Content = _game.TopTenHighScores[0].AgeInt;
						CorrectAnswersLabel1.Content = _game.TopTenHighScores[0].ScoreInt;
						IncorrectAnswersLabel1.Content = (10 - _game.TopTenHighScores[0].ScoreInt);
						TimeLabel1.Content = _game.TopTenHighScores[0].TimeInt;
						// Score 2
						NameLabel2.Content = _game.TopTenHighScores[1].NameString;
						AgeLabel2.Content = _game.TopTenHighScores[1].AgeInt;
						CorrectAnswersLabel2.Content = _game.TopTenHighScores[1].ScoreInt;
						IncorrectAnswersLabel2.Content = (10 - _game.TopTenHighScores[1].ScoreInt);
						TimeLabel2.Content = _game.TopTenHighScores[1].TimeInt;
						// Score 3
						NameLabel3.Content = _game.TopTenHighScores[2].NameString;
						AgeLabel3.Content = _game.TopTenHighScores[2].AgeInt;
						CorrectAnswersLabel3.Content = _game.TopTenHighScores[2].ScoreInt;
						IncorrectAnswersLabel3.Content = (10 - _game.TopTenHighScores[2].ScoreInt);
						TimeLabel3.Content = _game.TopTenHighScores[2].TimeInt;
						// Score 4
						NameLabel4.Content = _game.TopTenHighScores[3].NameString;
						AgeLabel4.Content = _game.TopTenHighScores[3].AgeInt;
						CorrectAnswersLabel4.Content = _game.TopTenHighScores[3].ScoreInt;
						IncorrectAnswersLabel4.Content = (10 - _game.TopTenHighScores[3].ScoreInt);
						TimeLabel4.Content = _game.TopTenHighScores[3].TimeInt;
						break;
					case 5:
						// Score 1
						NameLabel1.Content = _game.TopTenHighScores[0].NameString;
						AgeLabel1.Content = _game.TopTenHighScores[0].AgeInt;
						CorrectAnswersLabel1.Content = _game.TopTenHighScores[0].ScoreInt;
						IncorrectAnswersLabel1.Content = (10 - _game.TopTenHighScores[0].ScoreInt);
						TimeLabel1.Content = _game.TopTenHighScores[0].TimeInt;
						// Score 2
						NameLabel2.Content = _game.TopTenHighScores[1].NameString;
						AgeLabel2.Content = _game.TopTenHighScores[1].AgeInt;
						CorrectAnswersLabel2.Content = _game.TopTenHighScores[1].ScoreInt;
						IncorrectAnswersLabel2.Content = (10 - _game.TopTenHighScores[1].ScoreInt);
						TimeLabel2.Content = _game.TopTenHighScores[1].TimeInt;
						// Score 3
						NameLabel3.Content = _game.TopTenHighScores[2].NameString;
						AgeLabel3.Content = _game.TopTenHighScores[2].AgeInt;
						CorrectAnswersLabel3.Content = _game.TopTenHighScores[2].ScoreInt;
						IncorrectAnswersLabel3.Content = (10 - _game.TopTenHighScores[2].ScoreInt);
						TimeLabel3.Content = _game.TopTenHighScores[2].TimeInt;
						// Score 4
						NameLabel4.Content = _game.TopTenHighScores[3].NameString;
						AgeLabel4.Content = _game.TopTenHighScores[3].AgeInt;
						CorrectAnswersLabel4.Content = _game.TopTenHighScores[3].ScoreInt;
						IncorrectAnswersLabel4.Content = (10 - _game.TopTenHighScores[3].ScoreInt);
						TimeLabel4.Content = _game.TopTenHighScores[3].TimeInt;
						// Score 5
						NameLabel5.Content = _game.TopTenHighScores[4].NameString;
						AgeLabel5.Content = _game.TopTenHighScores[4].AgeInt;
						CorrectAnswersLabel5.Content = _game.TopTenHighScores[4].ScoreInt;
						IncorrectAnswersLabel5.Content = (10 - _game.TopTenHighScores[4].ScoreInt);
						TimeLabel5.Content = _game.TopTenHighScores[4].TimeInt;
						break;
					case 6:
						// Score 1
						NameLabel1.Content = _game.TopTenHighScores[0].NameString;
						AgeLabel1.Content = _game.TopTenHighScores[0].AgeInt;
						CorrectAnswersLabel1.Content = _game.TopTenHighScores[0].ScoreInt;
						IncorrectAnswersLabel1.Content = (10 - _game.TopTenHighScores[0].ScoreInt);
						TimeLabel1.Content = _game.TopTenHighScores[0].TimeInt;
						// Score 2
						NameLabel2.Content = _game.TopTenHighScores[1].NameString;
						AgeLabel2.Content = _game.TopTenHighScores[1].AgeInt;
						CorrectAnswersLabel2.Content = _game.TopTenHighScores[1].ScoreInt;
						IncorrectAnswersLabel2.Content = (10 - _game.TopTenHighScores[1].ScoreInt);
						TimeLabel2.Content = _game.TopTenHighScores[1].TimeInt;
						// Score 3
						NameLabel3.Content = _game.TopTenHighScores[2].NameString;
						AgeLabel3.Content = _game.TopTenHighScores[2].AgeInt;
						CorrectAnswersLabel3.Content = _game.TopTenHighScores[2].ScoreInt;
						IncorrectAnswersLabel3.Content = (10 - _game.TopTenHighScores[2].ScoreInt);
						TimeLabel3.Content = _game.TopTenHighScores[2].TimeInt;
						// Score 4
						NameLabel4.Content = _game.TopTenHighScores[3].NameString;
						AgeLabel4.Content = _game.TopTenHighScores[3].AgeInt;
						CorrectAnswersLabel4.Content = _game.TopTenHighScores[3].ScoreInt;
						IncorrectAnswersLabel4.Content = (10 - _game.TopTenHighScores[3].ScoreInt);
						TimeLabel4.Content = _game.TopTenHighScores[3].TimeInt;
						// Score 5
						NameLabel5.Content = _game.TopTenHighScores[4].NameString;
						AgeLabel5.Content = _game.TopTenHighScores[4].AgeInt;
						CorrectAnswersLabel5.Content = _game.TopTenHighScores[4].ScoreInt;
						IncorrectAnswersLabel5.Content = (10 - _game.TopTenHighScores[4].ScoreInt);
						TimeLabel5.Content = _game.TopTenHighScores[4].TimeInt;
						// Score 6
						NameLabel6.Content = _game.TopTenHighScores[5].NameString;
						AgeLabel6.Content = _game.TopTenHighScores[5].AgeInt;
						CorrectAnswersLabel6.Content = _game.TopTenHighScores[5].ScoreInt;
						IncorrectAnswersLabel6.Content = (10 - _game.TopTenHighScores[5].ScoreInt);
						TimeLabel6.Content = _game.TopTenHighScores[5].TimeInt;
						break;
					case 7:
						// Score 1
						NameLabel1.Content = _game.TopTenHighScores[0].NameString;
						AgeLabel1.Content = _game.TopTenHighScores[0].AgeInt;
						CorrectAnswersLabel1.Content = _game.TopTenHighScores[0].ScoreInt;
						IncorrectAnswersLabel1.Content = (10 - _game.TopTenHighScores[0].ScoreInt);
						TimeLabel1.Content = _game.TopTenHighScores[0].TimeInt;
						// Score 2
						NameLabel2.Content = _game.TopTenHighScores[1].NameString;
						AgeLabel2.Content = _game.TopTenHighScores[1].AgeInt;
						CorrectAnswersLabel2.Content = _game.TopTenHighScores[1].ScoreInt;
						IncorrectAnswersLabel2.Content = (10 - _game.TopTenHighScores[1].ScoreInt);
						TimeLabel2.Content = _game.TopTenHighScores[1].TimeInt;
						// Score 3
						NameLabel3.Content = _game.TopTenHighScores[2].NameString;
						AgeLabel3.Content = _game.TopTenHighScores[2].AgeInt;
						CorrectAnswersLabel3.Content = _game.TopTenHighScores[2].ScoreInt;
						IncorrectAnswersLabel3.Content = (10 - _game.TopTenHighScores[2].ScoreInt);
						TimeLabel3.Content = _game.TopTenHighScores[2].TimeInt;
						// Score 4
						NameLabel4.Content = _game.TopTenHighScores[3].NameString;
						AgeLabel4.Content = _game.TopTenHighScores[3].AgeInt;
						CorrectAnswersLabel4.Content = _game.TopTenHighScores[3].ScoreInt;
						IncorrectAnswersLabel4.Content = (10 - _game.TopTenHighScores[3].ScoreInt);
						TimeLabel4.Content = _game.TopTenHighScores[3].TimeInt;
						// Score 5
						NameLabel5.Content = _game.TopTenHighScores[4].NameString;
						AgeLabel5.Content = _game.TopTenHighScores[4].AgeInt;
						CorrectAnswersLabel5.Content = _game.TopTenHighScores[4].ScoreInt;
						IncorrectAnswersLabel5.Content = (10 - _game.TopTenHighScores[4].ScoreInt);
						TimeLabel5.Content = _game.TopTenHighScores[4].TimeInt;
						// Score 6
						NameLabel6.Content = _game.TopTenHighScores[5].NameString;
						AgeLabel6.Content = _game.TopTenHighScores[5].AgeInt;
						CorrectAnswersLabel6.Content = _game.TopTenHighScores[5].ScoreInt;
						IncorrectAnswersLabel6.Content = (10 - _game.TopTenHighScores[5].ScoreInt);
						TimeLabel6.Content = _game.TopTenHighScores[5].TimeInt;
						// Score 7
						NameLabel7.Content = _game.TopTenHighScores[6].NameString;
						AgeLabel7.Content = _game.TopTenHighScores[6].AgeInt;
						CorrectAnswersLabel7.Content = _game.TopTenHighScores[6].ScoreInt;
						IncorrectAnswersLabel7.Content = (10 - _game.TopTenHighScores[6].ScoreInt);
						TimeLabel7.Content = _game.TopTenHighScores[6].TimeInt;
						break;
					case 8:
						// Score 1
						NameLabel1.Content = _game.TopTenHighScores[0].NameString;
						AgeLabel1.Content = _game.TopTenHighScores[0].AgeInt;
						CorrectAnswersLabel1.Content = _game.TopTenHighScores[0].ScoreInt;
						IncorrectAnswersLabel1.Content = (10 - _game.TopTenHighScores[0].ScoreInt);
						TimeLabel1.Content = _game.TopTenHighScores[0].TimeInt;
						// Score 2
						NameLabel2.Content = _game.TopTenHighScores[1].NameString;
						AgeLabel2.Content = _game.TopTenHighScores[1].AgeInt;
						CorrectAnswersLabel2.Content = _game.TopTenHighScores[1].ScoreInt;
						IncorrectAnswersLabel2.Content = (10 - _game.TopTenHighScores[1].ScoreInt);
						TimeLabel2.Content = _game.TopTenHighScores[1].TimeInt;
						// Score 3
						NameLabel3.Content = _game.TopTenHighScores[2].NameString;
						AgeLabel3.Content = _game.TopTenHighScores[2].AgeInt;
						CorrectAnswersLabel3.Content = _game.TopTenHighScores[2].ScoreInt;
						IncorrectAnswersLabel3.Content = (10 - _game.TopTenHighScores[2].ScoreInt);
						TimeLabel3.Content = _game.TopTenHighScores[2].TimeInt;
						// Score 4
						NameLabel4.Content = _game.TopTenHighScores[3].NameString;
						AgeLabel4.Content = _game.TopTenHighScores[3].AgeInt;
						CorrectAnswersLabel4.Content = _game.TopTenHighScores[3].ScoreInt;
						IncorrectAnswersLabel4.Content = (10 - _game.TopTenHighScores[3].ScoreInt);
						TimeLabel4.Content = _game.TopTenHighScores[3].TimeInt;
						// Score 5
						NameLabel5.Content = _game.TopTenHighScores[4].NameString;
						AgeLabel5.Content = _game.TopTenHighScores[4].AgeInt;
						CorrectAnswersLabel5.Content = _game.TopTenHighScores[4].ScoreInt;
						IncorrectAnswersLabel5.Content = (10 - _game.TopTenHighScores[4].ScoreInt);
						TimeLabel5.Content = _game.TopTenHighScores[4].TimeInt;
						// Score 6
						NameLabel6.Content = _game.TopTenHighScores[5].NameString;
						AgeLabel6.Content = _game.TopTenHighScores[5].AgeInt;
						CorrectAnswersLabel6.Content = _game.TopTenHighScores[5].ScoreInt;
						IncorrectAnswersLabel6.Content = (10 - _game.TopTenHighScores[5].ScoreInt);
						TimeLabel6.Content = _game.TopTenHighScores[5].TimeInt;
						// Score 7
						NameLabel7.Content = _game.TopTenHighScores[6].NameString;
						AgeLabel7.Content = _game.TopTenHighScores[6].AgeInt;
						CorrectAnswersLabel7.Content = _game.TopTenHighScores[6].ScoreInt;
						IncorrectAnswersLabel7.Content = (10 - _game.TopTenHighScores[6].ScoreInt);
						TimeLabel7.Content = _game.TopTenHighScores[6].TimeInt;
						// Score 8
						NameLabel8.Content = _game.TopTenHighScores[7].NameString;
						AgeLabel8.Content = _game.TopTenHighScores[7].AgeInt;
						CorrectAnswersLabel8.Content = _game.TopTenHighScores[7].ScoreInt;
						IncorrectAnswersLabel8.Content = (10 - _game.TopTenHighScores[7].ScoreInt);
						TimeLabel8.Content = _game.TopTenHighScores[7].TimeInt;

						break;
					case 9:
						// Score 1
						NameLabel1.Content = _game.TopTenHighScores[0].NameString;
						AgeLabel1.Content = _game.TopTenHighScores[0].AgeInt;
						CorrectAnswersLabel1.Content = _game.TopTenHighScores[0].ScoreInt;
						IncorrectAnswersLabel1.Content = (10 - _game.TopTenHighScores[0].ScoreInt);
						TimeLabel1.Content = _game.TopTenHighScores[0].TimeInt;
						// Score 2
						NameLabel2.Content = _game.TopTenHighScores[1].NameString;
						AgeLabel2.Content = _game.TopTenHighScores[1].AgeInt;
						CorrectAnswersLabel2.Content = _game.TopTenHighScores[1].ScoreInt;
						IncorrectAnswersLabel2.Content = (10 - _game.TopTenHighScores[1].ScoreInt);
						TimeLabel2.Content = _game.TopTenHighScores[1].TimeInt;
						// Score 3
						NameLabel3.Content = _game.TopTenHighScores[2].NameString;
						AgeLabel3.Content = _game.TopTenHighScores[2].AgeInt;
						CorrectAnswersLabel3.Content = _game.TopTenHighScores[2].ScoreInt;
						IncorrectAnswersLabel3.Content = (10 - _game.TopTenHighScores[2].ScoreInt);
						TimeLabel3.Content = _game.TopTenHighScores[2].TimeInt;
						// Score 4
						NameLabel4.Content = _game.TopTenHighScores[3].NameString;
						AgeLabel4.Content = _game.TopTenHighScores[3].AgeInt;
						CorrectAnswersLabel4.Content = _game.TopTenHighScores[3].ScoreInt;
						IncorrectAnswersLabel4.Content = (10 - _game.TopTenHighScores[3].ScoreInt);
						TimeLabel4.Content = _game.TopTenHighScores[3].TimeInt;
						// Score 5
						NameLabel5.Content = _game.TopTenHighScores[4].NameString;
						AgeLabel5.Content = _game.TopTenHighScores[4].AgeInt;
						CorrectAnswersLabel5.Content = _game.TopTenHighScores[4].ScoreInt;
						IncorrectAnswersLabel5.Content = (10 - _game.TopTenHighScores[4].ScoreInt);
						TimeLabel5.Content = _game.TopTenHighScores[4].TimeInt;
						// Score 6
						NameLabel6.Content = _game.TopTenHighScores[5].NameString;
						AgeLabel6.Content = _game.TopTenHighScores[5].AgeInt;
						CorrectAnswersLabel6.Content = _game.TopTenHighScores[5].ScoreInt;
						IncorrectAnswersLabel6.Content = (10 - _game.TopTenHighScores[5].ScoreInt);
						TimeLabel6.Content = _game.TopTenHighScores[5].TimeInt;
						// Score 7
						NameLabel7.Content = _game.TopTenHighScores[6].NameString;
						AgeLabel7.Content = _game.TopTenHighScores[6].AgeInt;
						CorrectAnswersLabel7.Content = _game.TopTenHighScores[6].ScoreInt;
						IncorrectAnswersLabel7.Content = (10 - _game.TopTenHighScores[6].ScoreInt);
						TimeLabel7.Content = _game.TopTenHighScores[6].TimeInt;
						// Score 8
						NameLabel8.Content = _game.TopTenHighScores[7].NameString;
						AgeLabel8.Content = _game.TopTenHighScores[7].AgeInt;
						CorrectAnswersLabel8.Content = _game.TopTenHighScores[7].ScoreInt;
						IncorrectAnswersLabel8.Content = (10 - _game.TopTenHighScores[7].ScoreInt);
						TimeLabel8.Content = _game.TopTenHighScores[7].TimeInt;
						// Score 9
						NameLabel9.Content = _game.TopTenHighScores[8].NameString;
						AgeLabel9.Content = _game.TopTenHighScores[8].AgeInt;
						CorrectAnswersLabel9.Content = _game.TopTenHighScores[8].ScoreInt;
						IncorrectAnswersLabel9.Content = (10 - _game.TopTenHighScores[8].ScoreInt);
						TimeLabel9.Content = _game.TopTenHighScores[8].TimeInt;

						break;
					case 10:
						// Score 1
						NameLabel1.Content = _game.TopTenHighScores[0].NameString;
						AgeLabel1.Content = _game.TopTenHighScores[0].AgeInt;
						CorrectAnswersLabel1.Content = _game.TopTenHighScores[0].ScoreInt;
						IncorrectAnswersLabel1.Content = (10 - _game.TopTenHighScores[0].ScoreInt);
						TimeLabel1.Content = _game.TopTenHighScores[0].TimeInt;
						// Score 2
						NameLabel2.Content = _game.TopTenHighScores[1].NameString;
						AgeLabel2.Content = _game.TopTenHighScores[1].AgeInt;
						CorrectAnswersLabel2.Content = _game.TopTenHighScores[1].ScoreInt;
						IncorrectAnswersLabel2.Content = (10 - _game.TopTenHighScores[1].ScoreInt);
						TimeLabel2.Content = _game.TopTenHighScores[1].TimeInt;
						// Score 3
						NameLabel3.Content = _game.TopTenHighScores[2].NameString;
						AgeLabel3.Content = _game.TopTenHighScores[2].AgeInt;
						CorrectAnswersLabel3.Content = _game.TopTenHighScores[2].ScoreInt;
						IncorrectAnswersLabel3.Content = (10 - _game.TopTenHighScores[2].ScoreInt);
						TimeLabel3.Content = _game.TopTenHighScores[2].TimeInt;
						// Score 4
						NameLabel4.Content = _game.TopTenHighScores[3].NameString;
						AgeLabel4.Content = _game.TopTenHighScores[3].AgeInt;
						CorrectAnswersLabel4.Content = _game.TopTenHighScores[3].ScoreInt;
						IncorrectAnswersLabel4.Content = (10 - _game.TopTenHighScores[3].ScoreInt);
						TimeLabel4.Content = _game.TopTenHighScores[3].TimeInt;
						// Score 5
						NameLabel5.Content = _game.TopTenHighScores[4].NameString;
						AgeLabel5.Content = _game.TopTenHighScores[4].AgeInt;
						CorrectAnswersLabel5.Content = _game.TopTenHighScores[4].ScoreInt;
						IncorrectAnswersLabel5.Content = (10 - _game.TopTenHighScores[4].ScoreInt);
						TimeLabel5.Content = _game.TopTenHighScores[4].TimeInt;
						// Score 6
						NameLabel6.Content = _game.TopTenHighScores[5].NameString;
						AgeLabel6.Content = _game.TopTenHighScores[5].AgeInt;
						CorrectAnswersLabel6.Content = _game.TopTenHighScores[5].ScoreInt;
						IncorrectAnswersLabel6.Content = (10 - _game.TopTenHighScores[5].ScoreInt);
						TimeLabel6.Content = _game.TopTenHighScores[5].TimeInt;
						// Score 7
						NameLabel7.Content = _game.TopTenHighScores[6].NameString;
						AgeLabel7.Content = _game.TopTenHighScores[6].AgeInt;
						CorrectAnswersLabel7.Content = _game.TopTenHighScores[6].ScoreInt;
						IncorrectAnswersLabel7.Content = (10 - _game.TopTenHighScores[6].ScoreInt);
						TimeLabel7.Content = _game.TopTenHighScores[6].TimeInt;
						// Score 8
						NameLabel8.Content = _game.TopTenHighScores[7].NameString;
						AgeLabel8.Content = _game.TopTenHighScores[7].AgeInt;
						CorrectAnswersLabel8.Content = _game.TopTenHighScores[7].ScoreInt;
						IncorrectAnswersLabel8.Content = (10 - _game.TopTenHighScores[7].ScoreInt);
						TimeLabel8.Content = _game.TopTenHighScores[7].TimeInt;
						// Score 9
						NameLabel9.Content = _game.TopTenHighScores[8].NameString;
						AgeLabel9.Content = _game.TopTenHighScores[8].AgeInt;
						CorrectAnswersLabel9.Content = _game.TopTenHighScores[8].ScoreInt;
						IncorrectAnswersLabel9.Content = (10 - _game.TopTenHighScores[8].ScoreInt);
						TimeLabel9.Content = _game.TopTenHighScores[8].TimeInt;
						// Score 10
						NameLabel10.Content = _game.TopTenHighScores[9].NameString;
						AgeLabel10.Content = _game.TopTenHighScores[9].AgeInt;
						CorrectAnswersLabel10.Content = _game.TopTenHighScores[9].ScoreInt;
						IncorrectAnswersLabel10.Content = (10 - _game.TopTenHighScores[9].ScoreInt);
						TimeLabel10.Content = _game.TopTenHighScores[9].TimeInt;
						break;
					default:
						break;
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
