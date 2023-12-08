using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using ToBeNamed.Inventories;
using TMPro;

/// <summary>
/// GUI item slot?
/// </summary>
/// 
public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject Slot;
    public InventoryItem InventoryItem;

    private bool IsHovering = false;

    private GameObject InfoPanel;

    private TextMeshProUGUI ItemNameText;
    private TextMeshProUGUI ItemDescriptionText;

    [SerializeField]
    private Image ItemIcon;

    [SerializeField]
    private TextMeshProUGUI ItemStackText;

    private void Start()
    {
        InfoPanel = GameManager.Instance.ItemInfoPanel;

        //TODO : Dangerous roads here
        ItemNameText = InfoPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        ItemDescriptionText = InfoPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        UpdateStack(0);
    }

    public void OnPointerEnter(PointerEventData Data)
    {
        InfoPanel.SetActive(true);

        Debug.Log(InventoryItem.Item);

        if (InventoryItem.Item != null)
        {
            ItemNameText.text = InventoryItem.Item.Name;
            ItemDescriptionText.text = InventoryItem.Item.Description;
        }
        else
        {
            ItemNameText.text = "?????";
            ItemDescriptionText.text = "This item does not exist in this universe!";
        }

        IsHovering = true;
    }

    private void Update()
    {
        if(IsHovering)
        {
            float xOffset = (InfoPanel.GetComponent<RectTransform>().rect.width / 2) + 20f;
            float yOffset = (InfoPanel.GetComponent<RectTransform>().rect.height / 2) + 20f;

            InfoPanel.transform.position = new Vector2(Input.mousePosition.x + xOffset, Input.mousePosition.y - yOffset);
        }
    }

    public void OnPointerExit(PointerEventData Data)
    {
        InfoPanel.SetActive(false);
        IsHovering = true;
    }

    public void SetIcon(Sprite itemIcon)
    {
        ItemIcon.sprite = itemIcon;
    }

    public void UpdateStack(int Stack)
    {
        if (Stack < 1)
        {
            ItemStackText.text = "";
        }
        else
        {
            ItemStackText.text = Stack.ToString();
        }
    }
}