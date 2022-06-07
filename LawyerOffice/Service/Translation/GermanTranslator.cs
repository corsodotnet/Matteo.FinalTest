using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerOffice
{
    internal class GermanTranslator : ITranslator
    {
        public string Translate(string text)
        {
            if (text == "HALLO")

            {
                text = "ciao da German translator";
            }
            return text;
        }
    }
}
