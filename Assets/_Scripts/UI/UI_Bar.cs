using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_Bar : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float changeTime = 1f;

    [Header("Colors")]
    [SerializeField] private Color borderColor = Color.black;
    [SerializeField] private Color backgroundColor = Color.red;
    [SerializeField] private Color fillColor = Color.green;

    [Header("Images")]
    [SerializeField] private Image border;
    [SerializeField] private Image background;
    [SerializeField] private Image fillBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        border.color = borderColor;
        background.color = backgroundColor;
        fillBar.color = fillColor;
    }

    public void SetFillAmount(float fillAmount)
    {
        //tween between the values with easing over the change time
        DOTween.To(() => fillBar.fillAmount, x=> fillBar.fillAmount = x, fillAmount, changeTime).SetEase(Ease.OutCubic);
    }
}
