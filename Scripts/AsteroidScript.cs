using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;
    public float minSpeed, maxSpeed;
    public float rotation;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotation;
        float zSpeed = Random.Range(minSpeed, maxSpeed);
        asteroid.velocity = new Vector3(0,0,-zSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameBoundary")
        {
            return;
        }
        if (other.tag == "Asteroid")
        {
            return;
        }
       
        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
        if(other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
            GameController.instance.isGameStarted = false;
        }
        else
        {
            GameController.instance.score += 20;
        }
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
