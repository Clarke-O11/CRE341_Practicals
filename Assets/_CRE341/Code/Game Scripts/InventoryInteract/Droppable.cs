using UnityEngine;
using UnityEngine.Events;

public class Droppable : MonoBehaviour
{
    [SerializeField] private UnityEvent onDrop = null;
    [SerializeField] private Transform npc;
    private RNG_Drop dropScript;

    public void Drop()
    {
        //gameObject.SetActive(true);

        onDrop.Invoke();
    }
}
