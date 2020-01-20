using System.Collections.Generic;

namespace Waterskibaan
{
    public class InstructieAfgelopenArgs
    {
        public List<Sporter> Sporters { get; }
        public InstructieAfgelopenArgs(List<Sporter> sporters)
        {
            Sporters = sporters;
        }
    }
}