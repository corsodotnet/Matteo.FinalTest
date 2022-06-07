using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerOffice
{
    internal class EnglishTranslator : ITranslator
    {
        public string Translate(string text)
        {
            if (text == "HI")

            {
                text = "ciao da English translator";
            }
            return text;
        }
    }
}
