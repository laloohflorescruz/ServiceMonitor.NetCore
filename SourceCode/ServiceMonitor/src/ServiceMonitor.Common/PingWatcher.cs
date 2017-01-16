﻿using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace ServiceMonitor.Common
{
    public class PingWatcher : IWatcher
    {
        public PingWatcher()
        {
        }

        public String ActionName
        {
            get
            {
                return "Ping";
            }
        }

        public async Task<WatchResponse> Watch(WatcherParameter parameter)
        {
            var ping = new Ping();

            var reply = await ping.SendPingAsync(parameter.Values["Address"]);

            return new WatchResponse
            {
                Success = reply.Status == IPStatus.Success ? true : false
            };
        }
    }
}
