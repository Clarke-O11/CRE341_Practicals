using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInteractUI : MonoBehaviour
{
    public GameObject fpsCamera;
    public GameObject targetObject;
    private RaycastHit hit;
    public TextMeshProUGUI displayText;

    public GameObject crosshairFill;

    //[SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    //[SerializeField] private Transform debugTransform;
    //[SerializeField] private Transform lookDir;

    //PickUpItems pickUp;

    // Update is called once per frame
    void Update()
    {
       /* Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;

        }

        if (hit.collider.gameObject == targetObject)
        {
            displayText.text = targetObject.name;
            crosshairFill.SetActive(true);
            Vector3 aimDir = (mouseWorldPosition - lookDir.position).normalized;
            Debug.Log("Looking at" + targetObject);
        }
        else
        {
            displayText.text = "";
            crosshairFill.SetActive(false);
        }*/

        /*Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;*/

        if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit)) 
        {
            //Debug.DrawRay(fpsCamera.transform.position, fpsCamera.transform.forward * pickUp.pickUpRange, Color.red);
            //hitTransform = hit.transform;
            if (hit.collider.gameObject == targetObject)
            {
                displayText.text = targetObject.name;
                crosshairFill.SetActive(true);
                Debug.Log("Looking at" + targetObject);
            }
            else
            {
                displayText.text = "";
                crosshairFill.SetActive(false);
            }
        }


    }
}
