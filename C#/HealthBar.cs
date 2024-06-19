using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; // 血条的 Slider 组件
    public float fillSpeed = 0.5f; // 血条滚动的速度

    private float targetValue; // 目标血条值
    private bool isUpdating; // 是否正在更新血条

    private void Start()
    {
        isUpdating = false;
    }

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth; // 设置血条的最大值
        slider.value = maxHealth; // 将血条的当前值设置为最大值
    }

    public void SetHealth(int health)
    {
        targetValue = health; // 设置目标血条值

        if (!isUpdating)
        {
            // 如果没有正在更新血条，则开始协程来逐渐更新血条的位置
            StartCoroutine(UpdateHealthBar());
        }
    }

    private System.Collections.IEnumerator UpdateHealthBar()
    {
        isUpdating = true;

        while (slider.value > targetValue)
        {
            slider.value -= fillSpeed * Time.deltaTime; // 逐渐减小血条的位置
            yield return null;
        }

        isUpdating = false;
    }
}
