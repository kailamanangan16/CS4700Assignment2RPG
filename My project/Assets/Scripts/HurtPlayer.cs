using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    private HealthManager healthMan;
    public float waitToHurt = 2f;
    public bool isTouching;
    [SerializeField]
    private int damageToGive = 10;

    [SerializeField]
    private bool reloading = false;
    [SerializeField]
    private float waitToLoad = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouching){
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0){
                healthMan.HurtPlayer(damageToGive);
                waitToHurt = 1f;
            }
        }

        if (healthMan.currentHealth <= 0){
            reloading = true;
            if (reloading){
                waitToLoad -= Time.deltaTime;   
                if (waitToLoad <= 0){
                    healthMan.currentHealth = 50;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.collider.tag == "Player") {
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(damageToGive);
        }
    }

    private void OnCollisionStay2D(Collision2D other){
        if (other.collider.tag == "Player"){
            isTouching = true;
        }
    }

    void OnCollisionExit2D(Collision2D other){
        if (other.collider.tag == "Player"){
            isTouching = false;
            waitToHurt = 2f;
        }
    }
}
