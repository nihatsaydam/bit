using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class singin : MonoBehaviour
{
  
    public TMP_InputField usernameInput; // Kullanıcı adı input alanı
    public TMP_InputField passwordInput; // Şifre input alanı
    public TMP_InputField mailInput; // E-posta input alanı
    public TMP_InputField soruInput; // Gizli soru input alanı
    public GameObject kayit; // Panel objesini atanacak değişken
    

    public void OnSendButtonClicked()
    {
        // Input alanlarından verileri alın
        string username = usernameInput.text;
        string password = passwordInput.text;
        string mail = mailInput.text;
        string soru = soruInput.text;

        // HTTP isteği göndermek için bir URL belirleyin
        string url = "http://localhost/oyun/singin.php";

        // Form oluşturun ve verileri ekleyin
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);
        form.AddField("mail", mail);
        form.AddField("soru", soru);

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
                Debug.LogError("HTTP isteği başarısız: " + www.error);
            }
            else
            {
                kayit.SetActive(false);
                

                // Yanıtı işleyin veya uygun şekilde yanıtı kullanın
            }
        }
    }
}
