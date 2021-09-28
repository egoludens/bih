using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelActorController : MonoBehaviour {

    private BaseLevelActor _levelActor;

    public void SetLevelActor(BaseLevelActor levelActor)
    {
        _levelActor = levelActor;
        GetComponent<SpriteRenderer>().sprite = _levelActor.GetSprite();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
