using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerManager : MonoBehaviour
{
    public GameObject workerPanel;
    public Transform workerContent;
    public GameObject workerPrefab;

    private List<string> availableWorkers = new List<string>
    {
        "Painter", "Electrical Engineer", "Welder", "Blacksmith",
        "Tiler", "Plasterer", "Craftsman", "Carpenter", "Mason", "Plumber", "Electrician", "Mechanic"
    };
    private List<string> playerWorkers = new List<string>();

    void Start()
    {
        ShowAvailableWorkers();
    }

    void ShowAvailableWorkers()
    {
        foreach (var worker in availableWorkers)
        {
            GameObject workerObject = Instantiate(workerPrefab, workerContent);
            WorkerUI workerUI = workerObject.GetComponent<WorkerUI>();
            workerUI.Setup(worker, this);
        }
    }

    public void AddWorker(string worker)
    {
        if (!playerWorkers.Contains(worker))
        {
            playerWorkers.Add(worker);
            Debug.Log("İşçi eklendi: " + worker);
        }
        else
        {
            Debug.Log("İşçi zaten mevcut: " + worker);
        }
    }

    public bool PlayerHasWorker(string worker)
    {
        return playerWorkers.Contains(worker);
    }
}

public class WorkerUI : MonoBehaviour
{
    public Text workerNameText;
    public Button hireButton;
    private string worker;
    private WorkerManager workerManager;

    public void Setup(string newWorker, WorkerManager manager)
    {
        worker = newWorker;
        workerManager = manager;
        workerNameText.text = worker;
        hireButton.onClick.AddListener(OnHireButtonClicked);
    }

    void OnHireButtonClicked()
    {
        workerManager.AddWorker(worker);
    }
}
