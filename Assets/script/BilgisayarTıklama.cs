using UnityEngine;

public class BilgisayarTıklama : MonoBehaviour
{
    public GameObject ihalePanel;
    public GameObject workerPanel;

    public BilgisayarTuru bilgisayarTuru;

    public enum BilgisayarTuru
    {
        Ihale,
        Worker
    }

    void OnMouseDown()
    {
        if (bilgisayarTuru == BilgisayarTuru.Ihale)
        {
            ihalePanel.SetActive(true);
            workerPanel.SetActive(false);
            Debug.Log("Hey, İhale Paneli açıldı!");
        }
        else if (bilgisayarTuru == BilgisayarTuru.Worker)
        {
            ihalePanel.SetActive(false);
            workerPanel.SetActive(true);
            Debug.Log("Hey, Worker Paneli açıldı!");
        }
    }
}
