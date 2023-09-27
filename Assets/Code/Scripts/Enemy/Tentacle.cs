using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour {

    [SerializeField] int lenght;
    [SerializeField] float targetDist;
    [SerializeField] float smoothSpeed;
    [SerializeField] float trailSpeed;

    private Vector3[] segmentV;
    [SerializeField] private Vector3[] segmentPoses;
    [SerializeField] private Transform targetDir;
    private LineRenderer lineRend;

    private void Start(){

        lineRend = GetComponent<LineRenderer>();

        lineRend.positionCount = lenght;
        segmentPoses = new Vector3[lenght];
        segmentV = new Vector3[lenght];
    }

    private void Update(){

        segmentPoses[0] = targetDir.position;

        for(int i = 1; i < segmentPoses.Length; i++){
            segmentPoses[i] = Vector3.SmoothDamp(
                segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed + i / trailSpeed);
        }

        lineRend.SetPositions(segmentPoses);
    }
}