using UnityEngine;


public class BallController : MonoBehaviour
{

    public float speed;
    public float gravity;
    //public AudioSource audioPlayer;
    //public AudioClip bounceClip;
    // Create private references to the rigidbody component on the ball
    private Rigidbody rb;


    // At the start of the game..
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();

        //audioPlayer = GetComponent<AudioSource>();
    }

    // Each physics step..
    void FixedUpdate()
    {
        // add gravity on the z-axis using the gravity variable and deltaTime
        rb.AddForce(0, 0, -gravity * Time.deltaTime);
    }

    void OnCollisionEnter(Collision myCollision)
    {

        //Debug.Log(myCollision.relativeVelocity.magnitude);
        //only generate collision sound on harder hits
        if (myCollision.relativeVelocity.magnitude > 10)
        {
            //audioPlayer.PlayOneShot(bounceClip);
        }
    }
}