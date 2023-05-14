using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace EccobankAdmin.Conexiones
{
    public class Constantes
    {
        public static FirebaseClient firebase = new FirebaseClient("https://eccobank-58929-default-rtdb.firebaseio.com/");
        public const string webapiFirebase = "AIzaSyA1anlJ8hGmPmJ-7Lw6w672O0GTx7Ifp8E";
    }
}
