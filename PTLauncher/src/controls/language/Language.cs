using System.Collections.Generic;
using System.Linq;

namespace PTLauncher.Language
{
    public class GameLanguage
    {
        public string Parameter { get; set; }
        public string Name { get; set; }
        public string LocalizedName { get; set; }

        public static IList<GameLanguage> Languages = new List<GameLanguage>() {
            new GameLanguage() { Name = "German",       Parameter = "de", LocalizedName = "Deutsch"},
            new GameLanguage() { Name = "English",      Parameter = "en", LocalizedName = "English"},
            new GameLanguage() { Name = "Estonian",     Parameter = "et", LocalizedName = "Eesti"},
            new GameLanguage() { Name = "Spanish",      Parameter = "es", LocalizedName = "Español"},
            new GameLanguage() { Name = "French",       Parameter = "et", LocalizedName = "Français"},
            new GameLanguage() { Name = "Italian",      Parameter = "it", LocalizedName = "Italiano"},
            new GameLanguage() { Name = "Hungarian",    Parameter = "hu", LocalizedName = "Magyar"},
            new GameLanguage() { Name = "Dutch",        Parameter = "nl", LocalizedName = "Nederlands"},
            new GameLanguage() { Name = "Polish",       Parameter = "pl", LocalizedName = "Polskie"},
            new GameLanguage() { Name = "Portuguese",   Parameter = "pt", LocalizedName = "Português"},
            new GameLanguage() { Name = "Russian",      Parameter = "ru", LocalizedName = "Русский"},
            new GameLanguage() { Name = "Turkish",      Parameter = "tr", LocalizedName = "Türk"},
        };
    }

    public static class LanguagePersistance
    {
        public static GameLanguage GetDefaultLanguag()
        {
            return GameLanguage.Languages.Where(language => language.Parameter == "en").FirstOrDefault();
        }



    }
}
