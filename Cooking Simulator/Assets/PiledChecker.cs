using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiledChecker : MonoBehaviour {

    public GameObject belowOf;

    public List<GameObject> objectsOnTop;

    public bool bottomObject = false;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void FixedUpdate() {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.up, out hit,  0.1f)) {
            Debug.Log(gameObject.name + " is below of " + hit.transform.gameObject);
            belowOf = hit.transform.gameObject;
        } else {
            belowOf = null;
        }

        if (bottomObject) {
            objectsOnTop = GetObjectsPiledOnTop();
        }
    }

    public GameObject GetObjectOnTop() {
        return belowOf;
    }

    public List<GameObject> GetObjectsPiledOnTop() {
        List<GameObject> objectsPiledOnTop = new List<GameObject>();
        GameObject obj = belowOf;

        while (true) {
            if (obj == null) break;

            PiledChecker piledCheckerScript = obj.GetComponent<PiledChecker>();
            if (piledCheckerScript == null) break;

            if (objectsOnTop.Contains(obj)) break;

            objectsPiledOnTop.Add(obj);

            obj = piledCheckerScript.GetObjectOnTop();
        }

        return objectsPiledOnTop;
    }
}
