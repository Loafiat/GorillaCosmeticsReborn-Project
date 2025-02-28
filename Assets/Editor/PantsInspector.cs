using GorillaCosmeticsReborn;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PantsDescriptor))]
public class PantsInspector : Editor
{
    public bool DebugInfo = false;
    
    public override void OnInspectorGUI()
    {
        PantsDescriptor hTarget = (PantsDescriptor)this.target;
        
        GUILayout.Label("Author: ");
        hTarget.Author = GUILayout.TextField(hTarget.Author, EditorStyles.textField);
        GUILayout.Space(1);
        GUILayout.Label("Name: ");
        hTarget.Name = GUILayout.TextField(hTarget.Name, EditorStyles.textField);

        GUILayout.Space(10);
        DebugInfo = GUILayout.Toggle(DebugInfo, "Advanced");

        if (DebugInfo)
        {
            if (GUILayout.Button("Calculate Hat Offset"))
                CalculateHatOffset(hTarget);

            //if (GUILayout.Button("Generate Hat Sprite"))
            //    GenerateHatIcon(hTarget);
            
            if (GUILayout.Button("Go To Hat Offset"))
            {
                hTarget.transform.position = hTarget.positionOffset + SkeletonReference.GetBodyBone.position;
                hTarget.transform.rotation = Quaternion.Euler(hTarget.rotationOffset.eulerAngles + SkeletonReference.GetBodyBone.eulerAngles);
            }
        }
        
        GUILayout.Space(10);

        if (GUILayout.Button("Export Hat"))
        {
            CalculateHatOffset(hTarget);
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

    public void CalculateHatOffset(PantsDescriptor hTarget)
    {
        hTarget.positionOffset = hTarget.transform.position - SkeletonReference.GetBodyBone.position;
        hTarget.rotationOffset = Quaternion.Euler(hTarget.transform.eulerAngles - SkeletonReference.GetBodyBone.eulerAngles);
    }

    public void GenerateHatIcon(PantsDescriptor hTarget)
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
