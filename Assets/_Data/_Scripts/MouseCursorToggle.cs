using UnityEngine;

public class MouseCursorToggle : MonoBehaviour
{
    [Header("Mouse Cursor Settings")]
    [SerializeField] private bool startWithCursorVisible = false;
    
    private bool isCursorVisible;
    
    void Start()
    {
        // Thiết lập trạng thái ban đầu của cursor
        isCursorVisible = startWithCursorVisible;
        SetCursorState(isCursorVisible);
    }
    
    void Update()
    {
        // Kiểm tra input để toggle cursor bằng ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursor();
        }
    }
    
    /// <summary>
    /// Toggle trạng thái hiển thị của cursor
    /// </summary>
    public void ToggleCursor()
    {
        isCursorVisible = !isCursorVisible;
        SetCursorState(isCursorVisible);
    }
    
    /// <summary>
    /// Hiển thị cursor
    /// </summary>
    public void ShowCursor()
    {
        isCursorVisible = true;
        SetCursorState(true);
    }
    
    /// <summary>
    /// Ẩn cursor
    /// </summary>
    public void HideCursor()
    {
        isCursorVisible = false;
        SetCursorState(false);
    }
    
    /// <summary>
    /// Thiết lập trạng thái cursor
    /// </summary>
    /// <param name="visible">True để hiện cursor, false để ẩn</param>
    private void SetCursorState(bool visible)
    {
        if (visible)
        {
            // Hiển thị cursor và cho phép di chuyển tự do
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            // Ẩn cursor và khóa tại giữa màn hình
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    
    /// <summary>
    /// Có thể gọi từ UI Button
    /// </summary>
    public void OnToggleButtonClicked()
    {
        ToggleCursor();
    }
    
    // Hiển thị trạng thái trong Inspector (chỉ khi đang play)
    void OnGUI()
    {
        if (Application.isPlaying)
        {
            GUI.color = isCursorVisible ? Color.green : Color.red;
            GUI.Label(new Rect(10, 10, 200, 20), 
                $"Cursor: {(isCursorVisible ? "Visible" : "Hidden")}");
            GUI.Label(new Rect(10, 30, 200, 20), 
                "Press ESC to toggle");
        }
    }
}