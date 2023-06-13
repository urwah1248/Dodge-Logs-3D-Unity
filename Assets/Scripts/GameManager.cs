using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public Transform spawnPoint;
    int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstacles()
    {
        while(true){
            float waitTime = Random.Range(0.7f,2f);
            yield return new WaitForSeconds(waitTime);
            Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
        }
    }
    public void GameStart(){
        player.SetActive(true);
        playButton.SetActive(false);
        StartCoroutine("SpawnObstacles");
    }

    public void ScoreIncrement(){
        score += 1;
        scoreText.text = score.ToString();
        print(score);
    }
}
