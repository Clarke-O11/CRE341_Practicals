using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening.Core.Easing;

public class ItemInteractUI : MonoBehaviour
{
    public GameObject fpsCamera;
    public GameObject targetObject;
    private RaycastHit hit;
    public TextMeshProUGUI displayText;

    //[SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    //[SerializeField] private Transform debugTransform;

    // Update is called once per frame
    void Update()
    {
        /*Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;

            if (hit.collider.gameObject == targetObject)
            {
                displayText.text = targetObject.name;
            }
            else
            {
                displayText.text = "";
            }
        } */
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit)) 
        {
            if (hit.collider.gameObject == targetObject)
            {
                displayText.text = targetObject.name;
            }
            else 
            {
                displayText.text = "";
            }
        }
        
    }
}
