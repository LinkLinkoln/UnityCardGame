using UnityEngine;

public class CreateDestroyCard : MonoBehaviour
{
    [SerializeField] private GameObject currentCard;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Canvas mainCanvas;
    public void CardCreate()
    {
        currentCard = Instantiate(prefab, prefab.transform.position, prefab.transform.rotation);
        currentCard.transform.SetParent(mainCanvas.transform, false);
    }

    public void CardDestroy()
    {
        Destroy(currentCard);
    }
}
