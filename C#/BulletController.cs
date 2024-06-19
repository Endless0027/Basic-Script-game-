using UnityEngine;
using System.Collections.Generic;

public class BulletController : MonoBehaviour
{
    public float destroyDelay = 2f; // �ӵ������ӳ�ʱ��

    private bool isInitialized = false; // �ӵ��Ƿ��ѳ�ʼ��
    private Rigidbody rb; // �ӵ��ĸ������

    // �����
    private static Queue<GameObject> bulletPool = new Queue<GameObject>();

    // ��ʼ���ӵ�
    public void InitializeBullet()
    {
        if (!isInitialized)
        {
            rb = GetComponent<Rigidbody>();
            isInitialized = true;
        }
    }

    // �����ӵ�
    public void FireBullet(Vector3 direction, float speed)
    {
        InitializeBullet();

        // �����ӵ����ƶ�������ٶ�
        rb.velocity = direction.normalized * speed;

        // ������ʱ�����ӳ�һ��ʱ��������ӵ�
        Invoke("DestroyBullet", destroyDelay);
    }

    // �����ӵ�
    private void DestroyBullet()
    {
        // �����ӵ���״̬
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;

        // ���ӵ��Żض����
        bulletPool.Enqueue(gameObject);
        gameObject.SetActive(false);
    }

    // �Ӷ�����л�ȡ�ӵ�����
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
            // ��������Ϊ�գ��򴴽��µ��ӵ�����
            GameObject newBullet = Instantiate(Resources.Load<GameObject>("Bullet"));
            newBullet.GetComponent<BulletController>().InitializeBullet();
            return newBullet;
        }
    }
}
