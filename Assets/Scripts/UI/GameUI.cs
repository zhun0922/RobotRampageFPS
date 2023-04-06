using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    Sprite redReticle;
    [SerializeField]
    Sprite yellowReticle;
    [SerializeField]
    Sprite blueReticle;
    [SerializeField]
    Image reticle;

    //�̹����� ��������Ʈ�� ����

  /*  ��������Ʈ�� ���ʿ� �ִϸ��̼��� ����������� �Ѹ����� ������� �˰���.
    Image�� �ݵ�� Canvas �Ʒ��� �־�߸��ϰ�,

    Sprite�� �ٱ� �ʿ� �־ ������� ȭ�鿡 ���Դϴ�.*/

    public void UpdateReticle()
    {
        switch (GunEquipper.activeWeaponType)
        {
            case Constants.Pistol:
                reticle.sprite = redReticle;
                break;
            case Constants.Shotgun:
                reticle.sprite = yellowReticle;
                break;
            case Constants.AssaultRifle:
                reticle.sprite = blueReticle;
                break;
            default:
                return;
        }
    }
}
