using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class BulletFactory : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletParent;

    //sprite textures
    public Sprite playerBulletSprite;
    public Sprite EnemyBulletSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerBulletSprite = Resources.Load<Sprite>("Sprites/Bullet");
        EnemyBulletSprite = Resources.Load<Sprite>("Sprites/EnemySmallBullet");
        bulletPrefab = Resources.Load("Prefabs/Bullet") as GameObject;
        bulletParent = GameObject.Find("Bullets").transform;
    }

    public GameObject CreateBullet(e_BulletType type = e_BulletType.player)
    {
        GameObject bullet = null;

        var testBullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
        testBullet.GetComponent<BulletBehaviour>().speed = 0.0f;

        switch (type)
        {
            case e_BulletType.player:
                testBullet.GetComponent<SpriteRenderer>().sprite = playerBulletSprite;
                testBullet.GetComponent<BulletBehaviour>().SetDirection(BulletDirection.up);
                break;
            case e_BulletType.enemy:
                testBullet.GetComponent<SpriteRenderer>().sprite = EnemyBulletSprite;
                testBullet.GetComponent<BulletBehaviour>().SetDirection(BulletDirection.down);
                break;
        }

        bullet.SetActive(false);

        return bullet;
    }
}
