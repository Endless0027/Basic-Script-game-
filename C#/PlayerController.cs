using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // 玩家移动速度
    public float shootSpeed = 10f; // 子弹射击速度
    public GameObject bulletPrefab; // 子弹预制体
    public AudioClip shootSound; // 射击音效
    private AudioSource audioSource; // 音频源

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); // 获取音频源组件
    }

    private void Update()
    {
        // 处理玩家的移动操作
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rb.velocity = movement * moveSpeed;

        // 处理玩家的射击操作
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // 获取鼠标点击位置
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = hit.point;

            // 计算子弹发射方向
            Vector3 shootDirection = (targetPosition - transform.position).normalized;

            // 创建子弹对象  ss
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // 为子弹设置初始速度
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = shootDirection * shootSpeed;

            // 播放射击音效
            audioSource.PlayOneShot(shootSound);

            // 在适当的时机销毁子弹
            Destroy(bullet, 3f); // 在3秒后销毁子弹
        }
    }
}
