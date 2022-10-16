using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Boundry bounds;
    public Boundry SpeedBounds;
    public Boundry ScreenBounds;

    private float HorizontalSpeed;
    private float VerticalSpeed;

    public SpriteRenderer sr;

    [Header("Other Enemy Properties")]
    public Color randomColor;
    public SpriteRenderer spriteRenderer;
    public Transform bulletSpawn;
    public float FireRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ResetEnemy();
        InvokeRepeating("FireBullet", 0.0f, FireRate);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
        
    }

    private void Move()
    {
        var HorizontalLength = bounds.XMax - bounds.XMin;
        transform.position = new Vector3(Mathf.PingPong(Time.time * HorizontalSpeed, HorizontalLength) - bounds.XMax,
            transform.position.y - VerticalSpeed * Time.deltaTime, transform.position.z);
    }

    private void CheckBounds()
    {
        if (transform.position.y < ScreenBounds.YMin)
        {
            ResetEnemy();
        }
    }

    private void ResetEnemy()
    {
        float randomXPosition = Random.Range(bounds.XMin, bounds.XMax);
        float randomYPosition = Random.Range(bounds.YMin, bounds.YMax);

        transform.position = new Vector3(randomXPosition, randomYPosition, 0.0f);

        HorizontalSpeed = Random.Range(SpeedBounds.XMax, SpeedBounds.XMin);
        VerticalSpeed = Random.Range(SpeedBounds.YMax, SpeedBounds.YMin);

        List<Color> ColorList = new List<Color>() { Color.red, Color.yellow, Color.magenta, Color.cyan, Color.white, Color.white };

        sr.material.SetColor("_Color", ColorList[Random.Range(0, ColorList.Count)]);
    }

    private void FireBullet()
    {
        var bullet = BulletManager.instance.GetBullet(bulletSpawn.position, e_BulletType.enemy);
    }
}
