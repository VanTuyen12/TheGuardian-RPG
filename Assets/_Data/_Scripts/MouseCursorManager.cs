using System.Collections.Generic;
using UnityEngine;

public class MouseCursorManager : Singleton<MouseCursorManager>
{
    private bool startWithCursorVisible = false;
    
    [Header("Camera Control")]
    [SerializeField] private MonoBehaviour[] cameraScriptsToDisable;
    private HashSet<string> cursorRequests = new HashSet<string>();
    [SerializeField]private bool isCursorVisible;
    public bool IsCursorVisible => isCursorVisible;
    
    
    protected override void Start()
    {
        base.Start();
        if (startWithCursorVisible)
        {
            cursorRequests.Add("Initial");
        }
        UpdateCursorState();
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
        if (isCursorVisible)
        {
            cursorRequests.Clear();
        }
        else
        {
            cursorRequests.Add("Manual");
        }
        UpdateCursorState();
    }
    
    public void SetCursorVisible(bool visible, string requester = "Manual")
    {
        if (visible)
        {
            cursorRequests.Add(requester);
        }
        else
        {
            cursorRequests.Remove(requester);
        }
        
        UpdateCursorState();
    }
    
    private void UpdateCursorState()
    {
        bool shouldShowCursor = cursorRequests.Count > 0;
        if (isCursorVisible != shouldShowCursor)
        {
            isCursorVisible = shouldShowCursor;
            SetCursorState(shouldShowCursor);
        }
    }
    
    public void ShowCursor()
    {
        SetCursorVisible(true, "Direct");
    }
    
    public void HideCursor()
    {
        SetCursorVisible(false, "Direct");
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