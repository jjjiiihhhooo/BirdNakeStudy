using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour , IDamaged
{
    private int hp = 30;
    private float x;
    private float y;
    private float speed;
    private float timer;
    private Vector3 dir;

    private Manager manager;

    private void OnEnable()
    {
        timer = 30;
        manager = FindObjectOfType<Manager>();
        transform.GetComponentInChildren<EnemyFire>().manager = manager;
        SetPosition();
        SetDir();
    }

    private void Update()
    {
        transform.position += Time.deltaTime * dir * speed;
        if (timer <= 0)
        {
            SetDir();
            timer = 50;
        }
        else if (timer > 0)
            timer -= 0.1f;

        if (transform.position.x >= 8.0f || transform.position.x <= -8.0f)
            dir.x *= -1;
        else if(transform.position.y >= 4.0f || transform.position.y <= -4.0f)
            dir.y *= -1;

        if (hp < 0) 
            SetPosition();
    }

    private void SetDir()
    {
        float randomX = Random.Range(-1.0f, 1.0f);
        float randomY = Random.Range(-1.0f, 1.0f);
        dir = new Vector3(randomX, randomY, 0);
    }

    private void SetPosition()
    {
        speed = Random.Range(1.0f, 3.0f);
        float randomX = Random.Range(8.0f, -8.0f);
        float randomY = Random.Range(4.0f, -4.0f);

        transform.position = new Vector3(randomX, randomY, 0);
        hp = 30;
    }

    public void SetDamaged(int _damage)
    {
        hp -= _damage;
    }
}
