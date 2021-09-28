using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectController : MonoBehaviour {

    private BaseLevelObject _levelObject;

    public void SetLevelObject(BaseLevelObject levelObject)
    {
        _levelObject = levelObject;
        GetComponent<SpriteRenderer>().sprite = _levelObject.GetSprite();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
