using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Waterskibaan;

namespace WaterskibaanScherm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Logger _logger; 
        public Timer timer { get; set; }
        private Game game = new Game();
        
        bool gameRunning = false;
        int currentPosition = 22;
        int count = 0;


        List<Sporter> _startWachtrij = new List<Sporter>();
        List<Sporter> _instructieWachtrij = new List<Sporter>();
        List<Sporter> _instructiegroep = new List<Sporter>();

        public int TotaalAantalBezoekers { get; set; }
        public int HoogstBehaaldeScore { get; set; }
        public int BezoekersInRodeKleding { get; set; }
        public int AantalRondjesTotaal { get; set; }
        public IList<string> UniekeMoves { get; set; } 
        public IList<Color> Kleurtjes { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            game.Intialize();

            _logger = game.Log;
        }

        private void UpdateStats()
        {
            int totaalAantalBezoeker = _logger.AantalBezoekersInTotaal();
            if (totaalAantalBezoeker != TotaalAantalBezoekers)
            {
                TotaalAantalBezoekers = totaalAantalBezoeker;
                wpfLBTotalVisitors.Text = TotaalAantalBezoekers.ToString();
            }

            int hoogstBehaaldeScore = _logger.HoogsteScoreMoves();
            if (hoogstBehaaldeScore != HoogstBehaaldeScore)
            {
                HoogstBehaaldeScore = hoogstBehaaldeScore;
                wpfLBHighestScore.Text = HoogstBehaaldeScore.ToString();
            }

            int totaalBezoekersInRodeKleding = _logger.TelrodeSporters();
            if (totaalBezoekersInRodeKleding != BezoekersInRodeKleding)
            {
                BezoekersInRodeKleding = totaalBezoekersInRodeKleding;
                wpfLBRedVistors.Text = BezoekersInRodeKleding.ToString();
            }

            int totaalAantalRondjes = _logger.TotaalAantalRondjes();
            if (totaalAantalRondjes != AantalRondjesTotaal)
            {
                AantalRondjesTotaal = totaalAantalRondjes;
                wpfLBTotalAmountRounds.Text = AantalRondjesTotaal.ToString();
            }

            var uniekeMoves = _logger.UniekeMoves();
            if (uniekeMoves != UniekeMoves && uniekeMoves.Count > count)
            {
                UniekeMoves = uniekeMoves;
                count = uniekeMoves.Count;
                wpfLBUniqueMoves.Text = _logger.Printlist(UniekeMoves);
            }

            var tienlichste = _logger.TienLichtsteKleuren();
            var nieuweKleuren = new List<Color>();
            foreach (var kleur in tienlichste)
            {
                nieuweKleuren.Add(Color.FromRgb(kleur.R, kleur.G, kleur.B)) ;
            }
            Kleurtjes = nieuweKleuren;
            DrawLightestColors(Kleurtjes);
            
        }

        public void CheckForMoves()
        {
            foreach (Lijn lijn in game.waterskiBaan._kabel.Lijnen)
            {
                if (lijn.Sporter.HuidigeMove != null)
                {
                    wpfLBLastMove.Text = lijn.Sporter.HuidigeMove.Naam();
                    lijn.Sporter.HuidigeMove = null;
                }
            }
        }

        public void DrawLightestColors(IList<Color> colors)
        {
            int position = 0;
            foreach (var item in colors)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Fill = new SolidColorBrush(item);
                rectangle.Width = 15;
                rectangle.Height = 20;
                Canvas.SetTop(rectangle, 0);
                Canvas.SetLeft(rectangle, position);
                wpfCVSortedOnColor.Children.Add(rectangle);
                position += 20;
            }

        }

        private void UpdateScreen()
        {
            _instructieWachtrij = game.wachtrijInstructie.GetAlleSporters();
            DrawSporters(_instructieWachtrij, wpfCVWachtrijInstructie);
            _instructiegroep = game.instructieGroep.GetAlleSporters();
            DrawSporters(_instructiegroep, wpfCVInstructiegroep);
            wpfLBAvailableLines.Text = game.waterskiBaan._lijnenVoorraad.GetAantalLijnen().ToString();
            _startWachtrij = game.wachtrijStarten.GetAlleSporters();
            DrawSporters(_startWachtrij, wpfCVWachtrijStarten);
            UpdateKabel();
            if (game.waterskiBaan._kabel.Lijnen.Count >0)
            {
                UpdateStats();
                CheckForMoves();
            }
            
        }

        public void UpdateKabel()
        {
            foreach (var lijn in game.waterskiBaan._kabel.Lijnen)
            {
                if (lijn.Sporter != null)
                {
                    SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(lijn.Sporter.KledingKleur.Item1, lijn.Sporter.KledingKleur.Item2, lijn.Sporter.KledingKleur.Item3));
                    if (lijn.PositieOpDeLijn == 0)
                    {
                        wpfRT0.Background = brush;
                        wpfRT0.Visibility = Visibility.Visible;
                    }
                    if (lijn.PositieOpDeLijn == 1)
                    {
                        wpfRT1.Background = brush;
                        wpfRT1.Visibility = Visibility.Visible;
                    }
                    if (lijn.PositieOpDeLijn == 2)
                    {
                        wpfRT2.Background = brush;
                        wpfRT2.Visibility = Visibility.Visible;
                    }
                    if (lijn.PositieOpDeLijn == 3)
                    {
                        wpfRT3.Background = brush;
                        wpfRT3.Visibility = Visibility.Visible;
                    }
                    if (lijn.PositieOpDeLijn == 4)
                    {
                        wpfRT4.Background = brush;
                        wpfRT4.Visibility = Visibility.Visible;
                    }
                    if (lijn.PositieOpDeLijn == 5)
                    {
                        wpfRT5.Background = brush;
                        wpfRT5.Visibility = Visibility.Visible;
                    }
                    if (lijn.PositieOpDeLijn == 6)
                    {
                        wpfRT6.Background = brush;
                        wpfRT6.Visibility = Visibility.Visible;
                    }
                    if (lijn.PositieOpDeLijn == 7)
                    {
                        wpfRT7.Background = brush;
                        wpfRT7.Visibility = Visibility.Visible;
                    }
                    if (lijn.PositieOpDeLijn == 8)
                    {
                        wpfRT8.Background = brush;
                        wpfRT8.Visibility = Visibility.Visible;
                    }
                    if (lijn.PositieOpDeLijn == 9)
                    {
                        wpfRT9.Background = brush;
                        wpfRT9.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        public void DrawSporters(List<Sporter> sporters, Canvas canvas)
        {
            canvas.Children.Clear();
            currentPosition = 22;
            foreach (Sporter sporter in sporters)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Fill = new SolidColorBrush(Color.FromRgb(sporter.KledingKleur.Item1, sporter.KledingKleur.Item2, sporter.KledingKleur.Item3));
                rectangle.Width = 20;
                rectangle.Height = 20;
                Canvas.SetTop(rectangle, 22);
                Canvas.SetLeft(rectangle, currentPosition);
                canvas.Children.Add(rectangle);
                currentPosition += 30;
            }
        }

        private void wpfBTStart_Click(object sender, RoutedEventArgs e)
        {
            if (!gameRunning)
            {
                timer = new Timer(100);
                timer.AutoReset = true;
                timer.Elapsed += Timer_Elapsed;
                game.StartTimer(100);
                timer.Start();
                gameRunning = true;

            }
            else
            {
                game.StopTimer();
                gameRunning = false;
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(UpdateScreen);
        }
    }
}
