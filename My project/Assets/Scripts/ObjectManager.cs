using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private UIManager UIMan;
    public Sprite baconSprite;
    public Sprite beerSprite;
    public Sprite pieSprite;
    private PlayerController PC;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIMan = FindObjectOfType<UIManager>();
        PC = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other){
        if(other.collider.tag == "Player" && gameObject.name == "Bacon") {
            UIMan.GetBacon(baconSprite);
            PC.addObject();
        }

        if(other.collider.tag == "Player" && gameObject.name == "Beer") {
            UIMan.GetBeer(beerSprite);
            PC.addObject();
        }

        if(other.collider.tag == "Player" && gameObject.name == "PieApple") {
            UIMan.GetPie(pieSprite);
            PC.addObject();

        }

        Destroy(this.gameObject);
    }
}
