using Pinbattlers.Menus;
using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "MapDataScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameCustom + "/MapData Scriptable Event",
        order = ScriptableEventConstants.MenuOrderCustom + 3
    )]
    public class MapDataEvent : BaseScriptableEvent<MapsData>
    {
    }
}

