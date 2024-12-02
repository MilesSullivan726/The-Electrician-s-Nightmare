using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        GameObject.Find("Audio Manager").GetComponent<AudioManager>().PlayProjectile();
    }

    // Update is called once per frame
    void Update()
    {
        //rigidBody.AddForce(Vector2.up, ForceMode2D.Impulse);
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        //destroy out of bounds projectile
        if (transform.position.x < -5f)
        {
            Destroy(gameObject);
        }

        else if (transform.position.x > 5f)
        {
            Destroy(gameObject);
        }

        //top and bottom bounds
        if (transform.position.y > 5f)
        {
            Destroy(gameObject);
        }

        else if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
