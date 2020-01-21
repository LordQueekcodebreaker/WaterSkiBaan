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
    public partial class MainWindow : Window, IObserver
    {
        private Game game = new Game();
        bool gameRunning = false;
        int currentPosition = 22;

        List<Sporter> _startWachtrij = new List<Sporter>();
        List<Sporter> _instructieWachtrij = new List<Sporter>();
        List<Sporter> _instructiegroep = new List<Sporter>();

        public MainWindow()
        {
            InitializeComponent();
            game.Intialize();
        }

        public void StartUpdating()
        {
            Timer timer = new Timer(1000);
            timer.AutoReset = true;
            timer.Elapsed += UpdateScreen;
            timer.Start();
           
        }

        private void UpdateScreen(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(UpdateLists);
        }

        public void UpdateLists()
        {
            wpfLBLineAmount.Content = game.waterskiBaan._lijnenVoorraad.GetAantalLijnen();

            _instructieWachtrij = game.wachtrijInstructie.GetAlleSporters();
            DrawSporters(_instructieWachtrij, wpfCVWachtrijInstructie);

            _instructiegroep = game.instructieGroep.GetAlleSporters();
            DrawSporters(_instructiegroep, wpfCVInstructiegroep);

            _startWachtrij = game.wachtrijStarten.GetAlleSporters();
            DrawSporters(_startWachtrij, wpfCVWachtrijStarten);

            if (game.waterskiBaan._kabel.Lijnen.Count > 0)
            {
                UpdateKabel();
            }

            game.CurrentState = State.Clear;
        }

        //TODO: Improve if possible
        public void UpdateKabel()
        {
            foreach (Lijn lijn in game.waterskiBaan._kabel.Lijnen)
            {
                if (lijn.Sporter!= null)
                {
                    SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(lijn.Sporter.KledingKleur.Item1, lijn.Sporter.KledingKleur.Item2, lijn.Sporter.KledingKleur.Item3));
                    switch (lijn.PositieOpDeLijn)
                    {
                        case 0:
                            wpfRT0.Background = brush;
                            wpfRT0.Visibility = Visibility.Visible;
                            break;
                        case 1:
                            wpfRT1.Background = brush;
                            wpfRT1.Visibility = Visibility.Visible;
                            break;
                        case 2:
                            wpfRT2.Background = brush;
                            wpfRT2.Visibility = Visibility.Visible;
                            break;
                        case 3:
                            wpfRT3.Background = brush;
                            wpfRT3.Visibility = Visibility.Visible;
                            break;
                        case 4:
                            wpfRT4.Background = brush;
                            wpfRT4.Visibility = Visibility.Visible;
                            break;
                        case 5:
                            wpfRT5.Background = brush;
                            wpfRT5.Visibility = Visibility.Visible;
                            break;
                        case 6:
                            wpfRT6.Background = brush;
                            wpfRT6.Visibility = Visibility.Visible;
                            break;
                        case 7:
                            wpfRT7.Background = brush;
                            wpfRT7.Visibility = Visibility.Visible;
                            break;
                        case 8:
                            wpfRT8.Background = brush;
                            wpfRT8.Visibility = Visibility.Visible;
                            break;
                        case 9:
                            wpfRT9.Background = brush;
                            wpfRT9.Visibility = Visibility.Visible;
                            break;
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
                game.StartTimer(1000);
                gameRunning = true;
                StartUpdating();
            }
            else
            {
                game.StopTimer();
                gameRunning = false;
            }
        }
    }
}
