using UnityEngine;

[CreateAssetMenu(fileName = "New StoryCard", menuName = "Card/Create new story card")]

public class StoryCard : CardBaseScript
{
    [SerializeField] private int yearForDrop;
    [SerializeField] private int daysForDrop;
    public int YearForDrop => yearForDrop;
    public int DaysForDrop => daysForDrop;
}
