using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class APIHelper : MonoBehaviour
{
    public TextMeshProUGUI apiText;
    public GameObject inputAPI;

    string baseUrl = "https://localhost:7023/API/v1/";

    // [ContextMenu("Test Get")]
    public async void GetUsuario()
    {
        try
        {
            string url = baseUrl + "GetUsuario/" + inputAPI.GetComponent<TMP_InputField>().text;

            UnityWebRequest request = UnityWebRequest.Get(url);

            request.SetRequestHeader("Content-Type", "application/json");

            var operation = request.SendWebRequest();

            while (!operation.isDone) await Task.Yield();

            var jsonResponse = request.downloadHandler.text;

            if (request.result != UnityWebRequest.Result.Success) Debug.LogError("Erro de Conexao");

            var jsonResponseFixed = jsonResponse.Replace("[", "").Replace("]", "");

            var result = JsonConvert.DeserializeObject<Usuario>(jsonResponseFixed);

            apiText.text = $"ID: {result.usuarioId}\n" +
                $"Usuário: {result.username}\n" +
                $"E-mail: {result.email}\n" +
                $"Senha: {result.password}";
        }
        catch (Exception ex)
        {
            apiText.text = $"Erro!\nUsuario não existe.";
            Debug.Log(ex);
            throw;
        }
    }
}