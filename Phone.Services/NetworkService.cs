//NetworkService.cs

using Phone.Enums;
using System;

namespace Phone.Services
{

    public delegate void NetworkEventHandler();

    public enum NetworkState {
        Offline,
        [Description("Connected to the network")]
        Online
    }

    public class NetworkService
    {
        public event NetworkEventHandler OnlineEvent;
        public event NetworkEventHandler OfflineEvent;

        public NetworkState State { get; private set; }

        public NetworkService()
        {
            State = NetworkState.Offline;
        }

        public void TurnOnWiFi()
        {
            if (State != NetworkState.Online)
            {
                State = NetworkState.Online;
                OnlineEvent?.Invoke();
            }
        }
        public void TurnOffWiFi()
        {
            if (State != NetworkState.Offline)
            {
                State = NetworkState.Offline;
                OfflineEvent?.Invoke();
            }
        }

        public void Start()
        {
            State = NetworkState.Online;
        }

        public void Upload(string content)
        {
            if(State == NetworkState.Online)
                Console.WriteLine($"Uploading {content}");
        }

        public string Download(string url)
        {
            if (State == NetworkState.Online)
                return $"Downloaded content from {url} at {DateTime.Now.ToLongTimeString()}";
            else
                return null;
        }
    }
}
