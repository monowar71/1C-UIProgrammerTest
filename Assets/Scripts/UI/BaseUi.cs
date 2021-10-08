using UnityEngine;

public class BaseUi : MonoBehaviour
{
    internal virtual void Start()
    {
        UpdateUiValues();
        GameModel.ModelChanged += UpdateUiValues;
        GameModel.OperationComplete += OperationCompleteCather;
    }

    internal virtual void UpdateUiValues() { }

    internal virtual void OperationCompleteCather(GameModel.OperationResult result)
    {
        MessageController.Instance.HideMessage("loading");
        if (!result.IsSuccess)
        {
            MessageController.Instance.ShowMessage("error", result.ErrorDescription);
        }
    }
    internal virtual void OnDestroy()
    {
        GameModel.ModelChanged -= UpdateUiValues;
        GameModel.OperationComplete -= OperationCompleteCather;
    }
}
