using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuScript : MonoBehaviour
{

    public GameObject settingsUIbackground;

    public void UISlide()
    {
        Vector3 transform = settingsUIbackground.transform.position;
        transform = new Vector3((Mathf.Lerp(transform.x, gameObject.transform.position.x, 1f)), transform.y, transform.z);
    }
}
