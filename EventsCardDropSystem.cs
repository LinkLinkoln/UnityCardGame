using UnityEngine;

public class EventsCardDropSystem : MonoBehaviour
{
    [SerializeField] private HealthManager healthManager;
    public CardBaseScript EventCardCheck(CharacterDataBase characterData)
    {
        for (int i = 0; i < characterData.EventCards.Count; i++)
        {
            float maxHealthToDrop = characterData.EventCards[i].MaxHealthToDrop;
            float minHealthToDrop = characterData.EventCards[i].MinHealthToDrop;
            float currentHealth = TypeOfHealthSet(characterData.EventCards[i]);
            if (currentHealth <= maxHealthToDrop && currentHealth >= minHealthToDrop)
            {
                float randomValue = Random.Range(0f, 1);
                randomValue = Mathf.Round(randomValue * 100f) / 100f;
                if (characterData.EventCards[i].dropChance >= randomValue)
                {
                    Debug.Log($"Карта выпала {characterData.EventCards[i]}");
                    characterData.EventCards[i].dropChance = characterData.EventCards[i].SavedDropChance;
                    return characterData.EventCards[i];
                }
                else
                {
                    characterData.EventCards[i].dropChance += characterData.EventCards[i].AddChanceOnTurn;
                }
            }
        }
        return null;
    }

    public float TypeOfHealthSet(EventCard currentEventCard)
    {
        switch (currentEventCard.TypeOfHealth.ToString())
        {
            case "Army":
                return healthManager.Health[0];
            case "Church":
                return healthManager.Health[1];
            case "People":
                return healthManager.Health[2];
            case "Harvest":
                return healthManager.Health[3];
            case "Epidemic":
                return healthManager.Health[4];
            case "KingdomPower":
                return healthManager.Health[5];
            case "Gold":
                return healthManager.Health[6];
        }
        return 0;
    }
}
