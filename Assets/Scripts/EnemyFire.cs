using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyFire : MonoBehaviour
{
    [SerializeField] private float fireTimer;

    private float fireDelay = 3f;
    private bool isTarget = true;
    private Vector3 fireDir;
    private Bullet tempBullet;
    public Manager manager;

    private void Update()
    {
        fireDir = manager.HeadVec() - transform.position;
        BulletFire();
    }

    private void BulletFire()
    {
        if (isTarget)
        {
            if (fireTimer > fireDelay)
            {
                tempBullet = BulletPool.instance.PopBullet();
                tempBullet.tag = "EnemyBullet";
                tempBullet.transform.position = this.transform.position;
                tempBullet.dir = fireDir;
                tempBullet.gameObject.SetActive(true);
                fireTimer = 0;
            }
            fireTimer += Time.deltaTime;
        }
    }
}
