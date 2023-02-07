using UnityEngine;

public class StatusSizer : MonoBehaviour
{
    private RectTransform placement;
    private Resolution _resolution;
    void Start()
    {
        _resolution = Screen.currentResolution;
        placement = GetComponent<RectTransform>();
        placement.localScale = new Vector3((float)(0.5 * _resolution.width) / 1920, (float) (0.5 * _resolution.height) / 1080);
        placement.anchoredPosition = new Vector2((float)(250 * _resolution.width) / 1920, (float) (-175 * _resolution.height) / 1080);
    }
}
