using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneUIManager : MonoBehaviour
{
    private static GameSceneUIManager instance;
    public static GameSceneUIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance=FindObjectOfType<GameSceneUIManager>();   
            }
            return instance;
        }
    }

    [SerializeField]
    TextMeshProUGUI timeText;
    [SerializeField]
    TextMeshProUGUI allEnemyCount;
    [SerializeField]
    TextMeshProUGUI cureentEnemyCount;
    [SerializeField]
    TextMeshProUGUI allPortalCount;
    [SerializeField]
    TextMeshProUGUI cureentPortalCount;
    [SerializeField]
    TextMeshProUGUI consoleText;
    [SerializeField]
    TextMeshProUGUI hpText;
    [SerializeField]
    GameObject bombImage;
    [SerializeField]
    GameObject portalImage;
    [SerializeField]
    TextMeshProUGUI playerHP;
   

    public Slider slider;
    
    public GameObject console;
    public float StageTime;
 

    // Start is called before the first frame update
    private void Awake()
    {
        StageTime = 150f;

        slider.maxValue = 1;
        PortalCurrentCount(0);
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.currenStage==1)
        {
            StageTime -= Time.deltaTime;
            ChangeTIme(StageTime);
            if (StageTime <= 0)
            {
                
                GameManager.Instance.playerDie?.Invoke();
            }
        }
        else if(GameManager.Instance.currenStage==2&&!GameManager.Instance.GameClear)
        {
            StageTime -= Time.deltaTime;
            ChangeTIme(StageTime);
            if (StageTime <= 0)
            {
                GameManager.Instance.playerDie?.Invoke();
            }
        }

    }
    private void ChangeTIme(float time)
    {
        if(time<=0)
        { time = 0;
            LoadSceneManager.Instance.GoScene("ResultScene");
        }
        timeText.text=time.ToString("F2");
    }
    public void EnemyMaxCount(int enemy)
    {
        allEnemyCount.text = "/"+enemy.ToString();
    }
    public void EnemyCurrenCount(int enemy)
    {
        cureentEnemyCount.text = enemy.ToString();
    }
    public void PortalAllCount(int portal) 
    {
        allPortalCount.text = "/"+portal.ToString();
    }
    public void PortalAllCount(string test,int portal)
    {
        allPortalCount.text = test+"/" + portal.ToString();
    }
    public void PortalCurrentCount(int portal) 
    {
        cureentPortalCount.text=portal.ToString();
    }
    public void InstallBomb(float time)
    {
        slider.value=Mathf.Lerp(0,1,time/5);
    }
    public void Console(string console)
    {
        consoleText.text = console;
    }
    public void OnColsole()
    {
        console.SetActive(true);
    }
    public void OffConsole()
    {
        console.SetActive(false);
    }
    public void InBombposition()
    {
        slider.gameObject.SetActive(!slider.gameObject.activeSelf);
    }
    public void OutBombposition()
    {
        slider.gameObject.SetActive(false);
    }
    public void RightImage()
    {
        bombImage.SetActive(!bombImage.gameObject.activeSelf);
        portalImage.SetActive(!portalImage.gameObject.activeSelf);
    }
    public void PlayerHP(int nowhp)
    {
        playerHP.text = nowhp.ToString() + "/3";
    }
 
}
