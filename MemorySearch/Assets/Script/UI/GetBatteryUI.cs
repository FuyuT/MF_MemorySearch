using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetBatteryUI : MyUtil.SingletonMonoBehavior<GetBatteryUI>
{
    protected override bool dontDestroyOnLoad { get{ return true; } }
    [SerializeField]
    BatteryCountUI BatteryAddUI;

    //[SerializeField]
    public Animator Startanimator;
    float BatteryCount;

    public void AddBattey(float addCount)
    {
        BatteryAddUI.SetBatteryCount(addCount);
        PlayGetAnim();
    }

    void PlayGetAnim()
    {
        BehaviorAnimation.UpdateTrigger(ref Startanimator, "StartGetBattery");
    }
}
