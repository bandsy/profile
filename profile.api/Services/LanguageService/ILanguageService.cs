using System.Collections.Generic;
namespace profile.api.Services.LanguageService
{
    public interface ILanguageService
    {
         List<string> GetIsoCodes(List<string> languages);
    }
}