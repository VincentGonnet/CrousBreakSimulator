using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private ObjectManager objectManager;
    [SerializeField] private RectTransform handleRect;

    private void Awake()
    {
        if (instance == null)
        {
            instance = FindAnyObjectByType<UIManager>();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SendSliderWorldPointToObject() {

        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(null, handleRect.position);
        
        // Convert the screen point to a world position
        Vector3 worldPosition;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(handleRect, screenPoint, Camera.main, out worldPosition);
        
        // Now, worldPosition is the world point of the slider's handle
        Debug.Log("World Position: " + worldPosition);

        objectManager.UpdateCupPosition(worldPosition);
    }

    public Vector3 GetHandleWorldPosition() {
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(null, handleRect.position);
        
        // Convert the screen point to a world position
        Vector3 worldPosition;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(handleRect, screenPoint, Camera.main, out worldPosition);
        
        return worldPosition;
    }
}
