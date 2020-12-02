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
        private readonly FirebaseApp app;

        public FirebaseService()
        {
            this.app = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(@"/home/pi/OpenMyGarage/API/Service/firebasekey.json")
            });
        }

        public async Task SendMessage(string plate)
        {
            var messaging = FirebaseMessaging.GetMessaging(this.app);

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
