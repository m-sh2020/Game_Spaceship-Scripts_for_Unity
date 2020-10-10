using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject playerExplosion;
    public float minSpeed, maxSpeed;
    public GameObject lazerShotEnemy;
    public GameObject lazerGunEnemy;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody enemy = GetComponent<Rigidbody>();
        float zSpeed = Random.Range(minSpeed, maxSpeed);
        float angle = Random.Range(-0.5f, 0.5f);
        enemy.velocity = new Vector3(zSpeed * angle, 0, -zSpeed );
        StartCoroutine(Fire());
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameBoundary")
        {
            return;
        }
        Instantiate(playerExplosion, transform.position, Quaternion.identity);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
        Destroy(other.gameObject);
    }

    IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(lazerShotEnemy, lazerGunEnemy.transform.position, Quaternion.identity);
        }
    }

}
