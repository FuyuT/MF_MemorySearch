using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lockon : MonoBehaviour
{
    /*******************************
    * private
    *******************************/

    [SerializeField]
    GameObject target;

    [SerializeField]
    SearchMemory Search;

    [SerializeField]
    GameObject ScanImg;

    Animator ScanImgAnim;

    [SerializeField]
    float scanImagePosY;

    [SerializeField]
    Slider SearcSlider;

    private void Awake()
    {
    }

    void Start()
    {
        ScanImg.SetActive(false);
        ScanImgAnim = ScanImg.GetComponent<Animator>();
    }

    void Update()
    {
        if (target == null) return;
        UpdateScanImgTransform();

        PlayScanImgAnim();

        if (Search.isScan)
        {
            StopScanImgAnim();
        }
    }

    private void OnDisable()
    {
        ScanImg.SetActive(false);
    }

    void PlayScanImgAnim()
    {
        if (!Search.isScan && ScanImgAnim.speed == 0)
        {
            ScanImgAnim.speed = 1;
        }
    }

    void StopScanImgAnim()
    {
        if (Search.isScan)
        {
            ScanImgAnim.speed = 0;
            ScanImgAnim.Play("ScanPossible", 0, 0);
        }
    }

    void UpdateScanImgTransform()
    {
        Ray EnemyRay = new Ray(target.transform.position + new Vector3(0, 20, 0), new Vector3(0, -1, 0)); ;

        RaycastHit hit;
        if ( target.GetComponent<BoxCollider>(). Raycast(EnemyRay,out hit,30.0f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
               ScanImg.transform.position = hit.point + new Vector3(0,scanImagePosY,0);
            }
        }
        ScanImg.transform.rotation = Camera.main.transform.rotation;
    }

    /*******************************
    * public
    *******************************/

    public GameObject GetTarget()
    {
        return target;
    }

    /*******************************
    * �Փˏ���
    *******************************/

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag != "Enemy") return;

        if (target == null)
        {
            target = collision.gameObject;
            SearcSlider.value = 0;
            ScanImg.SetActive(true);

            return;
        }
        //�X�L�������Ă鎞�́A�^�[�Q�b�g��؂�ւ��Ȃ�
        if (Search.isScan)
        {
            if (target != null)
            {
                return;
            }
        }
        else
        {
            //���݂̃^�[�Q�b�g�ƁA�ʂ̃^�[�Q�b�g�̂ǂ��炪�v���C���[�ɋ߂������f����
            Vector3 PlayerPos = Player.readPlayer.GetPos();
            Vector3 temp = PlayerPos - target.transform.position;
            float targetDistance = temp.x + temp.y + temp.z;
            temp = Player.readPlayer.GetPos() - collision.transform.position;
            float collisionDistance = temp.x + temp.y + temp.z;

            if (collisionDistance <= targetDistance)
            {
                target = collision.gameObject;

                ScanImg.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag != "Enemy") return;
        if (collision.gameObject == target)
        {
            ScanImg.SetActive(false);
            target = null;
        }
      
    }
}