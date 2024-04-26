using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.IO;

public class SaveLoad : MonoBehaviour
{
    private string savePath;

    [SerializeField] private TimeManager timeManager;
    [SerializeField] private CharacterDataBase characterData;
    [SerializeField] private CharacterDataBase allCards;

    private void Awake()
    {
        savePath = Application.persistentDataPath + "/saveData.json";
        Debug.Log(savePath);
        LoadGame();
    }

    [Serializable]
    public class SaveData
    {
        [SerializeField] private int currentYear;
        public int CurrentYear => currentYear;

        [SerializeField] private List<string> storyCardIds;
        public List<string> StoryCardIds => storyCardIds;

        [SerializeField] private List<string> eventCardIds;
        public List<string> EventCardIds => eventCardIds;

        [SerializeField] private List<string> characterIds;
        public List<string> CharacterIds => characterIds;

        public SaveData(int year, List<string> storyIds, List<string> eventIds, List<string> charIds)
        {
            currentYear = year;
            storyCardIds = storyIds;
            eventCardIds = eventIds;
            characterIds = charIds;
        }
    }

    public void ReloadGame()
    {
        LoadGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SaveGame()
    {
        List<string> storyCardIds = new List<string>();
        foreach (var storyCard in characterData.StoryCards)
        {
            storyCardIds.Add(storyCard.ObjectId);
        }

        List<string> eventCardIds = new List<string>();
        foreach (var eventCard in characterData.EventCards)
        {
            eventCardIds.Add(eventCard.ObjectId);
        }

        List<string> characterIds = new List<string>();
        foreach (var character in characterData.Characters)
        {
            characterIds.Add(character.CharacterId);
        }

        SaveData saveData = new SaveData(timeManager.CurrentYear, storyCardIds, eventCardIds, characterIds);
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(savePath, json);
        Debug.Log(json);
    }

    public void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            timeManager.SetYear(saveData.CurrentYear);

            List<StoryCard> storyCards = new List<StoryCard>();
            foreach (string storyCardId in saveData.StoryCardIds)
            {
                StoryCard storyCard = allCards.GetStoryCardById(storyCardId);
                if (storyCard != null)
                {
                    storyCards.Add(storyCard);
                }
            }

            List<EventCard> eventCards = new List<EventCard>();
            foreach (string eventCardId in saveData.EventCardIds)
            {
                EventCard eventCard = allCards.GetEventCardById(eventCardId);
                if (eventCard != null)
                {
                    eventCards.Add(eventCard);
                }
            }

            List<Characters> characters = new List<Characters>();
            foreach (string characterId in saveData.CharacterIds)
            {
                Characters character = allCards.GetCharacterById(characterId);
                if (character != null)
                {
                    characters.Add(character);
                }
            }

            characterData.LoadCards(storyCards, eventCards, characters);
            Debug.Log("Игра загружена");
        }
        else
        {
            Debug.Log("Файл сохранения не найден.");
            SaveGame();
        }
    }
}