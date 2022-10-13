using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]
public class BulletFactory : MonoBehaviour
{

    private GameObject bulletPrefab;
    private Transform bulletParent;

    //sprite textures
    private Sprite playerBulletSprite;
    private Sprite EnemyBulletSprite;

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

        bullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity, bulletParent);
        //testBullet.GetComponent<BulletBehaviour>().speed = 0.0f;

        switch (type)
        {
            case e_BulletType.player:
                bullet.GetComponent<SpriteRenderer>().sprite = playerBulletSprite;
                bullet.GetComponent<BulletBehaviour>().SetDirection(BulletDirection.up);
                bullet.name = "Player Bullet";
                break;
            case e_BulletType.enemy:
                bullet.GetComponent<SpriteRenderer>().sprite = EnemyBulletSprite;
                bullet.GetComponent<BulletBehaviour>().SetDirection(BulletDirection.down);
                bullet.name = "Enemy Bullet";
                break;
        }

        bullet.GetComponent<BulletBehaviour>().type = type;
        //Debug.Log(type);
        bullet.SetActive(false);

        return bullet;
    }
}
