using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToBeNamed.Items
{
    [CreateAssetMenu(fileName = "Item", menuName = "Items/Item", order = 1)]
    public class Item : ScriptableObject
    {
        public string Name;
        public string Description;
        public int MaxStack;
        public bool MultiStack;
        public Sprite IconSprite;
    }
}