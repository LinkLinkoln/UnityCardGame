using UnityEngine;

[CreateAssetMenu(fileName = "New EventCard", menuName = "Card/Create new event card")]
public class EventCard : CardBaseScript
{
    [SerializeField] private ChooseTypeOfHealth typeOfHealth;
    [SerializeField] private float maxHealthToDrop;
    [SerializeField] private float minHealthToDrop;
    [SerializeField] private float addChanceOnTurn;
    public float dropChance;

    public ChooseTypeOfHealth TypeOfHealth => typeOfHealth;
    public float MaxHealthToDrop => maxHealthToDrop;
    public float MinHealthToDrop => minHealthToDrop;
    public float AddChanceOnTurn => addChanceOnTurn;
    private float savedDropChance = 0;
    public float SavedDropChance => savedDropChance;


    private void OnValidate()
    {
        savedDropChance = dropChance;
        UnityEditor.EditorUtility.SetDirty(this);
    }

    private void OnDisable()
    {
        if (!Application.isPlaying)
        {
            dropChance = savedDropChance;
        }
    }
}


