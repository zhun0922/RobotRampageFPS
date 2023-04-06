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

    //이미지와 스프라이트의 차이

  /*  스프라이트는 애초에 애니메이션을 낮은비용으로 뿌릴려고 만들어진 알고리즘.
    Image는 반드시 Canvas 아래에 있어야만하고,

    Sprite는 바깥 쪽에 있어도 사용자의 화면에 보입니다.*/

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
