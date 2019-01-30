using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseTop : MonoBehaviour
{
    // Grow parameters
    public float approachSpeed = 0.05f;
    public float growthBound = 2f;
    public float shrinkBound = 0.5f;
    private float currentRatio = 1;

    // The text object we're trying to manipulate
    private GameObject text;
    private float originalFontSize;

    // And something to do the manipulating
    private Coroutine routine;
    private bool keepGoing = true;
    private bool closeEnough = false;
    private float initialY;

    // Attach the coroutine
    void Awake()
    {
        // Find the text  element we want to use
        this.text = this.gameObject;
        initialY = this.gameObject.transform.position.y;

        // Then start the routine
        this.routine = StartCoroutine(this.Pulsing());
    }

    IEnumerator Pulsing()
    {
        // Run this indefinitely
        while (keepGoing)
        {
            // Get bigger for a few seconds
            while (this.currentRatio != this.growthBound)
            {
                // Determine the new ratio to use
                currentRatio = Mathf.MoveTowards(currentRatio, growthBound, approachSpeed);

                // Update our text element
                this.text.transform.position = new Vector3(this.text.transform.position.x, initialY + 50 * currentRatio, this.text.transform.position.z);

                yield return new WaitForEndOfFrame();
            }

            // Shrink for a few seconds
            while (this.currentRatio != this.shrinkBound)
            {
                // Determine the new ratio to use
                currentRatio = Mathf.MoveTowards(currentRatio, shrinkBound, approachSpeed);

                // Update our text element
                this.text.transform.position = new Vector3(this.text.transform.position.x, initialY + 50 * currentRatio, this.text.transform.position.z);

                yield return new WaitForEndOfFrame();
            }
        }
    }
}
