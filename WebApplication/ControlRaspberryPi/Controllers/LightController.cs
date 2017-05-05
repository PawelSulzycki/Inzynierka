using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using ControlRaspberryPi.Helper;
using ControlRaspberryPi.Server;

namespace ControlRaspberryPi.Controllers
{
    public class LightController : Controller
    {
        // GET: Light
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LightOn(int index)
        {
            var serverHelper = ServerHelper.GetInstance();
            var serverWcf = serverHelper.GetServer();
            if (CurrentState(index) == 0)
            {
                serverWcf.Light("ON", index);
            }

            return RedirectToAction("Index", "Light");
        }
        public ActionResult LightOff(int index)
        {
            var serverHelper = ServerHelper.GetInstance();
            var serverWcf = serverHelper.GetServer();
            if (CurrentState(index) == 1)
            {
                serverWcf.Light("OFF", index);
            }    

            return RedirectToAction("Index", "Light");
        }

        public int CurrentState(int index)
        {
            var serverHelper = ServerHelper.GetInstance();
            var serverWcf = serverHelper.GetServer();
            return serverWcf.State(index);
        }
    }
}