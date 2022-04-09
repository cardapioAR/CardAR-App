using UnityEngine;
using System.IO;
using System.Net;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class APIHelper : MonoBehaviour
{
    [ContextMenu("Test Get")]
    public async void GetUsuario()
    {
        UnityWebRequest request = UnityWebRequest.Get("https://localhost:7023/API/v1/GetUsuarios");

        request.SetRequestHeader("Content-Type", "application/json");

        var operation = request.SendWebRequest();

        while (!operation.isDone) await Task.Yield();

        if (request.result == UnityWebRequest.Result.Success) Debug.Log(request.downloadHandler.text);
        else Debug.Log(request.error);
    }
}
