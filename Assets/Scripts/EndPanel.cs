using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPanel : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    void OnEnable()
    {
        GameTime.OnGameEnd += OnGameEnded;
    }

    void OnDisable()
    {
        GameTime.OnGameEnd -= OnGameEnded;
    }

    void OnGameEnded()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
