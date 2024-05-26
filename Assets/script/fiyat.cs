using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class BTCPriceFetcherTMP : MonoBehaviour
{
    public string url = "http://localhost/oyun/fiyat.php"; // PHP betiğinin URL'si
    public TMP_Text priceText; // TMP Text nesnesi
    private float refreshInterval = 60f; // Fiyatı her 60 saniyede bir güncelle

    void Start()
    {
        StartCoroutine(GetBTCPrice());
        InvokeRepeating("RefreshPrice", refreshInterval, refreshInterval);
    }

    void RefreshPrice()
    {
        StartCoroutine(GetBTCPrice());
    }

    IEnumerator GetBTCPrice()
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error: " + request.error);
            priceText.text = "BTC/USDT Fiyatı: Hata";
        }
        else
        {
            // JSON verisini al
            string jsonResponse = request.downloadHandler.text;
            BTCPrice priceData = JsonUtility.FromJson<BTCPrice>(jsonResponse);
            
            // TMP Text nesnesine fiyatı yaz
            priceText.text = "BTC/USDT Fiyatı: " + priceData.price + " USD";
        }
    }
}

[System.Serializable]
public class BTCPrice
{
    public string symbol;
    public string price;
}
