using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.VoiceCommands;

namespace Factoid.Services.Background.Helpers
{
    internal static class ProgressHelper
    {
        internal static async void LaunchAppInForegroundAsync(VoiceCommandServiceConnection voiceServiceConnection, string parameters)
        {
            var userMessage = new VoiceCommandUserMessage();

            userMessage.DisplayMessage = "Launching Factoid...";

            var response = VoiceCommandResponse.CreateResponse(userMessage);

            response.AppLaunchArgument = "type=fact&" + parameters;

            await voiceServiceConnection.RequestAppLaunchAsync(response);
        }


        internal static async Task ReportFailureAsync(VoiceCommandServiceConnection voiceServiceConnection, string message)
        {
            var userMessage = new VoiceCommandUserMessage();

            string noSuchTripToDestination = message;
            userMessage.DisplayMessage = userMessage.SpokenMessage = noSuchTripToDestination;

            var response = VoiceCommandResponse.CreateResponse(userMessage);
            await voiceServiceConnection.ReportFailureAsync(response);

            return;
        }

        internal static async Task ShowProgressScreenAsync(VoiceCommandServiceConnection voiceServiceConnection, string message)
        {
            var userProgressMessage = new VoiceCommandUserMessage();
            userProgressMessage.DisplayMessage = userProgressMessage.SpokenMessage = message;
            
            VoiceCommandResponse response = VoiceCommandResponse.CreateResponse(userProgressMessage);
            await voiceServiceConnection.ReportProgressAsync(response);

            return;
        }
    }
}
