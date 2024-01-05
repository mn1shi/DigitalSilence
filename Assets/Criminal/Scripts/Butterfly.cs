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
                    pos.z += 0.25f;
                    pos.y += 0.25f;
                    Instantiate(headC, pos, transform.rotation);
                    //Animator anim = hit.transform.GetComponent<Animator>();
                }

                if (hit.transform.tag == "headL")
                {
                    Destroy(hit.transform.gameObject);
                }

                if (hit.transform.tag == "headR")
                {
                    Destroy(hit.transform.gameObject);
                }

            }
        }
    }
}
