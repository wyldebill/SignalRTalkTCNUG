using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Longpollingmvc.Controllers
{
    public class ChatController : Controller
    {

        // add the member variable for the taskcompletionsource
        static TaskCompletionSource<string> _nextMessage
           = new TaskCompletionSource<string>();





        //
        // GET: /Chat/

        public ActionResult Index()
        {
            return View();
        }

        // add the action method that starts the poll, using async and await
        [HttpGet]
        public async Task<string> LongPoll()
        {
            string theMessage = await _nextMessage.Task;

            return theMessage;
        }


        // add the action method that responds to the message sent from clients.
        [HttpPost]
        public void PostMessage(string message)
        {
            _nextMessage.SetResult(message);
            _nextMessage = new TaskCompletionSource<string>();

        }


   
    }



}
