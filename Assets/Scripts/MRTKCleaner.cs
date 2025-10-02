using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MRTKCleaner : MonoBehaviour
{
    [ContextMenu("Clean MRTK Components")]
    void CleanMRTK()
    {
        // All GameObjects in the scene
        GameObject[] allObjects = FindObjectsOfType<GameObject>(true);

        int cleanedCount = 0;

        foreach (GameObject obj in allObjects)
        {
            // Skip MRTK system GameObjects just in case
            if (obj.name.Contains("MixedReality") || obj.name.Contains("MRTK"))
                continue;

            // Remove MRTK components by name
            var components = obj.GetComponents<Component>();
            foreach (var comp in components)
            {
                if (comp == null) continue;

                string typeName = comp.GetType().Name;

                if (
                    typeName.Contains("MRTK") ||
                    typeName.Contains("Pressable") ||
                    typeName.Contains("NearInteraction") ||
                    typeName.Contains("Interactable") ||
                    typeName.Contains("Solver") ||
                    typeName.Contains("BoundsControl") ||
                    typeName.Contains("Hand") ||
                    typeName.Contains("Pointer") ||
                    typeName.Contains("Manipulation") ||
                    typeName.Contains("MixedReality")
                )
                {
#if UNITY_EDITOR
                    Debug.Log($"Removing {typeName} from {obj.name}");
                    Undo.DestroyObjectImmediate(comp);
#else
                    DestroyImmediate(comp);
#endif
                    cleanedCount++;
                }
            }

            // Try adding Unity UI components if needed
            RectTransform rt = obj.GetComponent<RectTransform>();
            if (rt != null)
            {
                if (obj.GetComponent<CanvasRenderer>() == null)
                    obj.AddComponent<CanvasRenderer>();

                if (obj.GetComponent<Image>() == null)
                    obj.AddComponent<Image>();
            }
        }

        Debug.Log($"✅ MRTKCleaner: Removed {cleanedCount} MRTK-related components.");
    }
}
