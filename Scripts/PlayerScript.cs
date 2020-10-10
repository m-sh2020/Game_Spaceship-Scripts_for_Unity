using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float shotDelay;
    public GameObject lazerShot, lazerShotSmallLeft, lazerShotSmallRight;
    public GameObject lazerGun, lazerGunLeft, lazerGunRight,playerExplosion;

    public float speed;
    public float xMin, xMax, zMin, zMax;
    public float tilt;
    Rigidbody ship;
    float nextShortTime, nextShortTime2, shotDelay2;

    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponent<Rigidbody>();
        shotDelay2 = shotDelay / 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.instance.isGameStarted)
        {
            return;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        float clampedX = Mathf.Clamp(ship.position.x, xMin, xMax);
        float clampedZ = Mathf.Clamp(ship.position.z, zMin, zMax);

        ship.position = new Vector3(clampedX, 0, clampedZ);

        ship.rotation = Quaternion.Euler(ship.velocity.z * tilt, 0, -ship.velocity.x * tilt);

        if (Time.time > nextShortTime && Input.GetButton("Fire1"))
        {
            Instantiate(lazerShot, lazerGun.transform.position, Quaternion.identity);
            nextShortTime = Time.time + shotDelay;
        }
        else
        if (Time.time > (nextShortTime2) && Input.GetButton("Fire2"))
            {
            Instantiate(lazerShotSmallLeft, lazerGunLeft.transform.position, Quaternion.Euler(0, -45, 0));
            Instantiate(lazerShotSmallRight, lazerGunRight.transform.position, Quaternion.Euler(0, 45, 0));
            nextShortTime2 = Time.time + shotDelay2;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LaserEnemy")
        {
            Instantiate(playerExplosion, transform.position, Quaternion.identity);
            GameController.instance.isGameStarted = false;
            Destroy(gameObject);
        }
    }
}
