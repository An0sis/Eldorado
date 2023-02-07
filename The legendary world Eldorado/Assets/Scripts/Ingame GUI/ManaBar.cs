using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxMana(int mana, int add)
    {
        slider.maxValue = mana;
        slider.value += add;
    }

    public void SetMana(int mana)
    {
        slider.value = mana;
    }
}
