using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;
    protected float lastFireTime;

    public Ammo ammo;
    public AudioClip liveFire;
    public AudioClip dryFire;

    //Zoom
    public float zoomFactor;
    public int range;
    public int damage;
    private float zoomFOV;
    private float zoomSpeed = 6;
    void Start()
    {
        zoomFOV = Constants.CameraDefaultZoom / zoomFactor;
        lastFireTime = Time.time - 10;
    }
    /*  1.Time.deltaTime

float Time.deltatime

초단위로 시간이 카운트되며 마지막프레임에서 완료된다.



2.Time.time

float Time.time

선언된 시점에서 카운트가 시작된다.*/


    protected virtual void Update()
    {
        // Right Click (Zoom)
        if (Input.GetMouseButton(1))
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView,
           zoomFOV, zoomSpeed * Time.deltaTime);
        }
        else
        {
            Camera.main.fieldOfView = Constants.CameraDefaultZoom;
        }
    }
    protected void Fire()
    {
        if (ammo.HasAmmo(tag))
        {
            GetComponent<AudioSource>().PlayOneShot(liveFire);
            ammo.ConsumeAmmo(tag);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(dryFire);
        };
        GetComponentInChildren<Animator>().Play("Fire"); //왜 INChildren이지?

        //레이캐스트
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range))
        {
            processHit(hit.collider.gameObject);
        }
    }

    

    private void processHit(GameObject hitObject)
    {
        if (hitObject.GetComponent<Player>() != null)
        {
            hitObject.GetComponent<Player>().TakeDamage(damage);
        }
        if (hitObject.GetComponent<Robot>() != null)
        {
            hitObject.GetComponent<Robot>().TakeDamage(damage);
        }
    }
}
