using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public AudioClip slowdownSound;
    [SerializeField] public GameObject enemyPrefab;

    [SerializeField] private Enemy enemy;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioSource playerAudio;

    [SerializeField] public float timer;
    [SerializeField] private float time = 1.5f;
    [SerializeField] private int score = 0;
    [SerializeField] public float speed = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        enemy = enemyPrefab.GetComponent<Enemy>();
        playerAudio = GetComponent<AudioSource>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // not so good for performance but a simple game should be fine

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) // doing input this way instead of Input.GetAxis removes inertia issues
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

    private void OnTriggerEnter(Collider other) // updates score accordingly
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

    private void OnCollisionEnter(Collision collision) // destroy gameobject, load game over scene and save the score 
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(3);
            SaveControl();
        }
    }

    void SaveControl() // function for saving the total score 
    {
        MainControl.Instance.playerScore = gameManager.totalScore;
        MainControl.Instance.SaveScore();
        
    }

}
