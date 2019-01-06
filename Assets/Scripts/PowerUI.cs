using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PowerUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform power;
    public GameObject crossHair;

    Camera cam;
    bool hovering = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovering = false;
    }

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (hovering && Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition).ToVector2();
            Vector2 diff = mousePosition - transform.position.ToVector2();

            if (diff.sqrMagnitude < 7.5f)
            {
                power.position = mousePosition;
                float rotation = Angle.AngleBetweenVector2(transform.position, crossHair.transform.position);

                Quaternion newRotation = new Quaternion
                {
                    eulerAngles = new Vector3(0f, 0f, rotation + 45f)
                };

                crossHair.transform.rotation = newRotation;
            }
        }
    }
}
