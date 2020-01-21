using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WaterskibaanScherm;

namespace Waterskibaan
{
    public enum State { IG, WI, WS, Clear }
    public class Game : ISubject
    {
        public IObserver Observer { get; set; }
        public State CurrentState { get; set; }
        public Timer timer { get; set; }
        public Waterskibaan waterskiBaan = new Waterskibaan();

        public InstructieGroep instructieGroep = new InstructieGroep();
        public WachtrijInstructie wachtrijInstructie = new WachtrijInstructie();
        public WachtrijStarten wachtrijStarten = new WachtrijStarten();

        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public event NieuweBezoekerHandler NieuweBezoeker;

        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);
        public event InstructieAfgelopenHandler instructieAfgelopen;

        public delegate void LijnenVerplaatstHandler();
        public event LijnenVerplaatstHandler LijnenVerplaatst;

        public int timed;

        public void Intialize()
        {
            //bezoeker event toevoegen
            NieuweBezoeker += OnNieuweBezoeker;
            instructieAfgelopen += OninstructieAfgelopen;
            LijnenVerplaatst += OnLijnenVerplaatst;
        }

        public void StartTimer(int interval)
        {
            timer = new Timer(interval);
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            Console.ReadLine();
        }

        public void StopTimer()
        {
            timer.Stop();
            timer.Dispose();
        }




        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timed++;
            if (timed % 3 == 0)
            {
                Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves());
                NieuweBezoeker?.Invoke(new NieuweBezoekerArgs(sporter));
            }
            if (timed % 20 == 0)
            {
                List<Sporter> sporters = wachtrijInstructie.SportersVerlatenRij(wachtrijInstructie.GetAlleSporters().Count);
                instructieAfgelopen?.Invoke(new InstructieAfgelopenArgs(sporters));
            }
            if (timed > 31 && timed % 4 == 0)
            {
                LijnenVerplaatst?.Invoke();
            }
        }


        //functional
        private void OnNieuweBezoeker(NieuweBezoekerArgs e)
        {
            wachtrijInstructie.SporterNeemtPlaats(e.Sporter);
            Console.WriteLine($"event on nieuwe bezoeker {wachtrijInstructie.GetAantal()} ");
            CurrentState = State.WI;
            Notify();
        }

        //functional
        private void OninstructieAfgelopen(InstructieAfgelopenArgs e)
        {
            foreach (Sporter sporter in e.Sporters)
            {
                instructieGroep.SporterNeemtPlaats(sporter);
            }
            Console.WriteLine($"Event on instr. afgelopen {instructieGroep.GetAantal()}");
            System.Threading.Thread.Sleep(10000);
            List<Sporter> sporters = instructieGroep.SportersVerlatenRij(instructieGroep.GetAlleSporters().Count);
            foreach (Sporter sporter in sporters)
            {
                wachtrijStarten.SporterNeemtPlaats(sporter);
            }
            Console.WriteLine($" in  de instructie groep{instructieGroep.GetAantal()} aantal in de wachtrij starten {wachtrijStarten.GetAantal()}");

        }

        private void OnLijnenVerplaatst()
        {
            waterskiBaan.VerplaatsKabel();
            if (waterskiBaan._kabel.IsStartPositieLeeg())
            {
                List<Sporter> sporters = wachtrijStarten.SportersVerlatenRij(1);
                if (sporters.Count > 0)
                {

                    var sporter = sporters[0];
                    sporter.Zwemvest = new Zwemvest();
                    sporter.Skies = new Skies();

                    Console.WriteLine("reached it");
                    waterskiBaan.SporterStart(sporter);
                }
            }
            Console.WriteLine($"status{waterskiBaan}");

        }

        public void Attach(IObserver observer)
        {
            Observer = observer;
        }

        public void Notify()
        {
            if (Observer != null)
            {
                Observer.UpdateLists();
            }
        }
    }
}
