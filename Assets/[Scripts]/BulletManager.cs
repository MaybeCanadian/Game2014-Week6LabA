using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    private List<Queue<GameObject>> BulletPools;
    [Range(10, 200)]
    public List<int> bulletCount;
    public List<int> ActiveBullets;
    public List<int> RemainingBullets;
    private int totalPools;

    public Transform bulletParent;

    public static BulletManager instance;


    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;    
        }
    }

    void Start()
    {
        BulletPools = new List<Queue<GameObject>>();
        BuildBulletPools();
        for(int i = 0; i < totalPools; i++)
        {
            BuildBulletPool((e_BulletType)i);
        }
    }

    private void BuildBulletPools()
    {
        totalPools = 0;

        for(int i = 0; i <= Enum.GetValues(typeof(e_BulletType)).Cast<int>().Max(); i++)
        {
            var tempPool = new Queue<GameObject>();
                BulletPools.Add(tempPool);
            if(bulletCount.Count <= i)
                bulletCount.Add(50);
            if (ActiveBullets.Count <= i)
                ActiveBullets.Add(0);
            if (RemainingBullets.Count <= i)
                RemainingBullets.Add(0);

            totalPools++;
        }

    }

    private void BuildBulletPool(e_BulletType type)
    {
        
        for (int i = 0; i < bulletCount[(int)type]; i++)
        {
           
            CreateBullet(type);
        }

        RemainingBullets[(int)type] = BulletPools[(int)type].Count;
    }

    public GameObject GetBullet(Vector2 position, e_BulletType type)
    {
        if (!(BulletPools[((int)type)].Count > 0))
        {
            CreateBullet(type);
        }
            var bullet = BulletPools[(int)type].Dequeue();
            bullet.SetActive(true);
            bullet.transform.position = position;

        ActiveBullets[(int)type]++;
        RemainingBullets[(int)type] = BulletPools[(int)type].Count;

        return bullet;
    }

    private void CreateBullet(e_BulletType type)
    {

        //Debug.Log("test");
        var bullet = BulletFactory.FactoryInstance.CreateBullet(type);
        BulletPools[((int)type)].Enqueue(bullet);
        RemainingBullets[(int)type]++;
    }

    public void ReturnBullet(GameObject bullet, e_BulletType type)
    {
        bullet.SetActive(false);
        BulletPools[(int)type].Enqueue(bullet);

        ActiveBullets[(int)type]--;
        RemainingBullets[(int)type] = BulletPools[(int)type].Count;
    } 
}
