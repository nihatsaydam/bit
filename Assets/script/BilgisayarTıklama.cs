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
        }
        else if (bilgisayarTuru == BilgisayarTuru.Worker)
        {
            workerPanel.SetActive(true);
            ihalePanel.SetActive(false);
        }
    }
}
