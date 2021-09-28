using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneSpriteListController : MonoBehaviour {

    public static MainSceneSpriteListController Instance { get; private set; }

    public Sprite PortalInbound;
    public Sprite PortalOutbound;
    public Sprite Desk;
    public Sprite Clerk;
    public Sprite Customer;

    void Start()
    {
        Instance = this;
    }
}
