using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;
    private Rigidbody2D rigidBody;
    public int speed;
    private float lastShot;
    public GameObject projectile;
    public float fireRate;
    public GameObject bones;
    public GameObject spawners;
    public GameObject music;
    public GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        rigidBody.AddForce(Vector3.up * verticalInput * Time.deltaTime * speed, ForceMode2D.Impulse);
        rigidBody.AddForce(Vector3.right * horizontalInput * Time.deltaTime * speed, ForceMode2D.Impulse);

        //Keep player on screen
        //left and right bounds
        if (transform.position.x < -4.5f)
        {
            transform.position = new Vector3(-4.5f, transform.position.y, transform.position.z);
        }

        else if (transform.position.x > 4.5f)
        {
            transform.position = new Vector3(4.5f, transform.position.y, transform.position.z);
        }

        //top and bottom bounds
        if (transform.position.y > 4.5f)
        {
            transform.position = new Vector3(transform.position.x, 4.5f, transform.position.z);
        }

        else if (transform.position.y < -4.5f)
        {
            transform.position = new Vector3(transform.position.x, -4.5f, transform.position.z);
        }

        //fire projectile
        if (Input.GetKeyDown(KeyCode.UpArrow) && Time.time - lastShot >= fireRate)
        {
            lastShot = Time.time;
            Instantiate(projectile, transform.position, transform.localRotation);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && Time.time - lastShot >= fireRate)
        {
            lastShot = Time.time;
            Instantiate(projectile, transform.position, Quaternion.Euler(180,0,0));
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && Time.time - lastShot >= fireRate)
        {
            lastShot = Time.time;
            Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, 90));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && Time.time - lastShot >= fireRate)
        {
            lastShot = Time.time;
            Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, -90));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameOverCanvas.SetActive(true);
            Instantiate(bones, transform.position, transform.rotation);
            GameObject.Find("Audio Manager").GetComponent<AudioManager>().PlayPlayerDeath();
            Destroy(spawners);
            Destroy(music);
            Destroy(gameObject);
        }
    }
}
