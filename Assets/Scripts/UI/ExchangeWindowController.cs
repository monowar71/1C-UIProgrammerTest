using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ExchangeWindowController : BaseUi
{
    [SerializeField] private Text creditsForOneCoin;
    [SerializeField] private Text coinsBalance;
    [SerializeField] private Text creditsBalance;

    [SerializeField] private InputField coinsInput;
    [SerializeField] private Text creditsForCoins;
    [SerializeField] private Button exchangeButton;

    private int _creditsToConvert;

    private void OnEnable()
    {
        Reset();
    }

    internal override void Start()
    {
        base.Start();
        coinsInput.onValueChanged.AddListener(OnInputFieldValueChanged);
        exchangeButton.onClick.AddListener(ConvertCoinToCredits);
        
        creditsForOneCoin.text = GameModel.CoinToCreditRate.ToString();
    }

    private void Reset()
    {
        coinsInput.text = "0";
        creditsForCoins.text = "0";
    }

    internal override void UpdateUiValues()
    {
        base.UpdateUiValues();
        
        Reset();
        
        var culture = new CultureInfo("ru-RU");
        coinsBalance.text = GameModel.CoinCount.ToString("0,0", culture);
        creditsBalance.text = GameModel.CreditCount.ToString("0,0", culture);
    }

    private void OnInputFieldValueChanged(string sValue)
    {
        if (int.TryParse(sValue, out var value))
        {
            if (value > GameModel.CoinCount)
            {
                coinsInput.text = GameModel.CoinCount.ToString();
                value = GameModel.CoinCount;
            }
        }
        else
        {
            value = 0;
        }

        _creditsToConvert = value;
        creditsForCoins.text = (value * GameModel.CoinToCreditRate).ToString();
    }

    private void ConvertCoinToCredits()
    {
        GameModel.ConvertCoinToCredit(_creditsToConvert);
        MessageController.Instance.ShowMessage("loading");
    }

    internal override void OnDestroy()
    {
        base.OnDestroy();
        coinsInput.onValueChanged.RemoveListener(OnInputFieldValueChanged);
        exchangeButton.onClick.RemoveListener(ConvertCoinToCredits);
    }
}
