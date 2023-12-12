using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatCalculator : MonoBehaviour
{
    [SerializeField] TMP_Text pointsText;
    [SerializeField] TMP_Text accuarcyText;
    [SerializeField] TMP_Text finalScore;
    public static float points;
    public static float accuarcy;
    public static float shotsFired;
    public static float shotsMissed;

    private void Update()
    {
        CalculateAccuarcy();
        pointsText.text = $"Points: {points.ToString("0")}";
        finalScore.text = $"Score: {points.ToString("0")}";
        accuarcyText.text = $"Accuarcy: {accuarcy.ToString("0")}%";

    }

        public void CalculateAccuarcy()
    {
        accuarcy = 100 - ((shotsMissed / shotsFired) * 100);
    }
    public static void ResetStats()
    {
        points = 0;
        accuarcy = 0;
        shotsFired = 0;
        shotsMissed = 0;
    }

}


