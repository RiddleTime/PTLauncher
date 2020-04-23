using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PTLauncher.Language
{
    public class GameLanguage
    {
        public string Name { get; set; }
        public string Parameter { get; set; }

        public static IList<GameLanguage> Languages = new List<GameLanguage>() {
            new GameLanguage() { Name = "Dutch",        Parameter = "nl"},
            new GameLanguage() { Name = "English",      Parameter = "en"},
            new GameLanguage() { Name = "Estonian",     Parameter = "et"},
            new GameLanguage() { Name = "German",       Parameter = "de"},
            new GameLanguage() { Name = "Hungarian",    Parameter = "hu"},
            new GameLanguage() { Name = "Italian",      Parameter = "it"},
            new GameLanguage() { Name = "Polish",       Parameter = "pl"},
            new GameLanguage() { Name = "Portuguese",   Parameter = "pt"},
            new GameLanguage() { Name = "Spanish",      Parameter = "es"},
            new GameLanguage() { Name = "Turkish",      Parameter = "tr"},
        };
    }

    public class LanguagePersistance
    {

    }
}
