using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class BodyPartSelection : MonoBehaviour
{
    [Header("Display Settings")]
    public bool skin = false;
    public bool muscular = false;
    public bool skeletal = false;
    public bool nervous = false;
    public bool circulatory = false;
    public bool lymphatic = false;
    public bool digestive = false;
    public bool respiratory = false;
    public bool urinary = false;
    //public bool hair = true;
    //public bool eyes = true;
    //public bool brain = false;

    [Header("Body part Connections")]
    public GameObject skinObject;
    public GameObject circulatoryObject;
    public GameObject digestiveObject;
    public GameObject lymphaticObject;
    public GameObject muscularObject;
    public GameObject nervousObject;
    public GameObject respiratoryObject;
    public GameObject urinaryObject;
    public GameObject skeletalObject;
    //public GameObject hairObject;
    //public GameObject eyesObject;
    //public GameObject brainObject;

    [Header("CameraRig Connections")] 
    public GameObject skinCameraRig;
    public GameObject musclesCameraRig;
    public GameObject skeletonCameraRig;
    public GameObject nervousCameraRig;
    public GameObject circulatoryCameraRig;
    public GameObject lymphaticCameraRig;
    public GameObject digestiveCameraRig;
    public GameObject respiratoryCameraRig;
    public GameObject urinaryCameraRig;



    // Update is called once per frame
    void Update()
    {
        skinObject.SetActive(skin);
        circulatoryObject.SetActive(circulatory);
        digestiveObject.SetActive(digestive);
        lymphaticObject.SetActive(lymphatic);
        muscularObject.SetActive(muscular);
        nervousObject.SetActive(nervous);
        respiratoryObject.SetActive(respiratory);
        urinaryObject.SetActive(urinary);
        skeletalObject.SetActive(skeletal);
        //hairObject.SetActive(hair);
        //eyesObject.SetActive(eyes);
        //brainObject.SetActive(brain);
        
        
        // For CameraRig Calibration
        skinCameraRig.SetActive(skin);
        musclesCameraRig.SetActive(muscular);
        skeletonCameraRig.SetActive(skeletal);
        nervousCameraRig.SetActive(nervous);
        circulatoryCameraRig.SetActive(circulatory);
        lymphaticCameraRig.SetActive(lymphatic);
        digestiveCameraRig.SetActive(digestive);
        respiratoryCameraRig.SetActive(respiratory);
        urinaryCameraRig.SetActive(urinary);
        
    }
}
