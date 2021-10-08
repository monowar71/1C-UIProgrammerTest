using UnityEngine;
using UnityEngine.UI;

public class ConsumableItemView : BaseUi
{
    [SerializeField] private Text itemName;
    [SerializeField] private Image sprite;
    [SerializeField] private Text countText;
    [SerializeField] private Text description;
    [SerializeField] private Button buyForCreditsButton;
    [SerializeField] private Button buyForCoinsButton;
    [SerializeField] private Text priceForCreditsText;
    [SerializeField] private Text priceForCoinsText;

    private GameModel.ConsumableTypes _myType;

    internal override void UpdateUiValues()
    {
        base.UpdateUiValues();
        countText.text = GameModel.GetConsumableCount(_myType).ToString();
    }
    

    public void InitItem(ConsumableItemScriptableObject data, GameModel.ConsumableConfig config)
    {
        itemName.text = data.itemName;
        sprite.sprite = data.icon;
        description.text = data.description;
        buyForCoinsButton.gameObject.SetActive(false);
        buyForCreditsButton.gameObject.SetActive(false);

        if (config.CoinPrice != 0)
        {
            buyForCoinsButton.gameObject.SetActive(true);
            priceForCoinsText.text = config.CoinPrice.ToString();
            
            buyForCoinsButton.onClick.AddListener(BuyItemForCoins);
        }
        
        if (config.CreditPrice != 0)
        {
            buyForCreditsButton.gameObject.SetActive(true);
            priceForCreditsText.text = config.CreditPrice.ToString();
            
            buyForCreditsButton.onClick.AddListener(BuyItemForCredits);
        }
        
        _myType = data.consumableType;
        
        UpdateUiValues();
    }
    
    private void BuyItemForCredits()
    {
        GameModel.BuyConsumableForSilver(_myType);
        
        MessageController.Instance.ShowMessage("loading");
    }
    private void BuyItemForCoins()
    {
        GameModel.BuyConsumableForGold(_myType);
        MessageController.Instance.ShowMessage("loading");
    }
}

