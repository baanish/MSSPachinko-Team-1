using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private float lastDebuffTime = 0;
    private float nextDebuffTime = 0;
    private float debuffTime = 0;
    private bool isDebuffed = false;
    public GameObject ball = null;
    public BallController ballController = null;

    // Start is called before the first frame update
    void Start()
    {
        ball.GetComponent<GameObject>();
        ballController = ball.GetComponent<BallController>();

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
        int debuffChoice = Random.Range(1, 3);
        debuffChoice = 3;
        if (debuffChoice == 1)
        {
            // Ball heavier and harder to keep alive
            Debug.Log("Debuff 1");
            ballController.gravity = 750;
        }
        if (debuffChoice == 2)
        {
            // Ball is lighter and slower, hard to control
            Debug.Log("Debuff 2");
            ballController.gravity = 5;
        }
        if (debuffChoice == 3)
        {
            // Makes air currents more dangerous
            Debug.Log("Debuff 3");
            ballController.airSpeed = 24;
        }
    }

    void resetDebuffs()
    {
        ballController.gravity = 100;
        ballController.airSpeed = 4;
    }
}
