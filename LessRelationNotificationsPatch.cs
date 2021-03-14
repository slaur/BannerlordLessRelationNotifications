using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.Core;

namespace LessRelationNotifications
{
    [HarmonyPatch(typeof(ChangeRelationAction), "ApplyPlayerRelation")]
    internal class LessRelationNotificationsPatch
    {
        private static bool Prefix(
        Hero hero,
        int relation,
        bool affectRelatives,
        ref bool showQuickNotification)
        {
            if (relation == 1)
            {
                showQuickNotification = false;
                var message = "Relation increased with " + hero.Name;
                if (hero.CurrentSettlement != null)
                {
                    message += " in " + hero.CurrentSettlement.Name;
                }
                InformationManager.DisplayMessage(new InformationMessage(message));
            }
            
            return true;
        }
    }
}