using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Drawing;

namespace Waterskibaan
{
    public class Game 
    {
        public  Logger Log { get; set; }
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
            Log = new Logger(waterskiBaan._kabel);
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
            if (timed % 21 == 0)
            {
                List<Sporter> sporters = wachtrijInstructie.SportersVerlatenRij(wachtrijInstructie.GetAlleSporters().Count);
                instructieAfgelopen?.Invoke(new InstructieAfgelopenArgs(sporters));
            }
            if (timed > 30 && timed % 3 == 0)
            {
                LijnenVerplaatst?.Invoke();
            }
        }


        //functional
        private void OnNieuweBezoeker(NieuweBezoekerArgs e)
        {
            wachtrijInstructie.SporterNeemtPlaats(e.Sporter);
            Console.WriteLine($"event on nieuwe bezoeker {wachtrijInstructie.GetAantal()} ");
            Log.Logging.Add(e.Sporter);
        }

        //functional
        private void OninstructieAfgelopen(InstructieAfgelopenArgs e)
        {
            foreach (Sporter sporter in e.Sporters)
            {
                instructieGroep.SporterNeemtPlaats(sporter);
            }
            Console.WriteLine($"Event on instr. afgelopen {instructieGroep.GetAantal()}");
            System.Threading.Thread.Sleep(1000);
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
                    waterskiBaan.SporterStart(sporter);
                }
            }
            Console.WriteLine($"status\n{waterskiBaan}");
            waterskiBaan.MoveUitvoeren();
        }
    }
}
