using System;
using UnityEngine;

[Serializable, CreateAssetMenu(menuName = "ScriptableObject/CardData")]
public class CardData : ScriptableObject
{
    public string Identifier => _identifier;
    public Sprite Sprite => _sprite;

    [SerializeField]
    private string _identifier;
    [SerializeField]
    private Sprite _sprite;
}
