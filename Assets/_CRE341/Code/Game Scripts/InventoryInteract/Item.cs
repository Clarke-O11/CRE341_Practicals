using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;
    public string itemName;
    public int quanitity;
    public Sprite icon;

    public Item(int id, string itemName, int quanitity, Sprite icon)
    {
        this.id = id;
        this.itemName = itemName;
        this.quanitity = quanitity;
        this.icon = icon;
    }

    public override string ToString()
    {
        return $"{quanitity}";
    }
}
