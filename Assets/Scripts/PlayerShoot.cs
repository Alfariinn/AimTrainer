using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] AudioClip shootSound;
    private AudioSource src;

    private Camera playerCamera;

    // Start is called before the first frame update
    void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
        src = GetComponentInChildren<AudioSource>();
        src.clip = shootSound;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            Shoot();
            src.Play();
        }
    }

    void Shoot ()
    {
        StatCalculator.shotsFired++;
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
        {
            ITarget target = hit.transform.GetComponent<ITarget>();
            if (target != null)
            {
                StatCalculator.points += +10;
                target.Hit();
            }
            else
            {
                StatCalculator.points -= 5;
                StatCalculator.shotsMissed++;
            }
                
        }
    }

    void OnEnable()
    {
        GameTime.OnGameEnd += GameEnd;
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
