using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target = null;
    
    [SerializeField] private float followspeed = 0.3f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float offsetZ;

    [SerializeField] private bool TrackPlayer;
    [SerializeField] [Range(0.0f, 20.0f)] private float SmoothTracking;
    [Header("If target is not the same as visual focus: ")]
    public Transform Visiontarget = null;
    

    private Vector3 desiredForward;

    // Update is called once per frame
    private void Start()
    {
        if (Visiontarget == null)
        {
            Visiontarget = target;
        }
    }
    void FixedUpdate()
    {
        if(target != null) {
            Vector3 targetPosition = target.TransformPoint(new Vector3(offsetX, offsetY, offsetZ));

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, followspeed);

            if (TrackPlayer == true)
            {
                Vector3 desiredForward = Visiontarget.position - this.transform.position;
                desiredForward.Normalize();
                Quaternion desiredRotation = Quaternion.LookRotation(desiredForward);
                float smoothing = 5f;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, desiredRotation, smoothing * 10 * Time.deltaTime);

            }
            return;
        }
        Debug.Log("You didnt assign a target in CameraFollow, you dumdum!");

    }
}
