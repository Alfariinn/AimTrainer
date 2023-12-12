using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController
    : MonoBehaviour
{
    [Header("Prefab Refrences")]
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public static bool gunVisible = true;

    [Header("Location Refrences")]
     private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;


    void Start()
    {
            gunAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gunAnimator.SetTrigger("Fire");
        }
    }

    void Shoot()
    {
        if (muzzleFlashPrefab)
        {
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            Destroy(tempFlash, destroyTimer);
        }
    }

    void CasingRelease()
    {
        if (!casingExitLocation || !casingPrefab)
        { return; }

        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation);
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower),
            (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        Destroy(tempCasing, destroyTimer);
    }

    void OnEnable()
    {
        GameTime.OnGameEnd += GameEnd;
        if (gunVisible)
            gameObject.SetActive(true);
        else gameObject.SetActive(false);
    }

    void OnDisable()
    {
        GameTime.OnGameEnd -= GameEnd;
    }

    private void GameEnd()
    {
        enabled = false;
    }
}


