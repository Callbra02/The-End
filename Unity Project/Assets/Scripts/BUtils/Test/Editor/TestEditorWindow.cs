using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

public class TestEditorWindow : EditorWindow
{
    public GameObject testObject;
    public Transform waypoint1;
    public Transform waypoint2;
    
    
    [MenuItem("Team Fingus/Test Editor Window")]
    public static void ShowExample()
    {
        TestEditorWindow wnd = GetWindow<TestEditorWindow>();
        wnd.titleContent = new GUIContent("Test Editor Window");
    }

    public void CreateGUI()
    {
        VisualElement root = rootVisualElement;
        
        Label label = new Label("Hello World!");
        root.Add(label);

        Button button = new Button();
        button.name = "button";
        button.text = "Button";
        root.Add(button);
        
        Toggle toggle = new Toggle();
        toggle.name = "toggle";
        toggle.label = "Toggle";
        root.Add(toggle);
        
        Slider slider = new Slider();
        slider.name = "lerpamount";
        slider.label = "Lerp Amount";
        root.Add(slider);
    }

}
