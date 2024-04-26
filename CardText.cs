using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class CardText : MonoBehaviour
{
    private Image _blackTextArea;
    [SerializeField] private TextMeshProUGUI noText;
    [SerializeField] private TextMeshProUGUI yesText;
    float alphaSpeedText = 70f;
    float alphaSpeedBackground = 10;

    public void makeVisible()
    {
        _blackTextArea = gameObject.GetComponent<Image>();
        _blackTextArea.color = new Color(0, 0, 0, Math.Clamp(Math.Abs(transform.rotation.z * alphaSpeedBackground), 0, 0.3f));

        Color colorNoText = noText.color;
        colorNoText.a = transform.rotation.z * alphaSpeedText;
        noText.color = colorNoText;

        Color colorYesText = yesText.color;
        colorYesText.a = transform.rotation.z * -alphaSpeedText;
        yesText.color = colorYesText;
    }

}
