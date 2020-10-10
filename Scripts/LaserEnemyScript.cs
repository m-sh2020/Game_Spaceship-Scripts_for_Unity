using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemyScript : MonoBehaviour
{
    public float speed;
    public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform.position - transform.position;
        transform.LookAt(target);
        GetComponent<Rigidbody>().velocity = new Vector3(target.x, target.y, target.z) ;
    }
}
