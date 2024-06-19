using UnityEngine;
using System.Collections.Generic;

public class BulletController : MonoBehaviour
{
    public float destroyDelay = 2f; // 子弹销毁延迟时间

    private bool isInitialized = false; // 子弹是否已初始化
    private Rigidbody rb; // 子弹的刚体组件

    // 对象池
    private static Queue<GameObject> bulletPool = new Queue<GameObject>();

    // 初始化子弹
    public void InitializeBullet()
    {
        if (!isInitialized)
        {
            rb = GetComponent<Rigidbody>();
            isInitialized = true;
        }
    }

    // 发射子弹
    public void FireBullet(Vector3 direction, float speed)
    {
        InitializeBullet();

        // 设置子弹的移动方向和速度
        rb.velocity = direction.normalized * speed;

        // 启动定时器，延迟一定时间后销毁子弹
        Invoke("DestroyBullet", destroyDelay);
    }

    // 销毁子弹
    private void DestroyBullet()
    {
        // 重置子弹的状态
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;

        // 将子弹放回对象池
        bulletPool.Enqueue(gameObject);
        gameObject.SetActive(false);
    }

    // 从对象池中获取子弹对象
    public static GameObject GetBulletFromPool()
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        else
        {
            // 如果对象池为空，则创建新的子弹对象
            GameObject newBullet = Instantiate(Resources.Load<GameObject>("Bullet"));
            newBullet.GetComponent<BulletController>().InitializeBullet();
            return newBullet;
        }
    }
}
