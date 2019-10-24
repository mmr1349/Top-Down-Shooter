using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public abstract class Usable : Item
    {
        public Usable(string itemName, string description, int price, Sprite sprite) : base(itemName, description, price, sprite) {
            //Do nothing lol
        }

        public abstract void Use();
    }
}
