using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class IhaleManager : MonoBehaviour
{
    public GameObject ihalePanel;
    public Transform ihaleContent;
    public GameObject ihalePrefab;

    private List<Ihale> ihaleListesi = new List<Ihale>();
    private string jsonDosyaYolu = "Assets/script/ihaleler.json";

    void Start()
    {
        LoadIhaleler();
        ShowIhaleler();
    }

    void LoadIhaleler()
    {
        string json = File.ReadAllText(jsonDosyaYolu);
        IhaleListesi ihaleListesiObject = JsonUtility.FromJson<IhaleListesi>(json);
        ihaleListesi = ihaleListesiObject.ihaleler;
    }

    void ShowIhaleler()
    {
        foreach (var ihale in ihaleListesi)
        {
            GameObject ihaleObject = Instantiate(ihalePrefab, ihaleContent);
            IhaleUI ihaleUI = ihaleObject.GetComponent<IhaleUI>();
            ihaleUI.Setup(ihale);
        }
    }
}

[System.Serializable]
public class IhaleListesi
{
    public List<Ihale> ihaleler;
}
