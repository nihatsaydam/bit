using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro; 
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class login : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;

    public void OnSendButtonClicked()
    {
        // Input alanlarından verileri alın
        string username = usernameInput.text;
        string password = passwordInput.text;

        // HTTP isteği göndermek için bir URL belirleyin
        string url = "http://localhost/oyun/login.php";

        // Form oluşturun ve verileri ekleyin
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        // HTTP POST isteği gönderin
        StartCoroutine(SendRequest(url, form));
    }

    IEnumerator SendRequest(string url, WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                
            }
            else
            {
               SceneManager.UnloadScene("login");
                SceneManager.LoadScene("harita");
                // Yanıtı işleyin veya uygun şekilde yanıtı kullanın
            }
        }
    }
}