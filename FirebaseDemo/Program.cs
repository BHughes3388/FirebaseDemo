using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore.V1;
using Google.Apis.Auth.OAuth2;
using Grpc.Auth;
using Grpc.Core;
using Google.Cloud.Firestore;
using Firebase.Auth;

namespace FirebaseDemo
{

    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        { 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            Console.WriteLine("Inside main");
            Authenticate();
            Application.Run(new Form1());
        }
        /*
          Following along from 
          https://googleapis.dev/dotnet/Google.Cloud.Firestore/latest/index.html#googlecloudfirestore
          https://googleapis.github.io/google-cloud-dotnet/docs/Google.Cloud.Firestore/datamodel.html
          https://googleapis.github.io/google-cloud-dotnet/docs/Google.Cloud.Firestore/userguide.html
             
             */
        private static async Task Authenticate()
        {

            //var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyBKpPKz-i778h50HSLn3F8frz7zjINy-7g"));
            //var auth = await authProvider.SignInWithEmailAndPasswordAsync("brad@hyeprecision.com","password");

            //Properties.Settings.Default.AuthToken = auth.FirebaseToken;
            //Properties.Settings.Default.Save();
            //var firebaseAuthLink = await authProvider.RefreshAuthAsync(auth); how to refresh auth token
            var project = "firestoredemo-262aa";
            var credential = GoogleCredential.FromAccessToken(Properties.Settings.Default.AuthToken);


            Channel channel = new Channel(
            FirestoreClient.DefaultEndpoint.Host, FirestoreClient.DefaultEndpoint.Port,
            credential.ToChannelCredentials());
            FirestoreClient client = FirestoreClient.Create(channel);

            FirestoreDb db = FirestoreDb.Create(project, client);


            CreateUser(db);
        }

        private static async Task CreateUser(FirestoreDb db)
        {
            // Create a document with a random ID in the "users" collection.
            CollectionReference collection = db.Collection("users");
            DocumentReference document = await collection.AddAsync(new { Name = new { First = "Brad", Last = "Hughes" }, UID = "LR3ODZZmGxgsrYc8WwovsIvD2N93" });

            DocumentSnapshot snapshot = await document.GetSnapshotAsync();
            Dictionary<string, object> data = snapshot.ToDictionary();
            Dictionary<string, object> name = (Dictionary<string, object>)data["Name"];
            Console.WriteLine(name["First"]);
            Console.WriteLine(name["Last"]);
            Console.WriteLine(snapshot.Id);
        }


    }
}
