using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // no using serialize field here since it messes with the slow motion 

     private float speed = 10.0f;
     private float smoothen = 0.01f;
     private float clampMin = 0f;
     private float clampMax = 1.1f;
     private float slowdownFactor = 0.05f;
     private float slowdownLength = 0.3f;

    // start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() //Slowdown time
    {
        Time.timeScale += slowdownLength * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, clampMin, clampMax);
        Time.fixedDeltaTime = Time.timeScale * smoothen;

        transform.Translate(Vector3.down * -speed * Time.unscaledDeltaTime);
 
    }

    private void OnCollisionEnter(Collision collision) // checks to see if player hits enemy 
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) // checks to see if player hits mesh beyond the screen to destroy objects. Temporary solve instead of using object pooling
    {
        if (other.CompareTag("OutOfBounds"))
        {
            Destroy(gameObject);
        }
    }

    public void DoSlowDown()
    {
        Time.timeScale = slowdownFactor; //slowdown time
        Time.fixedDeltaTime = Time.timeScale * smoothen; //smoothen slow motion
    }

}
