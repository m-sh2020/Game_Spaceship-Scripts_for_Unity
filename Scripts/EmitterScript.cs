using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public float minDelay, maxDelay;
    public GameObject[] objects = new GameObject[4];

    float nextLauchTime;

    // Update is called once per frame
    void Update()
    {
        if (!GameController.instance.isGameStarted)
        {
            return;
        }
        if (Time.time > nextLauchTime)
        {
            float xPosition = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            float yPosition = 0;
            float zPosition = transform.position.z;
            var element = objects[Random.Range(0, objects.Length)];
            Instantiate(element, new Vector3(xPosition, yPosition, zPosition), Quaternion.identity);
            nextLauchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
