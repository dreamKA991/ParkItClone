using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private CarController carController;
    [SerializeField] private Toggle inputControlsToggle;
    private bool useTouchControls;
    [SerializeField] private bool isLiftButtonsActive = false;
    [SerializeField] private GameObject liftButtons;
    [SerializeField] private ScoresStarsAnimation scoresStarsAnimation;
    [SerializeField] private TimeTargetManager timeTargetManager;
    [SerializeField] private TimeFinished timeFinished;
    [SerializeField] private TimerManager timerManager;
    private bool isMenuOpened = false;
    private bool isPopuped = false;
    // MENUSs
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject loseCanvas;
    [SerializeField] private GameObject menuCanvas;
    private void Awake()
    {
        useTouchControls = carController.useTouchControls;
        UpdateLiftButtons();
    }

    public void InputControlsToggle() {
        useTouchControls = !inputControlsToggle.isOn;
    }
    
    private void TurnOnCanvas(GameObject _canvas) => _canvas.active = true;
    private void TurnOffCanvas(GameObject _canvas) => _canvas.active = false;

    public void ToggleWinCanvas(int _grading)
    {
        if (CheckPopUps()) return;
        ToggleCanvasLogic();
        timeFinished.UpdateTimeTextOnFinish(timerManager.GetTimeInSeconds());
        TurnOnCanvas(winCanvas);
        scoresStarsAnimation.DoAnimationStars(_grading);
    }

    public void ToggleLoseCanvas() {
        if (CheckPopUps()) return;
        ToggleCanvasLogic();
        TurnOnCanvas(loseCanvas);
    }
    private void ToggleCanvasLogic() {
        isPopuped = true;
        timeTargetManager.UpdateTimeTargets();
    }
    public void TurnOnMenuCanvas()
    {
        isMenuOpened = true;
        TurnOnCanvas(menuCanvas);
    }

    public void TurnOffMenuCanvas()
    {
        isMenuOpened = false;
        TurnOffCanvas(menuCanvas);
    }
    private void ToggleLiftButtons()
    {
        isLiftButtonsActive = !isLiftButtonsActive;
        liftButtons.active = isLiftButtonsActive;
    }
    private bool CheckPopUps() {
        if (isMenuOpened) TurnOffMenuCanvas();
        if (isPopuped) return true;
        return false;
    }
    private void UpdateLiftButtons() {} //liftButtons.active = isLiftButtonsActive;
}
