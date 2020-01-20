namespace Waterskibaan
{
    public class NieuweBezoekerArgs
    {
        public Sporter Sporter { get; set; }
        public NieuweBezoekerArgs(Sporter sporter)
        {
            Sporter = sporter;
        }
    }
}