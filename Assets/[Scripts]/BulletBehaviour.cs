using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletBehaviour : MonoBehaviour
{
    [Header("Bullet Properties")]
    public BulletDirection direction;
    public float speed;
    public Boundry bounds;
    private Vector3 velocity;
    public e_BulletType type;

    [Header("Bullet References")]
    public BulletManager bulletManager;
    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
        SetDirection(direction);
    }

    public void SetDirection(BulletDirection inDirection)
    {
        switch (inDirection)
        {
            case BulletDirection.up:
                velocity = Vector3.up * speed;
                break;
            case BulletDirection.right:
                velocity = Vector3.right * speed;
                break;
            case BulletDirection.down:
                velocity = Vector3.down * speed;
                break;
            case BulletDirection.left:
                velocity = Vector3.left * speed;
                break;
        }

        direction = inDirection;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position += velocity * Time.deltaTime;
    }

    private void CheckBounds()
    {
        if (transform.position.x > bounds.XMax || transform.position.x < bounds.XMin ||
            transform.position.y > bounds.YMax || transform.position.y < bounds.YMin)
        {
            bulletManager.ReturnBullet(gameObject, type);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch(type) 
        {
            case e_BulletType.player:
                if(collision.tag == "Enemy")
                {
                    bulletManager.ReturnBullet(gameObject, type);
                }
                break;
            case e_BulletType.enemy:
                if(collision.gameObject.tag == "Player")
                {
                    Debug.Log("ow");
                    bulletManager.ReturnBullet(gameObject, type);
                }
                break;
        }
    }
}
