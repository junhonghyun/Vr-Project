using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreContainer : MonoBehaviour
{
    private static ScoreContainer instance;
    public static ScoreContainer Instance 
    {
        get 
        { 
            if(instance == null)
            {
                instance =FindObjectOfType<ScoreContainer>();
            }
            return instance; 
        } 
    }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public int headShot;
    public int remainTime;//�����ð� 
    public void resetCount()
    {
        headShot = 0;
        remainTime = 0;
    }
}
