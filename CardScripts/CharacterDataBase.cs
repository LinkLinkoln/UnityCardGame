using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CharacterDataBase", menuName = "Card/Create new CharacterDataBase")]
public class CharacterDataBase : ScriptableObject
{
    [SerializeField] private List<Characters> characters;
    [SerializeField] private List<StoryCard> storyCards;
    [SerializeField] private List<EventCard> eventCards;
    public List<Characters> Characters => characters;
    public List<StoryCard> StoryCards => storyCards;
    public List <EventCard> EventCards => eventCards;

    public void LoadCards(List<StoryCard> story, List<EventCard> events, List<Characters> charcters)
    {
        storyCards.Clear();
        storyCards.AddRange(story);

        eventCards.Clear();
        eventCards.AddRange(events);

        characters.Clear();
        characters.AddRange(charcters);
    }

    public StoryCard GetStoryCardById(string id)
    {
        foreach (var storyCard in storyCards)
        {
            if (storyCard.ObjectId == id)
            {
                return storyCard;
            }
        }
        return null;
    }
    public EventCard GetEventCardById(string id)
    {
        foreach (var eventCard in eventCards)
        {
            if (eventCard.ObjectId == id)
            {
                return eventCard;
            }
        }
        return null;
    }

    public Characters GetCharacterById(string id)
    {
        foreach (var character in characters)
        {
            Debug.Log($"characterId {id} AND {character.CharacterId}");
            if (character.CharacterId == id)
            {
                return character;
            }
        }
        return null;
    }


}



