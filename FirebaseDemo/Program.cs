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

          build firebase authentication class view
          https://forums.xamarin.com/discussion/168134/firebase-authentication-net-token-expired
             
        */

        private static async Task Authenticate()
        {
            
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyBKpPKz-i778h50HSLn3F8frz7zjINy-7g"));
            var auth = await authProvider.SignInWithEmailAndPasswordAsync("brad@hyeprecision.com","password");

            //Properties.Settings.Default.AuthToken = auth.FirebaseToken;
            var firebaseAuthLink = await authProvider.RefreshAuthAsync(auth);
            Properties.Settings.Default.AuthToken = firebaseAuthLink.FirebaseToken;
            Properties.Settings.Default.Save();
            var project = "firestoredemo-262aa";
            var credential = GoogleCredential.FromAccessToken(Properties.Settings.Default.AuthToken);


            Channel channel = new Channel(
            FirestoreClient.DefaultEndpoint.Host, FirestoreClient.DefaultEndpoint.Port,
            credential.ToChannelCredentials());
            FirestoreClient client = FirestoreClient.Create(channel);

            FirestoreDb db = FirestoreDb.Create(project, client);

            //CreateUser(db);

            Tool tool = new Tool
            {
                Name = "2.0MM BM LONG FINISH",
                Number = "4"
            };

            ExecutionData executionData = new ExecutionData
            {
                SelectedProgram = "Selected.program.running",
                ActiveProgram = "Active.program.running"
            };

            Machine machine = new Machine
            {
                Name = "Mikron HSM 200U LP",
                Ip = "192.168.1.150",
                MachineName = "Mikron 1",
                Tool = tool,
                ExecutationData = executionData
            };

            SaveMachine(db, machine);
        }

        private static async Task SaveMachine(FirestoreDb db, Machine machine)
        {
            CollectionReference collection = db.Collection("Machines");

            DocumentReference document = await collection.AddAsync(machine);

            // Fetch the data back from the server and deserialize it.
            DocumentSnapshot snapshot = await document.GetSnapshotAsync();
            Machine machineSnapshot = snapshot.ConvertTo<Machine>();
            Console.WriteLine(machineSnapshot.MachineName); // Mikron 1
            Console.WriteLine("reference id: " + snapshot.Id);
            Console.WriteLine("create time: " + machineSnapshot.CreateTime);

            machineSnapshot.Tool.Name = "5MM BM BLAH BLAH";
            await UpdateMachine(machineSnapshot);

        }

        private static async Task UpdateMachine(Machine machine)
        {
            DocumentReference document = machine.Reference;

            await document.SetAsync(machine, SetOptions.MergeAll);

            // Fetch the data back from the server and deserialize it.
            DocumentSnapshot snapshot = await document.GetSnapshotAsync();
            Machine machineSnapshot = snapshot.ConvertTo<Machine>();
            Console.WriteLine(machineSnapshot.Tool.Name); // 5MM BM BLAH BLAH
            Console.WriteLine("update time: " + machineSnapshot.UpdateTime);

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
