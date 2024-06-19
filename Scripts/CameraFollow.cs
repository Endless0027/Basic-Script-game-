using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Ҫ�����Ŀ�꣨��ң�

    public Vector3 offset; // �����Ŀ��֮���ƫ����

    public float smoothSpeed = 0.125f; // ����ƶ���ƽ���ٶ�

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target); // �����ʼ�ճ���Ŀ��
        }
    }
}
