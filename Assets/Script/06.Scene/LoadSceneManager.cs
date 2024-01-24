using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    private static LoadSceneManager instance;
    public static LoadSceneManager Instance 
    {
        get 
        {
            if(instance == null)
            {
                instance = FindObjectOfType<LoadSceneManager>();
            }
            return instance;
        }
        
   }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void GoScene(string sceneName)
    {
        Debug.Log("æ¿¿Ãµø");
        SceneManager.LoadScene(sceneName);
    }
    
}
