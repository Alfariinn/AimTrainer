using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class TargetSphereController : MonoBehaviour, ITarget
{
    [Header("-----Position change range-----")]
    [SerializeField] bool changeY = true;
    [SerializeField] float rangeX = 3f;
    [SerializeField] float rangeY = 3f;
    [SerializeField] float rangeZ = 3f;
    [SerializeField] float distanceThreshold = 2f;

    [Header("-----Movement-----")]
    [SerializeField] bool move = true;
    [SerializeField] float movementDistance  = 3;
    [SerializeField] float movenetSpeed = 5;

    [Header("-----Size-----")]
    [SerializeField] bool randomizeSize;
    [SerializeField] float size = 1;

    private Vector3 originalPosition;
    private Vector3 oldPosition;
    private Vector3 newPosition;
    private bool distanceChanged = false;
    private bool isMovingRight;

    [SerializeField] AudioClip hitSound;
    private AudioSource src;

    private void Awake()
    {

        src = GetComponent<AudioSource>();
        src.clip = hitSound;
    }
    private void Start()
    {
        originalPosition = transform.position;
        newPosition = transform.position;
        transform.localScale = new Vector3(size, size, size);
    }

    public void Update()
    {
        
        if (move)
        {
            Move();
        }
    }

    public void Hit()
    {
        src.Play();

        oldPosition = transform.position;

        while (true)
        {
            newPosition = new Vector3(randomPosition("x"), (changeY?randomPosition("y"): originalPosition.y), originalPosition.z);
            distanceChanged = CheckDistance(newPosition, oldPosition);
            if (distanceChanged)
            {
                transform.position = newPosition;
                break;
            }
        }

        if (randomizeSize) randomSize();

    }

    private void Move()
    {
        if (!isMovingRight)
        {
            if (transform.position.x > newPosition.x - movementDistance)
            {
                transform.position = new Vector3(transform.position.x - movenetSpeed * Time.deltaTime, transform.position.y, transform.position.z);

            }
            else
                isMovingRight = !isMovingRight;
        }
        else
        {
            if (transform.position.x < newPosition.x + movementDistance)
            {
                transform.position = new Vector3(transform.position.x + movenetSpeed * Time.deltaTime, transform.position.y, transform.position.z);

            }
            else
                isMovingRight = !isMovingRight;
        }
    }



    private void randomSize()
    {
        size = Random.Range(0.5f, 2f);
        transform.localScale = new Vector3(size, size, size);
    }

    bool CheckDistance(Vector3 firstPosition, Vector3 secondPosition)
    {
        Vector3 difference = secondPosition - firstPosition;
        Debug.Log(difference.ToString());
        float distance = difference.magnitude;
        return distance > distanceThreshold;
    }

    private float randomPosition(string s)
    {
        float randomX = Random.Range(originalPosition.x - rangeX, originalPosition.x + rangeX);
        float randomY = Random.Range(originalPosition.y - rangeY, originalPosition.y + rangeY);
        float randomZ = Random.Range(originalPosition.z - rangeZ, originalPosition.z + rangeZ);

        switch (s)
        {
            case "x":
                return randomX;
            case "y":
                return randomY;
            case "z":
                return randomZ;
            default:
                return randomX;
        }
    }

}
