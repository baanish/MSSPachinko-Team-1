using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManagerScript : MonoBehaviour
{
    private float lastDebuffTime = 0;
    private float nextDebuffTime = 0;
    private float debuffTime = 0;
    private bool isDebuffed = false;
    private bool icebergsDeployed = false;
    public GameObject ball = null;
    public BallController ballController = null;
    public GameObject icebergs = null;
    public TextMeshProUGUI debuffText = null;

    // Start is called before the first frame update
    void Start()
    {
        // find icebergs object
        icebergs = GameObject.Find("Icebergs");
        icebergs.SetActive(false);
        //debuffText = GetComponent<TextMeshProUGUI>();
        debuffText.text = "Smooth sailing!";
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - nextDebuffTime > 0)
        {
            debuffTime = Random.Range(8,12);
            nextDebuffTime = Time.time + debuffTime + Random.Range(25,35);
            lastDebuffTime = Time.time;
            debuffBall();
            Debug.Log("Debuffing ball for " + debuffTime + " seconds");
            isDebuffed = true;
           
           
        }
        else if (Time.time - (lastDebuffTime + debuffTime) > 0 && isDebuffed)
        {
            resetDebuffs();
            Debug.Log("Ball is no longer debuffed");
            isDebuffed = false; 
        }
    }

    void debuffBall()
    {
        findBall();
        int debuffChoice = Random.Range(1, 5);
        if (debuffChoice == 1)
        {
            // Ball heavier and harder to keep alive
            Debug.Log("Debuff 1");
            ballController.gravity = 750;
            debuffText.text = "The wind is getting stronger!";
        }
        if (debuffChoice == 2)
        {
            // Ball is lighter and slower, hard to control
            Debug.Log("Debuff 2");
            ballController.gravity = 5;
            debuffText.text = "The wind is getting weaker!";
        }
        if (debuffChoice == 3)
        {
            // Makes air currents more dangerous
            Debug.Log("Debuff 3");
            ballController.airSpeed = 24;
            debuffText.text = "Beware strong air currents!";
        }
        if (debuffChoice == 4)
        {
            Debug.Log("Debuff 4");
            icebergs.SetActive(true);
            icebergsDeployed = true;
            debuffText.text = "Icebergs ahead!";

        }
    }

    void resetDebuffs()
    {
        findBall();
        ballController.gravity = 100;
        ballController.airSpeed = 4;
        if (icebergsDeployed)
        {
            icebergs.SetActive(false);
            icebergsDeployed = false;
        }
        debuffText.text = "Smooth sailing!";
    }

    void findBall()
    {
        // find gameobject with tag "Ball"
        ball = GameObject.FindGameObjectWithTag("Ball");
        // get the ball controller script
        ballController = ball.GetComponent<BallController>();
    }
}
