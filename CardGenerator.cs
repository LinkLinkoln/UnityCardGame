using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    [SerializeField] private CharacterDataBase characterData;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private EventsCardDropSystem eventsCardDropSystem;

    private CardBaseScript currentCard;
    private int currentCharcterIndex;
    private int currentCharacterCardIndex;

    private bool EventCardCheck()
    {
        currentCard = eventsCardDropSystem.EventCardCheck(characterData);
        if (currentCard != null)
        {
            return true;
        }
        return false;
    }
    public CardBaseScript GenerateCardIndex(int choiseIndex)
    {
        if (StoryCardCheck() == true)
        {
            return currentCard;
        }
        else if (currentCard == null)
        {
            RandomCard();
            return currentCard;
        }
        else if (currentCard.ChoiseElements[choiseIndex].NextCard != null)
        {
            currentCard = currentCard.ChoiseElements[choiseIndex].NextCard;
            return currentCard;
        }
        else if (EventCardCheck() == true)
        {
            return currentCard;
        }
        else
        {
            RandomCard();
        }
        return currentCard;
    }
    public bool StoryCardCheck()
    {
        for (int i = 0; i < characterData.StoryCards.Count; i++)
        {
            StoryCard currentStoryCard = characterData.StoryCards[i];
            if (currentStoryCard.DaysForDrop <= timeManager.DaysInYear && currentStoryCard.YearForDrop <= timeManager.CurrentYear)
            {
                currentCard = characterData.StoryCards[i];
                characterData.StoryCards.Remove(characterData.StoryCards[i]);
                return true;
            }
        }
        return false;
    }
    public void RandomCard()
    {
        currentCharcterIndex = Random.Range(0,characterData.Characters.Count);
        currentCharacterCardIndex = Random.Range(0, characterData.Characters[currentCharcterIndex].RandomCards.Count);
        currentCard = characterData.Characters[currentCharcterIndex].RandomCards[currentCharacterCardIndex];
    }
}
