using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace webtx.realtime
{
    [HubName("chat")]
    public class signalr : Hub
    {
        public void chats(string noidung , string nguoigui )
        {
            Clients.All.chat(nguoigui, noidung);
        }
    }
}