using UnityEngine;

public class MouseCursorToggle : MyMonoBehaviour
{
    [Header("Mouse Cursor Settings")]
    [SerializeField] private bool startWithCursorVisible = false;
    
    [Header("Camera Control")]
    [SerializeField] private MonoBehaviour[] cameraScriptsToDisable;
    
    private bool isCursorVisible;
    
    protected override void Start()
    {
        base.Start();
        isCursorVisible = startWithCursorVisible;
        SetCursorState(isCursorVisible);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursor();
        }
    }
    
    public void ToggleCursor()
    {
        isCursorVisible = !isCursorVisible;
        SetCursorState(isCursorVisible);
    }
    
    public void ShowCursor()
    {
        isCursorVisible = true;
        SetCursorState(true);
    }
    
    public void HideCursor()
    {
        isCursorVisible = false;
        SetCursorState(false);
    }
    
    private void SetCursorState(bool visible)
    {
        if (visible)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
            SetCameraScriptsEnabled(false);
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            
            SetCameraScriptsEnabled(true);
        }
    }
    
    private void SetCameraScriptsEnabled(bool enabled)
    {
        if (cameraScriptsToDisable != null)
        {
            foreach (var script in cameraScriptsToDisable)
            {
                if (script != null)
                {
                    script.enabled = enabled;
                }
            }
        }
    }
    
    public void OnToggleButtonClicked()
    {
        ToggleCursor();
    }
    
    void OnGUI()
    {
        if (Application.isPlaying)
        {
            GUI.color = isCursorVisible ? Color.green : Color.red;
            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.fontStyle = FontStyle.Bold;
            style.fontSize = 20; 
            style.normal.textColor = GUI.color;
            GUI.Label(new Rect(Screen.width - 60, 10, 100, 50), "ESC",style);
        }
    }
}