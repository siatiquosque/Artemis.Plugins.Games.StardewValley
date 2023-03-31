using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Timers;
using SystemTimer = System.Timers.Timer;

namespace Artemis.Plugins.Games.StardewValley.GSI
{
    public class ArtemisWebClient
    {
        private const string CONFIG_PATH = @"C:\ProgramData\Artemis\webserver.txt";
        private const string PLUGIN_GUID = "298a471b-4188-433b-8e8b-b7238192921f";

        //private readonly ManualLogSource _logger;
        private static SystemTimer timer;
        private static string _baseUri;

        public static void load(StardewModdingAPI.IMonitor monitor) {
            //_logger = Logger;

            if (!File.Exists(CONFIG_PATH))
                throw new FileNotFoundException("Artemis: Webserver file not found");

            string uri;
            try
            {
                uri = File.ReadAllText(CONFIG_PATH);
            }
            catch (IOException)
            {
                monitor.Log("Artemis: Error reading webserver config file", StardewModdingAPI.LogLevel.Error);
                throw;
            }

            monitor.Log($"Found artemis web api uri: {uri}", StardewModdingAPI.LogLevel.Debug);
            _baseUri = $"{uri}plugins/{PLUGIN_GUID}";


            var _client = (HttpWebRequest)WebRequest.Create(_baseUri);

            //var request = new  RestRequest("plugins");
            try
            {
               var stream = _client.GetResponse().GetResponseStream();
                monitor.Log(stream.ToString(), StardewModdingAPI.LogLevel.Debug);

            }
            catch (Exception e)
            {
                monitor.Log("Artemis: Failed connecting to webserver", StardewModdingAPI.LogLevel.Error);
                //_logger.LogError(e);

                throw new Exception("Failed to connect to Artemis, exiting...");
            }


            monitor.Log("Connected to Artemis, starting timer.", StardewModdingAPI.LogLevel.Error);

            timer = new SystemTimer(100);
            //timer.Elapsed += OnTimerElapsed;
        }


        public static void SendJson(string json, StardewModdingAPI.IMonitor monitor)
        {
            try
            {
                //monitor.Log($"{_baseUri}/update", StardewModdingAPI.LogLevel.Debug);
                var request = (HttpWebRequest)WebRequest.Create($"{_baseUri}/update");
                request.ContentType = "application/json";
                request.Method = WebRequestMethods.Http.Post;
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                monitor.Log("Error to Send Json on Update Request", StardewModdingAPI.LogLevel.Error);
                //_logger.LogError(e);
            }
        }
    }
}
