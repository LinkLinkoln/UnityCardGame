using UnityEngine;

[CreateAssetMenu(fileName = "New AddCardToList command", menuName = "Commands/Create AddCardToList")]
public class AddToListCommand : ScriptableObject
{
    [SerializeField] private ScriptableObject cardToAdd;
    public ScriptableObject CardToAdd => cardToAdd;
}
