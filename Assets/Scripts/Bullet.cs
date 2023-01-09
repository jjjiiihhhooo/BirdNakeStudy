using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed;
    public Vector3 dir;

    private void OnEnable()
    {
        speed = 3;
        StartCoroutine(SetActive());
    }

    private IEnumerator SetActive()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "enemy")
        {
            other.GetComponent<Enemy>().GetDamage(2);
            gameObject.SetActive(false);
        }
    }
}
