using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMessageAfterAnimation : StateMachineBehaviour
{
    [SerializeField] private string messageTypeToClose;
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        MessageController.Instance.HideMessage(messageTypeToClose);
    }
}
