using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public AudioClip slowdownSound;
    public GameObject enemyPrefab;

    private Enemy enemy;
    private GameManager gameManager;
    private AudioSource playerAudio;

    public float timer;
    private float time = 1.5f;
    private int score = 0;
    public float speed = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        enemy = enemyPrefab.GetComponent<Enemy>();
        playerAudio = GetComponent<AudioSource>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.unscaledDeltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.unscaledDeltaTime;
        }

        timer += Time.deltaTime;

        if (timer >= time)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                enemy.DoSlowDown();
                timer = 0;
                playerAudio.PlayOneShot(slowdownSound, 0.5f);
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
                score = 500;
                gameManager.UpdateScore(score);
        }
        else if (other.CompareTag("OutOfBounds"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(3);
            SaveControl();


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(3);
            SaveControl();
        }
    }

    void SaveControl()
    {
        MainControl.Instance.playerScore = gameManager.totalScore;
        MainControl.Instance.SaveScore();
        
    }

}
