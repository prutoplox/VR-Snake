using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MoveButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public void MoveTo() {
        transform.Translate(new Vector3(-0.5f,-0.5f,0));
    }

    public void MoveBack()
    {
        transform.Translate(new Vector3(0.5f, 0.5f, 0));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MoveTo();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MoveBack();
    }
}
