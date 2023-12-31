using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class MultipleImageTracking : MonoBehaviour
{
    private ARTrackedImageManager trackedImages;
    public GameObject[] ArPrefabs;

    List<GameObject> ARObjects = new List<GameObject>();


    void Awake()
    {
        trackedImages = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        trackedImages.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        trackedImages.trackedImagesChanged -= OnTrackedImagesChanged;
    }


    // Event Handler
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        //Create object based on image tracked
        foreach (var trackedImage in eventArgs.added)
        {
            Debug.Log("trackedImage.referenceImage.name: " + trackedImage.referenceImage.name);
            foreach (var arPrefab in ArPrefabs)
            {
                //Debug.Log("trackedImage.referenceImage.name: " + trackedImage.referenceImage.name);
                if (trackedImage.referenceImage.name == arPrefab.name)
                {
                    var newPrefab = Instantiate(arPrefab, trackedImage.transform);
                    Debug.Log("new prefab: " + newPrefab.name);
                    ARObjects.Add(newPrefab);

                    if (trackedImage.referenceImage.name == "tracker1")
                    {
                        Transform go = ARObjects[0].transform.Find("butterfly");
                        //Debug.Log("transform: " + go.name);

                    }

                    if (trackedImage.referenceImage.name == "tracker2")
                    {
                        //ARObjects[0].
                    }

                    if (trackedImage.referenceImage.name == "tracker3")
                    {

                    }
                }


            }
        }

        //Update tracking position
        foreach (var trackedImage in eventArgs.updated)
        {
            foreach (var gameObject in ARObjects)
            {
                if (gameObject.name == trackedImage.name)
                {
                    gameObject.SetActive(trackedImage.trackingState == TrackingState.Tracking);
                    //Debug.Log("gameobject: " + gameObject.name);
                }
            }
        }

    }
}
