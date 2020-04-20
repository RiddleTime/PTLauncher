﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SteamKit2;

namespace PTLauncher.News
{
    public class GameNews
    {
        private DateTime dateTime { get; set; }
        public string DateTime { get { return dateTime.ToString("D"); } } // * D :Thursday, August 17, 2000
        public string Title { get; set; }
        public string ImageSource { get; set; }
        public bool HasImage { get { return ImageSource != string.Empty; } }
        public string Url { get; set; }

        public class Obtainer
        {
            public IList<GameNews> GameNews { get; private set; }

            public Obtainer()
            {
                GameNews = new List<GameNews>();
                ObtainNews();
            }

            private void ObtainNews()
            {
                using (dynamic steamNews = WebAPI.GetInterface("ISteamNews"))
                {
                    KeyValue kvNews = steamNews.GetNewsForApp(appid: 1112400, maxlength: 2000);

                    foreach (KeyValue news in kvNews["newsitems"]["newsitem"].Children)
                    {
                        GameNews.Add(new GameNews
                        {
                            dateTime = DateUtils.DateTimeFromUnixTime(news["date"].AsUnsignedLong()),
                            Title = news["title"].AsString(),
                            ImageSource = FindImageSource(news["contents"].AsString()),
                            Url = news["url"].AsString(),
                        });
                    }
                }
            }

            private string FindImageSource(string contents)
            {
                const string clanImageBase = "https://steamcdn-a.akamaihd.net/steamcommunity/public/images/clans";

                if (contents.Contains("STEAM_CLAN_IMAGE"))
                {
                    string image = Regex.Match(contents, "((?<=STEAM_CLAN_IMAGE})(.[/s]*){1,60}((.png)|(.jpg)))").Value;
                    return clanImageBase + image;
                }

                return string.Empty;
            }
        }
    }

}
