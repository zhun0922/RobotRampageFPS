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

�ʴ����� �ð��� ī��Ʈ�Ǹ� �����������ӿ��� �Ϸ�ȴ�.



2.Time.time

float Time.time

����� �������� ī��Ʈ�� ���۵ȴ�.*/
    }

    protected virtual void Update()
    {
    }
    protected void Fire()
    {
    }
}
