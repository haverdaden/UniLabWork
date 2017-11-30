using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FullScrolling : MonoBehaviour {

    public float offside = 0;
    public float displacement = 0;
    public bool isLooping = false;
    private List<Transform> backgroundPart;
    /// Scrolling speed
    public Vector2 speed = new Vector2(2, 2);
    /// Moving direction
    public Vector2 direction = new Vector2(-1, 0);
    /// Movement should be applied to camera
    public bool isLinkedToCamera = false;

    void Start()
    {
        ListChildren();
    }

    public void ListChildren()
    {
        // For infinite background only
        if (isLooping)
        {
            // Get all the children of the layer with a renderer
            backgroundPart = new List<Transform>();
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                // Add only the visible children
                if (child.GetComponent<Renderer>() != null)
                {
                    backgroundPart.Add(child);
                }
            }
            // Sort by position. Get the children from left to right.
            backgroundPart = backgroundPart.OrderBy(t => t.position.x).ToList();
        }
    }

    void Update()
    {
        // Movement
        Vector3 movement = new Vector3(
            speed.x * direction.x,
            speed.y * direction.y,
            0);
        movement *= Time.deltaTime;
        transform.Translate(movement);
        // Move the camera
        if (isLinkedToCamera)
        {
            Camera.main.transform.Translate(movement);
        }





        // 4 - Loop
        if (isLooping)
        {
            // Get the first object.
            // The list is ordered from left (x position) to right.
            Transform firstChild = backgroundPart.FirstOrDefault();
            if (firstChild != null)
            {
                // Check if the child is already before the camera.
                if (firstChild.position.x < Camera.main.transform.position.
                        x - offside)
                {
                    // If the child is already on the left of the camera,
                    //if it's completely outside and needs to be recycled.
                    if (firstChild.GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
                    {

                        // Get the last child position.
                        Transform lastChild = backgroundPart.LastOrDefault();
                        Vector3 lastPosition = lastChild.transform.position;
                        Vector3 lastSize = (lastChild.GetComponent<UnityEngine.Renderer>()
                                                .bounds.max - lastChild.GetComponent<UnityEngine.Renderer>()
                                                .bounds.min);

                        // Set the position of the recyled one to be after the last child

                        firstChild.position = new Vector3(lastPosition.x +
                            displacement, firstChild.position.y, firstChild.position.z);
                        // Set the recycled child to the last position
                        // of the backgroundPart list.
                        backgroundPart.Remove(firstChild);
                        backgroundPart.Add(firstChild);
                    }
                }
            }
        }
    }


}
