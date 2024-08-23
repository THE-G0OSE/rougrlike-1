
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class cameraFollowing : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private player target;
    [Header("Camera settings")]
    [Tooltip("Time before camera will reach target position")]
    [SerializeField] private float followingTime;
    [Tooltip("Horizontal offset relative to the player")]
    [SerializeField] private float horizontalOrientationDelta;
    [SerializeField] private float verticalOffset;

    private Vector3 cameraPosition;
    private Vector3 targetPosition;
    private Vector3 distanceVector;
    private float currentHorizontalOrientationDelta;
    private void Update()
    {
//positions and player orientation detection

        cameraPosition = transform.position;
        targetPosition = new Vector3(target.transform.position.x + currentHorizontalOrientationDelta, target.transform.position.y + verticalOffset, -10);

//distance form camera to target

        distanceVector = new Vector3(-(cameraPosition.x - targetPosition.x), -(cameraPosition.y - targetPosition.y), 0);

//smooth camera moving

        transform.position = Vector3.Lerp(cameraPosition, targetPosition, distanceVector.magnitude / followingTime * Time.deltaTime);

        
        
    }
    public void SetHorizontalOrientation(player.playerHorizontalOrientation orientation)
    {
        switch (orientation)
        {
            case player.playerHorizontalOrientation.Left: currentHorizontalOrientationDelta = -horizontalOrientationDelta; break;
            case player.playerHorizontalOrientation.Right: currentHorizontalOrientationDelta = horizontalOrientationDelta; break;
        }
    }



}
