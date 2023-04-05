using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;
    protected float lastFireTime;

    void Start()
    {
        lastFireTime = Time.time - 10;
      /*  1.Time.deltaTime

float Time.deltatime

초단위로 시간이 카운트되며 마지막프레임에서 완료된다.



2.Time.time

float Time.time

선언된 시점에서 카운트가 시작된다.*/
    }

    protected virtual void Update()
    {
    }
    protected void Fire()
    {
    }
}
