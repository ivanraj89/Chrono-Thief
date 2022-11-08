using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale += 0.3f * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1.1f);
        Time.fixedDeltaTime = Time.timeScale * 0.01f;

        transform.Translate(Vector3.down * -speed * Time.unscaledDeltaTime);
 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OutOfBounds"))
        {
            Destroy(gameObject);
        }
    }

    public void DoSlowDown()
    {
        Time.timeScale = 0.05f; //slowdown time
        Time.fixedDeltaTime = Time.timeScale * 0.01f; //smoothen slow motion
    }

}
