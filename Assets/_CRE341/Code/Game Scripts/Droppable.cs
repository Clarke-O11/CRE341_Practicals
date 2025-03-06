using UnityEngine;
using UnityEngine.Events;

public class Droppable : MonoBehaviour
{
    [SerializeField] private UnityEvent onDrop = null;

    public void Drop() 
    { 
        gameObject.SetActive(true);

        onDrop?.Invoke();
        transform.parent = null;
    }
}
