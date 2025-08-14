using UnityEngine;
using UnityEngine;
using UnityEditor;
using System.IO;
    
    public class ConvertRockMaterials : EditorWindow
    {
        string materialsFolder = "Assets/3D Gamekit - Environment Pack/Environment/Rocks/Materials";
        bool useURP = true; // Đặt false nếu bạn dùng Built-in Pipeline
    
        [MenuItem("Tools/Convert Rock Materials")]
        public static void ShowWindow()
        {
            GetWindow<ConvertRockMaterials>("Convert Rock Materials");
        }
    
        void OnGUI()
        {
            GUILayout.Label("OK ", EditorStyles.boldLabel);
    
            materialsFolder = EditorGUILayout.TextField("Materials Folder", materialsFolder);
            useURP = EditorGUILayout.Toggle(" URP", useURP);
    
            if (GUILayout.Button("OK All"))
            {
                ConvertAllMaterials();
            }
        }
    
        void ConvertAllMaterials()
        {
            string[] guids = AssetDatabase.FindAssets("t:Material", new[] { materialsFolder });
            int count = 0;
    
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);
    
                if (mat == null) continue;
    
                
                Texture albedo = mat.GetTexture("_MainTex") ?? mat.GetTexture("_BaseMap") ?? mat.GetTexture("_Albedo");
                Texture normal = mat.GetTexture("_BumpMap") ?? mat.GetTexture("_NormalMap");
                Texture occlusion = mat.GetTexture("_OcclusionMap");
                Texture metallic = mat.GetTexture("_MetallicGlossMap") ?? mat.GetTexture("_MetallicMap");
    
              
                if (useURP)
                    mat.shader = Shader.Find("Universal Render Pipeline/Lit");
                else
                    mat.shader = Shader.Find("Standard");
    
               
                if (albedo) mat.SetTexture("_BaseMap", albedo);
                if (normal) mat.SetTexture("_BumpMap", normal);
                if (occlusion) mat.SetTexture("_OcclusionMap", occlusion);
                if (metallic) mat.SetTexture("_MetallicGlossMap", metallic);
    
                EditorUtility.SetDirty(mat);
                count++;
            }
    
            AssetDatabase.SaveAssets();
            Debug.Log($"✅ OK {count} material.");
        }
    }

