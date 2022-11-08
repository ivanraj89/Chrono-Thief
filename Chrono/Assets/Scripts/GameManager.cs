using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //for canvas and text mesh pro


public class GameManager : MonoBehaviour
{

     public List<GameObject> enemies;
     public GameObject player;
     public TextMeshProUGUI scoreText;
     public int totalScore;

    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private int score;
    [SerializeField] private float xRange = 14;
    [SerializeField] private float ySpawnPos = 1;
    [SerializeField] private float zSpawnPos = 16;
    [SerializeField] private Vector3 prefabPos = new Vector3(0, 90, -90);

     


    private void Awake()
    {
        score = 0;
        scoreText.text = "" + score;  //set the score when awake to 0
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
         totalScore = UpdateScore(0); 
    }

    IEnumerator SpawnEnemy()
    {
        while (true) //spawn your characters
        {
            Vector3 position = new Vector3(Random.Range(-xRange, xRange), ySpawnPos, zSpawnPos);
            int index = Random.Range(0, enemies.Count);
            Instantiate(enemies[index], position, Quaternion.Euler(prefabPos));
            yield return new WaitForSeconds(spawnRate);
        }
            
    }

    public int UpdateScore(int scoreToAdd) // add 0 to innitial score and then return the final score to be stored in totalScore 
    {
        score += scoreToAdd;
        scoreText.text = "" + score;
        return (score) ;
    }
}
