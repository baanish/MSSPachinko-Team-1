using UnityEngine;


public class BallController : MonoBehaviour
{

    public float speed;
    public float startSpeed;
    public float airSpeed;
    public float gravity;
    //public AudioSource audioPlayer;
    //public AudioClip bounceClip;
    // Create private references to the rigidbody component on the ball
    private Rigidbody rb;
    // ball prefab to instantiate for respawn
    public GameObject ballPrefab;



    // At the start of the game..
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();
        // add a force to the ball in the z direction at the start of the game
        rb.AddForce(Vector3.forward * startSpeed);
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

    void OnTriggerEnter(Collider other)
    {
        // when ball enters trigger with tag "LeftAirCurrent" add force to the ball in -x direction
        if (other.gameObject.CompareTag("LeftAirCurrent"))
        {
            rb.AddForce(-airSpeed, 0, 0, ForceMode.Impulse);
        }
        // when ball enters trigger with tag "RightAirCurrent" add force to the ball in +x direction
        if (other.gameObject.CompareTag("RightAirCurrent"))
        {
            rb.AddForce(airSpeed, 0, 0, ForceMode.Impulse);
        }
        //when ball enters trigger with tag "DeathZone" destroy the ball and respawn it at the start
        if (other.gameObject.CompareTag("DeathZone"))
        {
            Destroy(gameObject);
            GameObject newBall = Instantiate(ballPrefab, new Vector3(8.5f, 0.5f, -1.63f), Quaternion.identity);
            // enable the ballController script on the new ball
            newBall.GetComponent<BallController>().enabled = true;
        }
    }

}