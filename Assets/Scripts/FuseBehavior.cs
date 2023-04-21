using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class FuseBehavior : MonoBehaviour
{
    public bool replaced = false;
    private bool movementFinished = false;
    private GameObject fuse;
    public XRSocketInteractor socket;
    private float randomNumber; 
    // Start is called before the first frame update
    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Fuses")
        {
            Random.InitState(System.DateTime.Now.Millisecond * this.gameObject.GetHashCode());
            StartCoroutine(wait());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (movementFinished && !replaced)
        {
            replaced = checkIfReplaced();
        }
    }

    IEnumerator wait()
    {
        randomNumber = Random.Range(5, 18);
        Debug.Log(randomNumber);
        yield return new WaitForSeconds(randomNumber);
        Debug.Log("Done waiting!");
        XRBaseInteractable obj = (XRBaseInteractable)socket.GetOldestInteractableSelected();

        if (obj != null)
        {
            //Move it
            Vector3 oldLocation = obj.transform.position;
            Vector3 newLocation = new Vector3(oldLocation.x, oldLocation.y, (float)(oldLocation.z - .2));
            yield return StartCoroutine(MoveSelectedInteractable(obj, newLocation, 30f));
        }
        movementFinished = true;
    }

    private IEnumerator MoveSelectedInteractable(XRBaseInteractable interactable, Vector3 newPosition, float lerpSpeed)
    {
        /* Code inspired from
         * https://forum.unity.com/threads/how-to-programmatically-remove-an-interactable-from-a-xrsocketinteractor.1119499/
         * Altered by Miller Taylor
         */


        // Store the interactable's interaction layer mask, in order to restore later on.
        var storeInteractionLayerMask = interactable.interactionLayers;

        // Make sure that the interactable gets unselected by the next update.
        interactable.interactionLayers = 0;
        socket.enabled = false;

        Vector3 currentPos = interactable.gameObject.transform.position;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * lerpSpeed;
            interactable.gameObject.transform.position = Vector3.Lerp(currentPos, newPosition, t);
            yield return null;
        }

        // Set the interactable to its new position
        interactable.gameObject.transform.position = newPosition;

        // Restore the interactable's interactionLayer mask and re-enable the socket interactor
        interactable.interactionLayers = storeInteractionLayerMask;
        socket.enabled = true;
        yield break;
    }

    private bool checkIfReplaced()
    {
        XRBaseInteractable obj = (XRBaseInteractable)socket.GetOldestInteractableSelected();
        if (obj != null)
        {
            return true;
        }
        return false;
    }

    public bool getReplaced()
    {
        return replaced;
    }

}
