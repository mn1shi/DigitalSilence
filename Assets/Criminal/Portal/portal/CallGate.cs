using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallGate : MonoBehaviour
{
    public GameObject portalGate;
    public void CallPortalGate()
    {
        portalGate = GameObject.Find("PortalGate");
        Debug.Log("portalgate:" + portalGate.name);
        //portalGate.SetActive(true);
    }
}
