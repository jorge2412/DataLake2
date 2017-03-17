using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.UI.Xaml;

namespace Factoid.Helpers
{
    public static class TileHelper
    {
        public static void PinFact(string fact)
        {
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();

            updater.EnableNotificationQueue(true);

            string content = @"<tile>" +
                  "<visual>" +
                    "<binding template=\"TileLarge\" branding=\"nameAndLogo\" displayName=\"Factoid\">" +
                      "<group>" +
                        "<subgroup>" +
                         "<text hint-style=\"title\">Did you know?</text>" +
                          $"<text hint-wrap=\"true\">{fact}</text>" +                         
                        "</subgroup>" +
                      "</group>" +
                    "</binding>" +
                     "<binding template=\"TileWide\" branding=\"nameAndLogo\" displayName=\"Factoid\">" +
                      "<group>" +
                        "<subgroup>" +
                         "<text hint-style=\"title\">Did you know?</text>" +
                          $"<text hint-wrap=\"true\">{fact}</text>" +
                        "</subgroup>" +
                      "</group>" +
                    "</binding>" +
                     "<binding template=\"TileMedium\" branding=\"nameAndLogo\" displayName=\"Factoid\">" +
                      "<group>" +
                        "<subgroup>" +                       
                          $"<text hint-wrap=\"true\">{fact}</text>" +
                        "</subgroup>" +
                      "</group>" +
                    "</binding>" +
                  "</visual>" +
                "</tile>";

            XmlDocument payload = new XmlDocument();

            payload.LoadXml(content);

            TileNotification tile = new TileNotification(payload);
            
            updater.Update(tile);

        }
    }
}
