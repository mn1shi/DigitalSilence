using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{

    public GameObject headC;
    public GameObject headL;
    public GameObject headR;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed primary button.");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log("hit");
                Debug.Log(hit.transform.name + " : " + hit.transform.tag);

                if (hit.transform.tag == "headC")
                {
                    Vector3 pos = hit.point;
                    Destroy(hit.transform.gameObject);
                    //pos.z += 0.05f;
                    //pos.y += 0.05f;
                    Instantiate(headC, pos, transform.rotation);
                    //Animator anim = hit.transform.GetComponent<Animator>();
                }

                if (hit.transform.tag == "headL")
                {
                    Vector3 pos = hit.point;
                    Destroy(hit.transform.gameObject);
                    Instantiate(headL, pos, transform.rotation);
                    
                }

                if (hit.transform.tag == "headR")
                {
                    Vector3 pos = hit.point;
                    Destroy(hit.transform.gameObject);
                    Instantiate(headR, pos, transform.rotation);
                }

            }
        }
    }
}
