using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BilliardClub.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace BilliardClub.Hubs
{
    public class ReservationHub : Hub
    {
        [HubMethodName("NotifyClients")]
        public static void ShowReservation()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ReservationHub>();
            context.Clients.All.updatedClients();
            //Clients.All.addNewReservationToPage(reservation);
            //Clients.All.showReservation(reservation);
        }
    }
}