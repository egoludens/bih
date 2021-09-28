using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskLevelObject : BaseLevelObject
{
    public List<DeskInstruction> Instructions { get; set; }

    public DeskLevelObject(int x, int y) : base(x, y)
    {
        Placement = ObjectPlacementEnum.Standing;
        Instructions = new List<DeskInstruction>();
    }

    public void AddInstruction(DeskInstruction deskInstruction)
    {
        Instructions.Add(deskInstruction);
    }

    public override Sprite GetSprite()
    {
        return MainSceneSpriteListController.Instance.Desk;
    }

}
