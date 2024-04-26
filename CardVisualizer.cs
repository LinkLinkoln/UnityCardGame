using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardVisualizer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cardName;
    [SerializeField] TextMeshProUGUI cardDescription;
    public void VisualizeCard(CardBaseScript currentCard)
    {
        Image icon = GameObject.FindGameObjectWithTag("Card").GetComponent<Image>();
        TextMeshProUGUI yesText = GameObject.FindGameObjectWithTag("YesText").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI noText = GameObject.FindGameObjectWithTag("NoText").GetComponent<TextMeshProUGUI>();

        cardName.text = currentCard.CardName;
        cardDescription.text = currentCard.CardDescription;
        icon.sprite = currentCard.CardIcon;
        yesText.text = currentCard.AgreeText;
        noText.text = currentCard.DisagreeText;
    }
}
