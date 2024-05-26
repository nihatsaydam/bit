using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class RSSReader : MonoBehaviour
{
    public TMP_Text newsTextPrefab;
    public Transform contentParent;

    IEnumerator Start()
    {
        string url = "http://localhost/oyun/haber.php"; // PHP API URL'nizi buraya yazın

        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error: " + www.error);
            yield break;
        }

        string jsonString = www.downloadHandler.text;
        string[] newsTitles = jsonString.Split(',');

        foreach (string title in newsTitles)
        {
            TMP_Text newsText = Instantiate(newsTextPrefab, contentParent);
            newsText.text = title;
        }
    }
}
