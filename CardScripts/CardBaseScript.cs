using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Create new card")]
public class CardBaseScript : ScriptableObject
{
    #region  Variable
    [SerializeField] private string objectId;
    public string ObjectId => objectId;

    [SerializeField] private string cardName;
    [SerializeField] private string cardDescription;
    [SerializeField] private string agreeText;
    [SerializeField] private string disagreeText;
    [SerializeField] private Sprite cardIcon;

    public string CardName => cardName;
    public string CardDescription => cardDescription;
    public string AgreeText => agreeText;
    public string DisagreeText => disagreeText;
    public Sprite CardIcon => cardIcon;
    #endregion
    //����� ������� �������� ��������� ������.
    [System.Serializable]
    public class ChoiseElement
    {
        //0 - �����, 1 - �������, 3 - ������ ����, 4 - ��������, 5 - ��������, 6 - ������ ������, 7 - �����;
        [SerializeField] private int daysAdd;
        [SerializeField] private int[] kingdomDamage;
        [SerializeField] private CardBaseScript nextCard;
        [SerializeField] private ScriptableObject[] commands;

        public int DaysAdd => daysAdd;
        public int[] KingdomDamage => kingdomDamage;
        public CardBaseScript NextCard => nextCard;
        public ScriptableObject[] Commands => commands;
    }

    [SerializeField] private List<ChoiseElement> choiseDamage;
    public List<ChoiseElement> ChoiseElements => choiseDamage;
    
}
