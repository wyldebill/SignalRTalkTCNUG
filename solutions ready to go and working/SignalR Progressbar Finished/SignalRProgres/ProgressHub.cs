
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace SignalRProgress
{
    //[HubName("")]
    public class ProgressHub : Hub
    {
        private static string MasterId { get; set; }


        public override Task OnConnected()
        {
            var connectionIdCurrentUser = Context.ConnectionId;

            if (connectionIdCurrentUser != MasterId && MasterId != null)
                Clients.Caller.youAreNotTheMaster();
            return base.OnConnected();
        }


        public void Auto()
        {
            SetValue(15, 1000);
            SetValue(65, 7000);
            SetValue(85, 8000);
            SetValue(100, 1000);

            //comment


        }

        public void IAmTheMaster(string key)
        {
            if (key == "4679a")
            {
                MasterId = Context.ConnectionId;
                Clients.Others.youAreNotTheMaster();
            }
          
        }

        public void SetValue(int value, int time)
        {
            Clients.All.SetValue(value, time);
        }


        public void SendMessage(string message)
        {
            Clients.All.RecMessage("hello" + message);
        }

        public void Set50()
        {
            Clients.All.SetClient50();
        }

        public void Set100()
        {
            Clients.All.SetClient100();
        }

        public void Set0()
        {
            Clients.All.SetClient0();
        }
    }
}