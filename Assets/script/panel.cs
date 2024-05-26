using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject panel; // Panel objesini atanacak değişken
     public GameObject kayit; // Panel objesini atanacak değişken
   
    void Start()
    {
        // Oyun başladığında paneli devre dışı bırak
        panel.SetActive(false);
        kayit.SetActive(false);
       
    }

    public void TogglePanel()
    {
        // Panelin aktif durumunu tersine çevir
        panel.SetActive(!panel.activeSelf);
    }
    
   
}