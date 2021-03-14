using System;
using System.Diagnostics;
using TaleWorlds.MountAndBlade;
using HarmonyLib;

namespace LessRelationNotifications
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            try
            {
                new Harmony("BannerLord.Mod.LessRelationNotifications").PatchAll();
            }
            catch (Exception ex)
            {
                Debug.Print("Error patching:\n" + ex.Message + " \n\n" + ex.InnerException?.Message);
            }
        }
    }
}