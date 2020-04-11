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

        public List<string> GetLanguageNames (List<string> isoCodes) {
            var languageNames = new List<string> ();
            var cultures = CultureInfo.GetCultures (CultureTypes.AllCultures);

            foreach (var isoCode in isoCodes) {
                var languageName = cultures.Where (x => x.ThreeLetterISOLanguageName.Equals (isoCode))
                    .Select (x => x.EnglishName)
                    .FirstOrDefault ();

                languageNames.Add (languageName);
            }

            return languageNames;

        }
    }
}