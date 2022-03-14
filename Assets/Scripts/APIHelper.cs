using UnityEngine;
using System.IO;
using System.Net;

public static class APIHelper
{
    public static Usuario GetUsuario()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:44356/api/getusuario");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();

        return JsonUtility.FromJson<Usuario>(json);
    }
}
