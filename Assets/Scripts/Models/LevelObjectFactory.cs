using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelObjectFactory {

    public static PortalLevelObject CreatePortal(int x, int y, PortalType portalType)
    {
        var portalObject = new PortalLevelObject(x, y, portalType);
        return portalObject;
    }

    public static DeskLevelObject CreateDesk(int x, int y)
    {
        var portalObject = new DeskLevelObject(x, y);
        return portalObject;
    }

}
