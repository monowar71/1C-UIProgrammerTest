using System.Collections.Generic;
using UnityEngine;

public class ReserveWindowController : BaseUi
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Transform itemsParent;
    [SerializeField] private List<ConsumableItemScriptableObject> objects = new List<ConsumableItemScriptableObject>();


    internal override void Start()
    {
        foreach (var prices in GameModel.ConsumablesPrice)
        {
            CreateItem(prices.Key, prices.Value);
        }
        base.Start();
    }

    private void CreateItem(GameModel.ConsumableTypes type, GameModel.ConsumableConfig config)
    {
        var item = objects.Find(o => o.consumableType == type);
        var itemObject = Instantiate(itemPrefab, itemsParent);
        if(itemObject.TryGetComponent(out ConsumableItemView itemComponent))
        {
            itemComponent.InitItem(item, config);
        }
        else
        {
            Debug.LogError("Could not create item without "+itemComponent.GetType());
        }
    }
}
