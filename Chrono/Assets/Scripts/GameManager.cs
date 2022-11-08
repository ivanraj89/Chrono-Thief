using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //for canvas and text mesh pro


public class GameManager : MonoBehaviour
{
    public List<GameObject> enemies;
    public GameObject player;
    public TextMeshProUGUI scoreText;

    private float spawnRate = 2f;
    private int score;
    private float xRange = 14;
    private float ySpawnPos = 1;
    private float zSpawnPos = 16;
    private Vector3 prefabPos = new Vector3(0, 90, -90);

    public int totalScore;


    private void Awake()
    {
        score = 0;
        scoreText.text = "" + score; 
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
        while (true)
        {
            Vector3 position = new Vector3(Random.Range(-xRange, xRange), ySpawnPos, zSpawnPos);
            int index = Random.Range(0, enemies.Count);
            Instantiate(enemies[index], position, Quaternion.Euler(prefabPos));
            yield return new WaitForSeconds(spawnRate);
        }
            
    }

    public int UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "" + score;
        return (score) ;
    }
}
