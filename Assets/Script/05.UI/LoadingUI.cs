using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingUI : MonoBehaviour
{
    [SerializeField]
    GameObject circle;
    float time;

    Transform rotationValue;

    private void Awake()
    {
        rotationValue = new GameObject().transform;
        rotationValue.rotation = Quaternion.Euler(0, 0, 1);
    }

    private void FixedUpdate()
    {
        time+= Time.deltaTime;
        NextSceneGo();
    }

    void NextSceneGo()
    {
        circle.transform.rotation *= rotationValue.rotation;
        if(time>=5)
        {
            LoadSceneManager.Instance.GoScene("BattleScene");
        }
    }
}

