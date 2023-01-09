using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private bool isTarget;
    private bool isFire = true;
    private float fireDelay = 0.5f;
    [SerializeField] private float fireTimer;
    private Vector3 fireDir;
    private Bullet tempBullet;

    private void Update()
    {
        BulletFire();
    }

    private void BulletFire()
    {
        if(isTarget && isFire)
        {
            if(fireTimer > fireDelay)
            {
                transform.rotation = Quaternion.LookRotation(fireDir).normalized;
                tempBullet = BulletPool.instance.PopBullet();
                tempBullet.transform.position = this.transform.position;
                tempBullet.dir = fireDir;
                tempBullet.gameObject.SetActive(true);
                fireTimer = 0;
            }
            fireTimer += Time.deltaTime;
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            fireDir = other.transform.position - transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            isTarget = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            isTarget = false;
        }
    }
}
