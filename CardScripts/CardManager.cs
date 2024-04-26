using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private CreateDestroyCard createDestroyCard;
    [SerializeField] private CardGenerator cardGenerator;
    [SerializeField] private CardVisualizer visualizer;
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private CommandsManager commandsManager;
    private CardBaseScript currentCard;
    
    private void Start()
    {
        UpdateCard(0);
    }

    //Создание карты
    public void UpdateCard(int choiseIndex)
    {
        createDestroyCard.CardDestroy();
        createDestroyCard.CardCreate();
        currentCard = cardGenerator.GenerateCardIndex(choiseIndex);
    }

    //Обновление значений после применения к арты
    public void UpdateGameValues(int choiseIndex)
    {
        if (currentCard.ChoiseElements[choiseIndex].KingdomDamage.Length == healthManager.Health.Length)
        {
            healthManager.TakeDamage(currentCard.ChoiseElements[choiseIndex].KingdomDamage);
            healthManager.UpdateHealth(currentCard.ChoiseElements[choiseIndex].KingdomDamage);
        }
        timeManager.AddDays(currentCard, choiseIndex);
        commandsManager.CommandFindType(currentCard, choiseIndex);
    }
    //Визуализация карты
    public void StartVisualize()
    {
        visualizer.VisualizeCard(currentCard);
    }
}
