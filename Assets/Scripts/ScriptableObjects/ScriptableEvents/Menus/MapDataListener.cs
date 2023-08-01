using Pinbattlers.Menus;
using ScriptableEvents;
using UnityEngine;

[AddComponentMenu(
        ScriptableEventConstants.MenuNameCustom + "/MapData Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderCustom + 0
    )]
public class MapDataListener : BaseScriptableEventListener<MapsData>
{
}
