using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ExchangeMainScreenController : BaseUi
{
    [SerializeField] private Text coinsCountText;
    [SerializeField] private Text creditsCountText;
    [SerializeField] private Text armorCountText;
    [SerializeField] private Text medpackCountText;
    
    private void Update()
    {
        GameModel.Update();
    }

    internal override void UpdateUiValues()
    {
        base.UpdateUiValues();
        
        var culture = new CultureInfo("ru-RU");
        coinsCountText.text = GameModel.CoinCount.ToString("0,0", culture);
        creditsCountText.text = GameModel.CreditCount.ToString("0,0", culture);
        
        armorCountText.text = GameModel.GetConsumableCount(GameModel.ConsumableTypes.ArmorPlate).ToString();
        medpackCountText.text = GameModel.GetConsumableCount(GameModel.ConsumableTypes.Medpack).ToString();
    }
}
