using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelActorClerk : BaseLevelActor
{
    public LevelActorClerk(int x, int y) : base(x, y)
    {
    }

    public override Sprite GetSprite()
    {
        return MainSceneSpriteListController.Instance.Clerk;
    }
}
