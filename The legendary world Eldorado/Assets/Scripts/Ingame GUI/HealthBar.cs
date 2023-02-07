using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health, int add)
    {
        slider.maxValue = health;
        slider.value += add;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
