using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public TextMeshProUGUI apiText;

    public void GetAPI()
    {
        Usuario usuario = APIHelper.GetUsuario();
        apiText.text = usuario.user;
    }
}
