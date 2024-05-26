using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AuctionPanelManager : MonoBehaviour
{
    public GameObject auctionItemPrefab; 
    public Transform contentParent; 
    public Button joinButton; 

    private BidGenerator bidGenerator;

    void Start()
    {
        bidGenerator = GameObject.FindObjectOfType<BidGenerator>();
        if (bidGenerator == null)
        {
            Debug.LogError("BidGenerator bulunamadı!");
            return;
        }

        GenerateAuctionItems();
    }

    void GenerateAuctionItems()
    {
        foreach (Bid bid in bidGenerator.bids)
        {
            GameObject auctionItem = Instantiate(auctionItemPrefab, contentParent);

            auctionItem.transform.Find("AuctionName").GetComponent<TMP_Text>().text = bid.bidName;
            auctionItem.transform.Find("AuctionDetails").GetComponent<TMP_Text>().text = bid.jobDetails;

            auctionItem.transform.Find("JoinButton").GetComponent<Button>().onClick.AddListener(() => OnJoinButtonClick(bid.bidName));
        }
    }

    void OnJoinButtonClick(string bidName)
    {
        Debug.Log("Katıl butonuna tıklandı! İhale adı: " + bidName);
        // Burada ilgili ihaleye katılma işlemleri yapılabilir
    }
}
