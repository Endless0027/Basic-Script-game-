using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // ����ƶ��ٶ�
    public float shootSpeed = 10f; // �ӵ�����ٶ�
    public GameObject bulletPrefab; // �ӵ�Ԥ����
    public AudioClip shootSound; // �����Ч
    private AudioSource audioSource; // ��ƵԴ

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); // ��ȡ��ƵԴ���
    }

    private void Update()
    {
        // ������ҵ��ƶ�����
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rb.velocity = movement * moveSpeed;

        // ������ҵ��������
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // ��ȡ�����λ��
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = hit.point;

            // �����ӵ����䷽��
            Vector3 shootDirection = (targetPosition - transform.position).normalized;

            // �����ӵ�����  ss
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Ϊ�ӵ����ó�ʼ�ٶ�
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = shootDirection * shootSpeed;

            // ���������Ч
            audioSource.PlayOneShot(shootSound);

            // ���ʵ���ʱ�������ӵ�
            Destroy(bullet, 3f); // ��3��������ӵ�
        }
    }
}
