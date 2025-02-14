using UnityEngine;

public class BatteryItem : MonoBehaviour
{
    /*******************************
    * private
    *******************************/
    [SerializeField] float delayTimeMax;
    [SerializeField] float speed;

    [SerializeField] float startUpSpeed;
    [SerializeField] float upDecreaseSpeed;

    float nowTime = 0;
    float batteryPower;

    private void FixedUpdate()
    {
        if (nowTime <= delayTimeMax)
        {
            nowTime += Time.deltaTime;
            return;
        }

        Vector3 targetPos = Player.readPlayer.GetPos();
        if (startUpSpeed > 0)
        {
            targetPos.y += startUpSpeed;
            startUpSpeed -= upDecreaseSpeed;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed);
    }

    /*******************************
    * public
    *******************************/
    public void Create(Vector3 pos ,float batteryPower)
    {
        var battery = Instantiate(this);
        battery.transform.position = pos;
        battery.batteryPower = batteryPower;
    }

    /*******************************
    * 衝突判定
    *******************************/

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //合成コストを増加させる
            DataManager.instance.IPlayerData().AddPossesionCombineCost(batteryPower);
            GetBatteryUI.Instance().AddBattey(batteryPower);
            Destroy(this.gameObject);
        }
    }
}
