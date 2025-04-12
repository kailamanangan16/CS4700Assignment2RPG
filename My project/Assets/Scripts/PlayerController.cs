using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    private Animator myAnimator;
    public int numObjects;
    private UIManager UIMan;

    [SerializeField]
    private float speed;
    

    void Start(){
        myRB = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        UIMan = FindObjectOfType<UIManager>();
        numObjects = 0;
    }

    void Update(){
        myRB.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))* speed * Time.deltaTime;

        myAnimator.SetFloat("moveX", myRB.linearVelocity.x);
        myAnimator.SetFloat("moveY", myRB.linearVelocity.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -11){
            myAnimator.SetFloat("lastX", Input.GetAxisRaw("Horizontal"));
            myAnimator.SetFloat("lastY", Input.GetAxisRaw("Vertical"));
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.collider.tag == "Snorlax" && numObjects >= 3) {
            UIMan.YouWin();
        }
    }

    public void addObject(){
        numObjects += 1;
    }
}
