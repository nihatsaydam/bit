using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bid
{
    public string bidName;
    public float minPrice;
    public float maxPrice;
    public float timeRemaining;
    public bool isActive;
    public string jobDetails;
    public float jobDuration; 
    public int requiredEmployeeCount; 
    public List<string> requiredEmployeeTypes; 
    public float participationFee; 
}

public class BidGenerator : MonoBehaviour
{
    public static BidGenerator Instance { get; private set; }

    public List<Bid> bids = new List<Bid>();
    public int numberOfBidsToGenerate = 10;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        GenerateBids(numberOfBidsToGenerate);
    }

    void GenerateBids(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Bid newBid = new Bid
            {
                bidName = "İhale " + (i + 1),
                minPrice = Random.Range(100000, 500000),
                maxPrice = Random.Range(500000, 1000000),
                timeRemaining = Random.Range(3600, 7200), // 1-2 saat
                isActive = true,
                jobDetails = "İşin Detayı " + (i + 1),
                jobDuration = Random.Range(30, 180), // 30-180 gün
                requiredEmployeeCount = Random.Range(1, 10),
                requiredEmployeeTypes = GenerateRandomEmployeeTypes(),
                participationFee = Random.Range(5000, 20000)
            };

            bids.Add(newBid);
        }
    }

    List<string> GenerateRandomEmployeeTypes()
    {
        List<string> allEmployeeTypes = new List<string> { "Elektrik Mühendisi", "İnşaat Mühendisi", "Mimar", "İşçi" };
        List<string> selectedEmployeeTypes = new List<string>();

        int count = Random.Range(1, allEmployeeTypes.Count);
        for (int i = 0; i < count; i++)
        {
            string employeeType = allEmployeeTypes[Random.Range(0, allEmployeeTypes.Count)];
            if (!selectedEmployeeTypes.Contains(employeeType))
            {
                selectedEmployeeTypes.Add(employeeType);
            }
        }

        return selectedEmployeeTypes;
    }
}
