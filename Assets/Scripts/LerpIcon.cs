using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpIcon : MonoBehaviour {

    public Vector3 startPos;
    public Vector3 endPos;

    float currentLerpTime;
    float lerpTime = 1f;
    
    float moveDistance = 10f;
	
	public void Lerpuj() {
        startPos = transform.position;
        endPos = transform.position + transform.up * moveDistance;
        
        Debug.Log(currentLerpTime);

            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            float perc = currentLerpTime / lerpTime;
            transform.position = Vector3.Lerp(startPos, endPos, perc);
        Debug.Log(endPos);
        Debug.Log(Vector3.Lerp(startPos, endPos, perc));
	}
}
