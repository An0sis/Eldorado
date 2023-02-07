using UnityEngine;
using UnityEngine.UI;

public class LvlNumber : MonoBehaviour
{   
    public Image dizaine;
    public Image unite;
    
    public Sprite zero;
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    public Sprite seven;
    public Sprite eight;
    public Sprite nine;

    public void ChangeSprite(int lvl)
    {
        string str;
        if (lvl < 10)
        {
            str = "0" + lvl;
        }
        else
        {
            str = lvl.ToString();
        }

        switch (str[0])
        {
            case '0':
                dizaine.sprite = zero;
                break;
            case '1':
                dizaine.sprite = one;
                break;
            case '2':
                dizaine.sprite = two;
                break;
            case '3':
                dizaine.sprite = three;
                break;
            case '4':
                dizaine.sprite = four;
                break;
            case '5':
                dizaine.sprite = five;
                break;
            case '6':
                dizaine.sprite = six;
                break;
            case '7':
                dizaine.sprite = seven;
                break;
            case '8':
                dizaine.sprite = eight;
                break;
            case '9':
                dizaine.sprite = nine;
                break;
            default:
                dizaine.sprite = zero;
                break;
        }
        
        switch (str[1])
        {
            case '0':
                unite.sprite = zero;
                break;
            case '1':
                unite.sprite = one;
                break;
            case '2':
                unite.sprite = two;
                break;
            case '3':
                unite.sprite = three;
                break;
            case '4':
                unite.sprite = four;
                break;
            case '5':
                unite.sprite = five;
                break;
            case '6':
                unite.sprite = six;
                break;
            case '7':
                unite.sprite = seven;
                break;
            case '8':
                unite.sprite = eight;
                break;
            case '9':
                unite.sprite = nine;
                break;
            default:
                unite.sprite = zero;
                break;
        }
    }
}
