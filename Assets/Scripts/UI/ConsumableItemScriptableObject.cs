using UnityEngine;

[CreateAssetMenu(fileName = "ConsumableItem", menuName = "ConsumableItem", order = 1)]
public class ConsumableItemScriptableObject : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    [TextArea] public string description;
    public GameModel.ConsumableTypes consumableType;
}