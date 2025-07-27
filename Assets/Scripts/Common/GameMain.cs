using UnityEngine;

public class GameMain : MonoBehaviour
{
    public static GameMain instance;

    public Transform m_resident;
    public Transform m_common;
    public Transform m_popup;
    public Transform m_tips;


    private void PlayGame()
    {
        InitManger();
    }
    /// <summary>
    /// 模块初始化
    /// </summary>
    private void InitManger()
    {
        UIManager.Sing.Init();
        //CardManager.Sing.Init(); // 游戏系统 
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
