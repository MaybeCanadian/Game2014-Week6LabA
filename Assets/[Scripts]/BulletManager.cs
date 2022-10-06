using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> bulletQueue;
    public GameObject bulletPrefab;
    [Range(10, 200)]
    public int bulletCount = 50;

    void Start()
    {
        bulletQueue = new Queue<GameObject>();
        BuildBulletPool();
    }

    private void BuildBulletPool()
    {
        for(int i = 0; i < bulletCount; i++)
        {
            CreateBullet();
        }
    }

    public GameObject GetBullet(Vector2 position, BulletDirection direction)
    {
        if (bulletQueue.Count == 0)
        {
            CreateBullet();
        }
            var bullet = bulletQueue.Dequeue();
            bullet.SetActive(true);
            bullet.transform.position = position;
            bullet.GetComponent<BulletBehaviour>().SetDirection(direction);

        return bullet;
    }

    private void CreateBullet()
    {
        var bullet = Instantiate(bulletPrefab);
        bullet.SetActive(false);
        bulletQueue.Enqueue(bullet);
    }

    public void RetrunBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletQueue.Enqueue(bullet);
    } 
}
