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
            bulletManager.ReturnBullet(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        bulletManager.ReturnBullet(gameObject);
    }
}
