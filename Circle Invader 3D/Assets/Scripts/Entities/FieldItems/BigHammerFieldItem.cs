﻿public class BigHammerFieldItem : FieldItem
{
    public override void OnPickup()
    {
        base.OnPickup();
        Gm.OverlayManager.Hud.UpdateBigHammerInterface();
    }

    public override void Destroy()
    {
        base.Destroy();
        Gm.OverlayManager.Hud.UpdateBigHammerInterface();
    }
}