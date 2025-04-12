using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private HealthManager healthMan;
    public Slider healthBar;
    public GameObject WinText;

    GameObject BaconImage;
    GameObject BeerImage;
    GameObject PieImage;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>();
        WinText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = healthMan.maxHealth;
        healthBar.value = healthMan.currentHealth;
        BaconImage = GameObject.Find("BaconImg");
        BeerImage = GameObject.Find("BeerImg");
        PieImage = GameObject.Find("PieImg");
        
    }

    public void GetBacon(Sprite s){
        BaconImage.GetComponent<Image>().sprite = s;
    }

    public void GetBeer(Sprite s){
        BeerImage.GetComponent<Image>().sprite = s;
    }

    public void GetPie(Sprite s){
        PieImage.GetComponent<Image>().sprite = s;
    }

    public void YouWin(){
        WinText.SetActive(true);
        Time.timeScale = 0;
    }
}
