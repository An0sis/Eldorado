using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxXp(int xp, int add)
    {
        slider.maxValue = xp;
        slider.value += add;
    }

    public void SetXp(int xp)
    {
        slider.value = xp;
    }
}
