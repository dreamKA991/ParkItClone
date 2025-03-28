using UnityEngine;
[RequireComponent (typeof(LevelGrading))]
public class GameTaskManager : MonoBehaviour
{
    [SerializeField] private bool canITouchProps = true;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private TimerManager timerManager;
    [SerializeField] private TimeTargetManager timeTargetManager;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private LevelGrading levelGrading;
    [SerializeField] private BannerAd bannerAd;
    private int grade = 3;
    [SerializeField] private bool isFinished = false;

    private void Start()
    {
        GlobalEventManager.onCharacterTouchedGameObject.AddListener(TouchObjectsLogic);
        GlobalEventManager.onCharacterParkedCorrectly.AddListener(GameWin);
        GlobalEventManager.onCharacterLose.AddListener(GameLose);
        GlobalEventManager.onRestart.AddListener(Restart);
    }

    private void TouchObjectsLogic(GameObject _obj) {
        string objTag = _obj.tag;
        if (objTag == "Player") return;
        if (objTag == "Prop") if (canITouchProps) return;
        GlobalEventManager.onCharacterLose.Invoke();
        Debug.Log("GameTaskManager: TouchObjectsLogic(GameObject) method called. GameObject is " + _obj.name);
    }

    private void GameWin()
    {
        if (isFinished) return;
        isFinished = true;
        Debug.Log("GameTaskManager: GameWin method called.");
        grade = timeTargetManager.GetGrade(timerManager.GetTimeInSeconds());
        uiManager.ToggleWinCanvas(grade);
        soundManager.PlayWinSounds();
        levelGrading.LevelGradeSave(grade);
    }

    private void GameLose()
    {
        if (isFinished) return;
        isFinished = true;
        Debug.Log("GameTaskManager: GameLose method called.");
        uiManager.ToggleLoseCanvas();
        soundManager.PlayLoseSounds();
        bannerAd.ShowBanner();
    }
    private void Restart()
    {
        isFinished = false;
    }
}
