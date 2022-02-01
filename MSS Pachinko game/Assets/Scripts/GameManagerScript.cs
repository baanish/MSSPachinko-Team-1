using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private float lastDebuffTime = 0;
    private float nextDebuffTime = 0;
    private float debuffTime = 0;
    private bool isDebuffed = false;
    private bool icebergsDeployed = false;
    public GameObject ball = null;
    public BallController ballController = null;
    public GameObject Iceberg1 = null;
    public GameObject Iceberg2 = null;
    public GameObject Iceberg3 = null;
    public GameObject Iceberg4 = null;
    public GameObject Iceberg5 = null;
    public GameObject Iceberg6 = null;

    // Start is called before the first frame update
    void Start()
    {
        ball.GetComponent<GameObject>();
        ballController = ball.GetComponent<BallController>();
        //Iceberg1.GetComponent<GameObject>();
        Iceberg1.transform.position = new Vector3(1.46f, -1, -1.87f);
        Iceberg2.transform.position = new Vector3(6.73f, -1, -1.99f);
        Iceberg3.transform.position = new Vector3(-8.11f, -1, 2.7f);
        Iceberg4.transform.position = new Vector3(-2.01f, -1, -3.58f);
        Iceberg5.transform.position = new Vector3(-0.91f, -1, 2.22f);
        Iceberg6.transform.position = new Vector3(1.74f, -1, 4.43f);
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
        int debuffChoice = Random.Range(1, 4);
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
        if (debuffChoice == 4)
        {
            Debug.Log("Debuff 4");
            Iceberg1.transform.position = new Vector3(1.46f, 0.5f, -1.87f);
            Iceberg2.transform.position = new Vector3(6.73f, 0.5f, -1.99f);
            Iceberg3.transform.position = new Vector3(-8.11f, 0.5f, 2.7f);
            Iceberg4.transform.position = new Vector3(-2.01f, 0.5f, -3.58f);
            Iceberg5.transform.position = new Vector3(-0.91f, 0.5f, 2.22f);
            Iceberg6.transform.position = new Vector3(1.74f, 0.5f, 4.43f);
            icebergsDeployed = true;

        }
    }

    void resetDebuffs()
    {
        ballController.gravity = 100;
        ballController.airSpeed = 4;
        if (icebergsDeployed)
        {
            Iceberg1.transform.position = new Vector3(1.46f, -1, -1.87f);
            Iceberg2.transform.position = new Vector3(6.73f, -1, -1.99f);
            Iceberg3.transform.position = new Vector3(-8.11f, -1, 2.7f);
            Iceberg4.transform.position = new Vector3(-2.01f, -1, -3.58f);
            Iceberg5.transform.position = new Vector3(-0.91f, -1, 2.22f);
            Iceberg6.transform.position = new Vector3(1.74f, -1, 4.43f);
            icebergsDeployed = false;
        }
    }
}
