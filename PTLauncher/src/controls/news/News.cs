using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                    try
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
                    catch { }
                }
            }

            /**
             * <summary>Obtains the first image within the content of a new post</summary>
             * It can filter 2 kind of images, them with some kind of steam preset {STEAM_CLAN_IMAGE} and the ones with that part replaced with the actual link.
             * 
             * if no image is found it will use the default Project Torque splash image
             */
            private string FindImageSource(string contents)
            {
                const string clanImageBase = "https://steamcdn-a.akamaihd.net/steamcommunity/public/images/clans";

                string image;

                if (contents.Contains("STEAM_CLAN_IMAGE"))
                {
                    image = clanImageBase + Regex.Match(contents, "((?<=STEAM_CLAN_IMAGE})(.[/s]*){1,60}((.png)|(.jpg)))").Value;
                }
                else
                {
                    image = Regex.Match(contents, "((" + clanImageBase + ")(.[/s]*){1,90}((.png)|(.jpg)))").Value;
                }

                if (image == string.Empty)
                {
                    image = "../../../images/PTsplash.png";  // TODO: let's fix this, this make something unstable in future. So it needs to be 'dynamic'! check out resource stream: https://stackoverflow.com/a/1192076
                }

                return image;
            }
        }
    }

}
