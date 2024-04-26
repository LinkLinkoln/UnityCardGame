using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private SaveLoad saveLoad;

    [SerializeField] private TextMeshProUGUI daysText;
    [SerializeField] private TextMeshProUGUI yearsText; 

    [SerializeField] private int allLivedDays = 0;
    [SerializeField] private int currentYear = 0;
    private int daysInYear = 0; 

    public int DaysInYear => daysInYear;
    public int AllLivedDays => allLivedDays;
    public int CurrentYear => currentYear;

    public void SetYear(int setYear)
    {
        currentYear = setYear;
        VisualizeYear();
    }
    public void AddDays(CardBaseScript currentCard, int choiseIndex)
    {
        allLivedDays = allLivedDays + currentCard.ChoiseElements[choiseIndex].DaysAdd; daysInYear = daysInYear + currentCard.ChoiseElements[choiseIndex].DaysAdd;
        daysInYear = daysInYear + currentCard.ChoiseElements[choiseIndex].DaysAdd;
        if (daysInYear >= 365)
        {
            daysInYear = 0;
            currentYear++;
            VisualizeYear();
            saveLoad.SaveGame();
        }
        VisualizeDays();
    }
    private void VisualizeDays()
    {
        daysText.text = $"{allLivedDays} days of glorios reign";
    }
    private void VisualizeYear()
    {
        yearsText.text = $"{currentYear}th year from the new world";
    }
}
