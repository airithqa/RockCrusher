using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;



public class targetScript : MonoBehaviour
{
   
    private gameManager gameManager;
    
    private Rigidbody targetRb;
    
    public ParticleSystem explosionParticle;
    
    private float minSpeed = 12;
    
    private float maxSpeed = 18;
    
    private float maxTorque = 8;
    
    private float xRange = 10;
    
    private float ySpawnPos = -10;
    public bool rockDisapear;
  
    public int pointValue=2;
    public float StartTime;
    public float EndTime;
    void Start()
    {
        
        targetRb=GetComponent<Rigidbody>();
    
        targetRb.AddForce(RandomForce(),ForceMode.Impulse);
    
        targetRb.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(),ForceMode.Impulse);

        transform.position = RandomSpawnPos();

        gameManager = GameObject.Find("Game Manager").GetComponent<gameManager>();
        
        
    }
    void FixedUpdate()
    {
       DestroyObjects();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange,xRange),ySpawnPos);
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            if (!gameObject.CompareTag("Bad"))
            {
                Destroy(gameObject);
                Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
                gameManager.UpdateScore(pointValue);
                
            }

            if (gameObject.CompareTag("Bad"))
            {
                Destroy(gameObject);
                Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
                gameManager.GameOver();
            }
            
        }
        
    }

    public void DestroyObjects()
    {
        StartTime += 0.1f;
        if (StartTime >= EndTime)
        {
            if (!gameObject.CompareTag("good"))
            {
                Destroy(gameObject);
            }
            if (gameObject.CompareTag("good"))
            {
                Destroy(gameObject);
                gameManager.health--;
            }
        }
    }

    public void ReduceHealth()
    {
        
    }


}