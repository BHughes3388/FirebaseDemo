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
        static void Authenticate()
        {

            FirestoreDb db = new FirestoreDbBuilder
            {

            }.Build();

            var FireStoreCredentials = "{\r\n  \"type\": \"service_account\",\r\n  \"project_id\": \"firestoredemo-262aa\",\r\n  \"private_key_id\": \"6e756ad231046b85b9f3e6db7f166291f4c00483\",\r\n  \"private_key\": \"-----BEGIN PRIVATE KEY-----\\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQC2+sceBYMes9Ms\\nVsmWms6dT0ImNLR3qXe80iziMNdfPo4YlLO78u+585ulYzbQKUM4eA0BduVNdBL1\\nWoYKw5asweSgAIph3rJinLYuqjHo1qebbGKG8v/mclr03wHsE4GeLToe0WldzqVa\\nkCGwe6Jh9cDaDjae9lKJ/vxWRuTSBnRQqEAkzXiGq4IQtSpaMP8MpZwurJ6igVmP\\nI+IBOFRclgN18gdImpeb0dPbDqbkHdybeLMLMbaLMhk+MeFsJxTfl+jXLdyKfJ7V\\nO4JBese5SV1Z2v93I/duS7qA/FUZN3DfYINxoZIRw+7Fds+vLrNaqaBkizbeEe4O\\nTYZ6EHeNAgMBAAECggEAAX8RZ3UO3Ed4vud35jrlh8TNcGfEtkSxdl7I+NjJvMRh\\nzhnEUrwZP+M2gLFaSwLxmGVYtlNowMEe3JHLVWH6pNpAZv5YXEBsI13BDFEzqIH2\\nqCZWl0PRkuq1C5on8CVZzWW8EI2tFDCWX+tjfc7QlIcOzGfuIMD/fFsUhU6MHJtY\\nyFo3xwFWhNrwtkYdgjF0yBqdanMiAk88yuoCHiCsjks2+vBCL4xj3fUbpUksqHSM\\nm8LUER5g0LIWeLuKz98o1Qg8uzl96jEnSpEfiXjLE274d1+1BSD/cTl5eKm+yqF7\\nWdRKuiCIcmLXKRf7SO3mgHP3yWVFTIvNNKjdRUjIwQKBgQD1JK2U+JipOfugSa+X\\nGrq3Oe1G64q2zZICPe/viS5UqHtQG6jtS+Z/4FVkkoJWE51iPL+xerCMIuDSgaDY\\nuDUuzNVu4WsGCi9+Ucg11cRU7dsmdZAgjIC7x/paq/eUogSlVfiH7+Y55EVY3Uln\\nwOryUDON44DrAI3tyAoWwwitLQKBgQC/FVEJbkfgzRdeovzecDoUqHhKWe5I53j3\\nBcZBbi/wOK9w26TwXRNEcKNJz6cr0DeT4gDsXEDfRfIWthW/38VMmW1TqMBAFSqV\\nippj/jk5qKv10YBQOijkIaW4gVnS42QOVyFk8w1cWyjgS1tfYBkyDSEeq4ZQ1eeU\\nUKHjL1kv4QKBgQDI01BkvzeJQxgRmuv/VQVrf0gUFnhgA46+yXDbgj1zW0cSPGaq\\nZ8igL+6k4qVl0NHZHb1IryMc2qHlsg5MHLRs759WI9Micouv512mRMZ/cRBctGjr\\nUU9RBqXhTAoaOJSnwgNFkdHA0XHCOB6fodqXwf5KGfuOCbk79+nT9dkQzQKBgHhD\\n0l09K8AxVSQbMUxPFj8qSYuCTpdUGK5g1AcactGe280McSNXcWkB+8PZDj5lLpXF\\nCQ+6gJoGS/g/YjEBhgxQBJ9C9r1elQ7JzaJhv2Kq5pAw67GS6WmsQ8F8qCwzMiZU\\ncJA46Y/XUELbKwc8VJ9L5CyJiGAYQUj39uwmQNwBAoGAQh3dhk5OeQikkFWmTnq8\\nYRk+mRv9CW+fXUnJFxzBfdfIiF6J4Uf5HXizYVJGUdx1XJufy26zpLNLxGoRJxR8\\n/8/2XV0mbSV73r/nVxgtp9D4/GGViwL1z1hvnr7Ixrpus2AKVVLHMeGWm/hGTq3h\\nqQkNP3ZAWsBAAKXQlVeFkUc=\\n-----END PRIVATE KEY-----\\n\",\r\n  \"client_email\": \"firebase-adminsdk-we3kz@firestoredemo-262aa.iam.gserviceaccount.com\",\r\n  \"client_id\": \"110219188225501423104\",\r\n  \"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",\r\n  \"token_uri\": \"https://oauth2.googleapis.com/token\",\r\n  \"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",\r\n  \"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-we3kz%40firestoredemo-262aa.iam.gserviceaccount.com\"\r\n}\r\n";
            var project = "firestoredemo-262aa";
            var path = "C:\\Users\\brad.JCW\\Desktop\\FirestoreCredentials.JSON";
            //var credential = GoogleCredential.FromFile(path);
            var credential = GoogleCredential.FromJson(FireStoreCredentials);

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
            Console.WriteLine(snapshot.Id);
        }


    }
}
