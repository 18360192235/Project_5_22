using UnityEngine;

public class GameMain : MonoBehaviour
{
    public static GameMain instance;

    public Transform m_resident;
    public Transform m_common;
    public Transform m_popup;
    public Transform m_tips;


    public PlayDataCache playData;
    
    private void PlayGame()
    {
        InitCache();
        InitCfg();
        InitManger();
        InitSDK();
    }
    /// <summary>
    /// 模块初始化
    /// </summary>
    private void InitManger()
    {
        UIManager.Sing.Init();
        //CardManager.Sing.Init(); // 游戏系统 
    }

    /// <summary>
    /// 初始化SDK
    /// </summary>
    private void InitSDK()
    {
        
    }
    /// <summary>
    /// 初始化配置
    /// </summary>
    private void InitCfg()
    {
        
    }

    /// <summary>
    /// 初始化缓存
    /// </summary>
    private void InitCache()
    {
        playData = new PlayDataCache();
        playData.Value.playLevel += 1;
        playData.OnSave();
    }

#region 生命周期函数
    private void Awake()
    {
        instance = this;
        PlayGame();
    }
    private void Start()
    {
        UIManager.Sing.ShowUI(UIDataDefault.MainUI);
    }

    private void OnDestroy()
    {
    }
    #endregion
}
