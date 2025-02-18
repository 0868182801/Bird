using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour {

    public float flyPower = 100;

    public AudioClip flyClip;
    public AudioClip gameOverClip;
    public AudioClip point;
    private AudioSource audioSource;
    private Animator anim;
    GameObject obj;
    GameObject gameController;
	// Use this for initialization
	void Start () {
        obj = gameObject;
        audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = flyClip;
        anim = obj.GetComponent<Animator>();
        anim.SetFloat("flyPower",0);
        anim.SetBool("isDead", false);

        if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButton(0))
        {
            if (!gameController.GetComponent<GameController>().isEndGame)
                audioSource.Play();
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flyPower));            
        }
        anim.SetFloat("flyPower", obj.GetComponent<Rigidbody2D>().linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EndGame();
    }    

    void OnTriggerEnter2D(Collider2D other)
    {
        audioSource.clip = point;
        audioSource.Play();
        gameController.GetComponent<GameController>().GetPoint();
    }

    void EndGame()
    {
        anim.SetBool("isDead", true);
        audioSource.clip = gameOverClip;
        audioSource.Play();
        gameController.GetComponent<GameController>().EndGame();
    }
}
