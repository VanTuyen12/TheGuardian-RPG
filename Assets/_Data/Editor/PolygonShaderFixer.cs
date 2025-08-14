using UnityEngine;
using UnityEditor;

public class PolygonShaderFixer : EditorWindow
{
    private Shader urpUnlit;
    private Color defaultGlowColor = Color.cyan;
    private float defaultEmissionIntensity = 2f;

    [MenuItem("Tools/Polygon Arsenal/Fix URP Shaders")]
    static void Init()
    {
        PolygonShaderFixer window = (PolygonShaderFixer)EditorWindow.GetWindow(typeof(PolygonShaderFixer));
        window.titleContent = new GUIContent("Polygon URP Shader Fixer");
        window.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("Chuyển Polygon Arsenal sang URP", EditorStyles.boldLabel);
        urpUnlit = Shader.Find("Universal Render Pipeline/Particles/Unlit");

        if (urpUnlit == null)
        {
            EditorGUILayout.HelpBox("Không tìm thấy shader URP/Particles/Unlit. Hãy đảm bảo URP đã được cài!", MessageType.Error);
            return;
        }

        defaultGlowColor = EditorGUILayout.ColorField("Màu Glow", defaultGlowColor);
        defaultEmissionIntensity = EditorGUILayout.FloatField("Độ sáng Glow", defaultEmissionIntensity);

        if (GUILayout.Button("Chuyển đổi ngay"))
        {
            ConvertAll();
        }
    }

    void ConvertAll()
    {
        string[] matGUIDs = AssetDatabase.FindAssets("t:Material");
        int converted = 0;

        foreach (string guid in matGUIDs)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);

            if (mat != null && mat.shader != null && 
                (mat.shader.name.Contains("PolygonArsenal-SolidGlowSoft") || mat.shader.name.Contains("PolygonArsenal-Solid")))
            {
                Undo.RecordObject(mat, "Convert Shader");
                mat.shader = urpUnlit;

                // Kích hoạt Glow
                mat.EnableKeyword("_EMISSION");
                mat.SetColor("_EmissionColor", defaultGlowColor * defaultEmissionIntensity);

                EditorUtility.SetDirty(mat);
                converted++;
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log($"✅ Đã chuyển {converted} materials sang URP/Particles/Unlit với Glow");
    }
}
