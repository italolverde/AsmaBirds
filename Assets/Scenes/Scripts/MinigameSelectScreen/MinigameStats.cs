using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Minigame_", menuName="ScriptableObject/Minigame")]

public class MinigameStats : ScriptableObject
{
    public string gameName;
    public Sprite cover;
    public string score;

}
