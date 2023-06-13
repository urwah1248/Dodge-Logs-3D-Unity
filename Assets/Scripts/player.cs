using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpStrength = 7;
    public bool canJump = true;
    public GameManager gameManager; 
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")||Input.GetMouseButtonDown(0)){
            if(canJump&&!gameOver){
                rb.velocity = new Vector3(0,jumpStrength,0);
                canJump = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="Obstacle"){
            gameOver = true;
            SceneManager.LoadScene("Game");
        }
        
        if(collision.collider.tag=="Ground"){
            canJump = true;
        }
    }

    void OnTriggerEnter(){
        if(!gameOver){
            gameManager.ScoreIncrement();
        }
    }
}
