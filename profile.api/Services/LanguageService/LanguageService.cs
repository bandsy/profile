using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace profile.api.Services.LanguageService {
    public class LanguageService : ILanguageService {
        public List<string> GetIsoCodes (List<string> languages) {
            var isoCodes = new List<string> ();
            var cultures = CultureInfo.GetCultures (CultureTypes.AllCultures);

            foreach (var language in languages) {
                var code = cultures.Where (x => x.EnglishName.Equals (language))
                    .Select (x => x.ThreeLetterISOLanguageName);

                isoCodes.AddRange (code);
            }

          return isoCodes;
        }
    }
}