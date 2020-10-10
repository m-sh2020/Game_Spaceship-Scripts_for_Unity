using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSmallLeftScript : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(-1*speed, 0, speed);
    }
}
