using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; // Ѫ���� Slider ���
    public float fillSpeed = 0.5f; // Ѫ���������ٶ�

    private float targetValue; // Ŀ��Ѫ��ֵ
    private bool isUpdating; // �Ƿ����ڸ���Ѫ��

    private void Start()
    {
        isUpdating = false;
    }

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth; // ����Ѫ�������ֵ
        slider.value = maxHealth; // ��Ѫ���ĵ�ǰֵ����Ϊ���ֵ
    }

    public void SetHealth(int health)
    {
        targetValue = health; // ����Ŀ��Ѫ��ֵ

        if (!isUpdating)
        {
            // ���û�����ڸ���Ѫ������ʼЭ�����𽥸���Ѫ����λ��
            StartCoroutine(UpdateHealthBar());
        }
    }

    private System.Collections.IEnumerator UpdateHealthBar()
    {
        isUpdating = true;

        while (slider.value > targetValue)
        {
            slider.value -= fillSpeed * Time.deltaTime; // �𽥼�СѪ����λ��
            yield return null;
        }

        isUpdating = false;
    }
}
