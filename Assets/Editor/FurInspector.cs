using GorillaCosmeticsReborn;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FurDescriptor))]
public class FurInspector : Editor
{
    public bool DebugInfo = false;
    
    public override void OnInspectorGUI()
    {
        FurDescriptor hTarget = (FurDescriptor)this.target;
        
        GUILayout.Label("Author: ");
        hTarget.Author = GUILayout.TextField(hTarget.Author, EditorStyles.textField);
        GUILayout.Space(1);
        GUILayout.Label("Name: ");
        hTarget.Name = GUILayout.TextField(hTarget.Name, EditorStyles.textField);
        GUILayout.Space(20);
        GUILayout.Label("Body Mat: ");
        hTarget.bodyMat = (Material)EditorGUILayout.ObjectField(hTarget.bodyMat, typeof(Material), false);
        GUILayout.Space(1);
        GUILayout.Label("Chest Mat: ");
        hTarget.chestMat = (Material)EditorGUILayout.ObjectField(hTarget.chestMat, typeof(Material), false);

        GUILayout.Space(10);

        if (GUILayout.Button("Export Hat"))
        {
            PrefabUtility.SaveAsPrefabAssetAndConnect(hTarget.gameObject, "Assets/Exports/" + hTarget.name + ".prefab", InteractionMode.AutomatedAction);
            AssetBundleBuild build = default(AssetBundleBuild);
            build.assetBundleName = hTarget.Name.Replace(" ", string.Empty).ToLower();
            build.assetNames = new[] { "Assets/Exports/" + hTarget.name + ".prefab" };
            BuildTarget activeBuildTarget = EditorUserBuildSettings.activeBuildTarget;
            BuildPipeline.BuildAssetBundles("Assets/Exports", new[] { build }, BuildAssetBundleOptions.None, activeBuildTarget);
            PrefabUtility.UnpackPrefabInstance(hTarget.gameObject, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            System.IO.File.Delete("Assets/Exports/" + hTarget.name + ".prefab");
            AssetDatabase.Refresh();
        }
    }

    public void GenerateHatIcon(FurDescriptor hTarget)
    {
        hTarget.CosmeticIcon = null;
        //if (hTarget.CosmeticIcon != null)
        //    DestroyImmediate(hTarget.CosmeticIcon);
        //Camera renderCamera = new GameObject().AddComponent<Camera>();
        //renderCamera.transform.SetParent(hTarget.transform, false);
        //renderCamera.transform.localPosition = new Vector3(1.6f, 1.6f, 2.5f);
        //renderCamera.transform.localRotation = Quaternion.Euler(24, -150, 0);
        //renderCamera.transform.rotation = Quaternion.Euler(renderCamera.transform.rotation.eulerAngles.x, renderCamera.transform.rotation.eulerAngles.y, 0);
        //RenderTexture renderTexture = new RenderTexture(512, 512, 0);
        //renderCamera.targetTexture = renderTexture;
        //renderCamera.Render();
        //RenderTexture savedRenderTexture = RenderTexture.active;
        //Texture2D newTexture = new Texture2D(renderTexture.width, renderTexture.height);
        //newTexture.ReadPixels(new Rect(0, 0, newTexture.width, newTexture.height), 0, 0);
        //RenderTexture.active = savedRenderTexture;
        //hTarget.CosmeticIcon = Sprite.Create(newTexture,new Rect(0, 0, newTexture.width, newTexture.height), new Vector2(0,0),1);
        //DestroyImmediate(renderCamera.gameObject);
    }
}
