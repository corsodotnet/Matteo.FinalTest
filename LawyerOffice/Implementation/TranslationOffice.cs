using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerOffice
{
    internal class TranslationOffice
    {
        TranslationOnlineStore _onlineStore = new TranslationOnlineStore();
        public string Translate(LANGUAGE lang, string text)
        {
            return _onlineStore.Translate(lang, text);
        }
    }
}
