using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New character", menuName = "Card/Create new character")]
public class Characters : ScriptableObject
{
    [SerializeField] private string objectId;
    public string CharacterId => objectId;

    [SerializeField] private List<CardBaseScript> randomCards;
    public List<CardBaseScript> RandomCards => randomCards;

}
