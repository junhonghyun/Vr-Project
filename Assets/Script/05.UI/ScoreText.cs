using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI score; 
    [SerializeField]
    TextMeshProUGUI time;
    [SerializeField]
    TextMeshProUGUI headShot;
    private void Awake()
    {
        if(ScoreContainer.Instance.remainTime<=0)
        {
            ScoreContainer.Instance.remainTime = 0;
        }
        time.text = ScoreContainer.Instance.remainTime.ToString();
        headShot.text=ScoreContainer.Instance.headShot.ToString();
        int total = ScoreContainer.Instance.remainTime*10 + ScoreContainer.Instance.headShot*30;
        score.text= total.ToString();
    }
}
