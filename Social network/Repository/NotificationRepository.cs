using Social_network.Models;
using Social_network.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Repository
{
    interface NotificationRepository
    {
		Task<List<NotificationResponse>> getAllNotificattion(PageInfo pageInfo);
	}
}
