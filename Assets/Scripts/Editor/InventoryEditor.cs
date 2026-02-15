using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using ToBeNamed.Items;

public class InventoryEditor : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    private Button AddPotion;
    private ObjectField ItemField;

    private Item Item;
    /*
    [MenuItem("Tools/InventoryEditor")]
    public static void ShowExample()
    {
        InventoryEditor wnd = GetWindow<InventoryEditor>();
        wnd.titleContent = new GUIContent("InventoryEditor");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        // Instantiate UXML
        VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
        root.Add(labelFromUXML);

        ItemField = rootVisualElement.Q<ObjectField>(name: "ItemField");

        AddPotion = rootVisualElement.Q<Button>(name:"AddPotionButton");

        ItemField.RegisterValueChangedCallback((evt) => 
        {
            Item = evt.newValue as Item;
        });

        AddPotion.clicked += AddItem;
    }

    private void AddItem()
    {
        if (!Application.isPlaying)
        {
            return;
        }

        GameObject Player = GameObject.Find("Player");

        Player.GetComponent<PlayerInventory>().AddItem(Item);
    }
    */
}