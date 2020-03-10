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
    }
}
