using UnityEngine;
using System.Collections;
using RootMotion.FinalIK;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;
using UnityEngine.iOS;
using UnityEngine.InputSystem.XR;

namespace RootMotion.Demos
{
    [ExecuteAlways]
    public class VRIKCalibrationController : MonoBehaviour
    {

        [Tooltip("Reference to the VRIK component on the avatar.")] public VRIK ik;
        [Tooltip("The settings for VRIK calibration.")] public VRIKCalibrator.Settings settings;
        [Tooltip("The HMD.")] public Transform headTracker;
        [Tooltip("(Optional) A tracker placed anywhere on the body of the player, preferrably close to the pelvis, on the belt area.")] public Transform bodyTracker;
        [Tooltip("(Optional) A tracker or hand controller device placed anywhere on or in the player's left hand.")] public Transform leftHandTracker;
        [Tooltip("(Optional) A tracker or hand controller device placed anywhere on or in the player's right hand.")] public Transform rightHandTracker;
        [Tooltip("(Optional) A tracker placed anywhere on the ankle or toes of the player's left leg.")] public Transform leftFootTracker;
        [Tooltip("(Optional) A tracker placed anywhere on the ankle or toes of the player's right leg.")] public Transform rightFootTracker;

        [Header("Data stored by Calibration")]
        public VRIKCalibrator.CalibrationData data = new VRIKCalibrator.CalibrationData();

        //UnityEngine.XR.Interaction.Toolkit.XRController controller;

        /*void Start()
        {
            UnityEngine.Debug.Log("inside Start function");
            controller = GetComponent<UnityEngine.XR.Interaction.Toolkit.XRController>();

            if (controller == null)
            {
                controller = gameObject.AddComponent<UnityEngine.XR.Interaction.Toolkit.XRController>();
            }

            
        }*/

        void LateUpdate()
        {
            //bool value = false;

            if (Input.GetKeyDown(KeyCode.C))
            {
                // Calibrate the character, store data of the calibration
                data = VRIKCalibrator.Calibrate(ik, settings, headTracker, bodyTracker, leftHandTracker, rightHandTracker, leftFootTracker, rightFootTracker);

            }

            /*
            if (controller == null)
            {
                //UnityEngine.Debug.Log("controller is null");
                return;
            }
            else
            {
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out value))
                {
                    UnityEngine.Debug.Log("inside the IF statement 1");
                    if (value)
                    {
                        UnityEngine.Debug.Log("inside the IF statement 2");
                    }
                }
            }
            */



            /*
            void Update()
            {
                UnityEngine.Debug.Log("inside Update function");
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool value))
                {
                    UnityEngine.Debug.Log("inside the IF statement 1");
                    if (value)
                    {
                        UnityEngine.Debug.Log("inside the IF statement 2");
                    }
                }
            }*/

            /*
             * calling Calibrate with settings will return a VRIKCalibrator.CalibrationData, which can be used to calibrate that same character again exactly the same in another scene (just pass data instead of settings), 
             * without being dependent on the pose of the player at calibration time.
             * Calibration data still depends on bone orientations though, so the data is valid only for the character that it was calibrated to or characters with identical bone structures.
             * If you wish to use more than one character, it would be best to calibrate them all at once and store the CalibrationData for each one.
             * */
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (data.scale == 0f)
                {
                    Debug.LogError("No Calibration Data to calibrate to, please calibrate with settings first.");
                }
                else
                {
                    // Use data from a previous calibration to calibrate that same character again.
                    VRIKCalibrator.Calibrate(ik, data, headTracker, bodyTracker, leftHandTracker, rightHandTracker, leftFootTracker, rightFootTracker);
                }
            }

            // Recalibrates avatar scale only. Can be called only if the avatar has been calibrated already.
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (data.scale == 0f)
                {
                    Debug.LogError("Avatar needs to be calibrated before RecalibrateScale is called.");
                }
                VRIKCalibrator.RecalibrateScale(ik, data, settings);
            }
        }
    }
}
