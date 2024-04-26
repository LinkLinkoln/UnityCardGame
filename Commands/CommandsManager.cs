using UnityEngine;
using UnityEngine.SceneManagement;

public class CommandsManager : MonoBehaviour
{
    [SerializeField] private CharacterDataBase characterData;
    [SerializeField] private SaveLoad saveLoad;
    [SerializeField] private HealthManager healthManager;

    public void CommandFindType(CardBaseScript currentCard, int choiseIndex)
    {
        ScriptableObject[] commands = currentCard.ChoiseElements[choiseIndex].Commands;

        for (int i = 0; i < commands.Length; i++)
        {
            //Проверку на DeathCheck добавляем только в те команды, которые не должны выпадать если карта убила игрока
            if (commands[i].GetType() == typeof(AddToListCommand) && healthManager.DeathCheck() != true) 
            {
                AddCard((AddToListCommand)commands[i]);
            }
            else if (commands[i].GetType() == typeof(LoadLastSave))
            {
                SceneManager.LoadScene("LoadingScreen");
            }
        }
    }
   

    private void AddCard(AddToListCommand currentCommand)
    {
        if (currentCommand.CardToAdd.GetType() == typeof(Characters))
        {
            characterData.Characters.Add((Characters)currentCommand.CardToAdd);
        }
        else if (currentCommand.CardToAdd.GetType() == typeof(StoryCard))
        {
            characterData.StoryCards.Add((StoryCard)currentCommand.CardToAdd);
        }
        else if (currentCommand.CardToAdd.GetType() == typeof(EventCard))
        {
            characterData.EventCards.Add((EventCard)currentCommand.CardToAdd);
        }
    }
}