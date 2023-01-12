using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDamaged
{
    [SerializeField] private float speed;
    public Vector3 dir;

    private SpriteRenderer sprite;

    private void OnEnable()
    {
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(SetActive());
        if (this.tag == "EnemyBullet")
        {
            speed = 2f;
            sprite.color = Color.black;
        }
        else if (this.tag == "PlayerBullet")
        {
            speed = 8;
            sprite.color = Color.red;
        }
    }

    private IEnumerator SetActive()
    {
        yield return new WaitForSeconds(7f);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "enemy" && this.tag == "PlayerBullet")
        {
            other.GetComponent<IDamaged>().SetDamaged(5);
            gameObject.SetActive(false);
        }
        else if((other.tag == "head" || other.tag == "body") && this.tag == "EnemyBullet")
        {
            other.GetComponent<IDamaged>().SetDamaged(5);
            gameObject.SetActive(false);
        }
    }

    public void SetDamaged(int _damage)
    {
        
    }
}
