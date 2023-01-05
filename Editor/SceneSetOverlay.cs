using UnityEngine;
using UnityEditor.Toolbars;
using UnityEditor.Overlays;
using UnityEditor;
using UnityEditor.SceneManagement;

[EditorToolbarElement(id, typeof(SceneView))]
[Icon("Assets/[GAME]/Scripts/Editor/Icon/SceneControllerIcon.png")]
class SceneSelector : EditorToolbarDropdownToggle
{
    public const string id = "SceneLoaderOverlay/SceneSelector";

    static int colorIndex = 0;
    public SceneSelector()
    {
        text = "Select Scene";
        tooltip = "Select scene on editor";

        // When the dropdown is opened, ShowColorMenu is invoked and we can create a popup menu.

        dropdownClicked += ShowScenes;
        // Subscribe to the Scene view OnGUI callback so that we can draw our color swatch.

        SceneView.duringSceneGui += LoadSelectedScene;
    }
    int preColorIndex = -1;
    void LoadSelectedScene(SceneView view)
    {
        if (colorIndex == preColorIndex)
        {
            return;
        }
        preColorIndex = colorIndex;

        EditorSceneManager.OpenScene(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(colorIndex));
    }

    // When the dropdown button is clicked, this method will create a popup menu at the mouse cursor position.
    void ShowScenes()
    {

        var menu = new GenericMenu();
        // Add your scenes if you want to show in Overlay
        //Scene Index in build settings
        menu.AddItem(new GUIContent(System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(0))), colorIndex == 0, () => colorIndex = 0);
        menu.AddItem(new GUIContent(System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(1))), colorIndex == 1, () => colorIndex = 1);
        menu.AddItem(new GUIContent(System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(2))), colorIndex == 2, () => colorIndex = 2);
        menu.ShowAsContext();
    }
}


// All Overlays must be tagged with the OverlayAttribute

[Overlay(typeof(SceneView), "SceneLoader Overlay")]

// Toolbar Overlays must inherit `ToolbarOverlay` and implement a parameter-less constructor. The contents of a toolbar are populated with string IDs, which are passed to the base constructor. IDs are defined by EditorToolbarElementAttribute.
[Icon("Assets/[GAME]/Scripts/Editor/Icon/SceneControllerIcon.png")]
public class EditorToolbarExample : ToolbarOverlay
{

    // ToolbarOverlay implements a parameterless constructor, passing the EditorToolbarElementAttribute ID.
    // This is the only code required to implement a toolbar Overlay. Unlike panel Overlays, the contents are defined
    // as standalone pieces that will be collected to form a strip of elements.

    EditorToolbarExample() : base(
        SceneSelector.id
        )
    { }
}
