using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    GameUI gameUI;
    [SerializeField]
    private int pistolAmmo = 20;
    [SerializeField]
    private int shotgunAmmo = 10;
    [SerializeField]
    private int assaultRifleAmmo = 50;
    public Dictionary<string, int> tagToAmmo;
    // Start is called before the first frame update
    void Awake()
    {
        tagToAmmo = new Dictionary<string, int> //선언과 동시에 초기화
        {
             { Constants.Pistol , pistolAmmo},
             { Constants.Shotgun , shotgunAmmo},
             { Constants.AssaultRifle , assaultRifleAmmo},
         };
    }

    public void AddAmmo(string tag, int ammo)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized gun type passed: " + tag);
        }
        tagToAmmo[tag] += ammo;
    }
    // Returns true if gun has ammo
    public bool HasAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized gun type passed: " + tag);
        }
        return tagToAmmo[tag] > 0; //0보다 크다면 true반환
    }
    public int GetAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized gun type passed:" + tag);
        }
        return tagToAmmo[tag]; //딕셔너리 value반환 
    }
    public void ConsumeAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized gun type passed:" + tag);
        }
        tagToAmmo[tag]--;
    }

}
