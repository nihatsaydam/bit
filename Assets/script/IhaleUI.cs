using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IhaleUI : MonoBehaviour
{
    public TextMeshProUGUI tenderNoText;
    public TextMeshProUGUI subjectText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI descriptionText;
    public Button participateButton;

    private Ihale ihale;
    private WorkerManager workerManager;

    void Awake()
    {
        // Referansları programatik olarak ayarlama
        tenderNoText = transform.Find("TenderNoText").GetComponent<TextMeshProUGUI>();
        subjectText = transform.Find("SubjectText").GetComponent<TextMeshProUGUI>();
        costText = transform.Find("CostText").GetComponent<TextMeshProUGUI>();
        descriptionText = transform.Find("DescriptionText").GetComponent<TextMeshProUGUI>();
        participateButton = transform.Find("ParticipateButton").GetComponent<Button>();
    }

    void Start()
    {
        workerManager = FindObjectOfType<WorkerManager>();
    }

    public void Setup(Ihale newIhale)
    {
        ihale = newIhale;
        tenderNoText.text = "Tender No: " + ihale.TenderNo;
        subjectText.text = ihale.Subject;
        costText.text = "Cost: $" + ihale.Cost.ToString("N2");
        descriptionText.text = ihale.Description;

        participateButton.onClick.AddListener(OnParticipateButtonClicked);
    }

    void OnParticipateButtonClicked()
    {
        // Gereksinimleri kontrol et ve ihaleye katıl
        bool meetsRequirements = CheckRequirements();
        if (meetsRequirements)
        {
            Debug.Log("Ihaleye katıldınız: " + ihale.Subject);
            // Gereksinimler karşılanıyorsa ihaleye katılma mantığını buraya ekleyin.
        }
        else
        {
            Debug.Log("Gereksinimler karşılanmıyor.");
        }
    }

    bool CheckRequirements()
    {
        // İşçi gereksinimlerini kontrol et
        foreach (string requirement in ihale.Requirements)
        {
            if (!workerManager.PlayerHasWorker(requirement))
            {
                return false;
            }
        }
        return true;
    }
}
