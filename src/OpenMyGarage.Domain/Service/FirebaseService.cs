using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenMyGarage.Domain.Service
{
    public class FirebaseService : IFirebaseService
    {
        public async Task SendMessage(string plate)
        {
            var app = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(@"/home/pi/OpenMyGaragare/Api/Service/firebasekey.json")
            });

            var messaging = FirebaseMessaging.GetMessaging(app);

            var message = new Message()
            {
                Notification = new Notification
                {
                    Title = "Someone's at the gate",
                    Body = plate
                },
                Topic = "news"
            };

            await messaging.SendAsync(message);
        }
    }
}
