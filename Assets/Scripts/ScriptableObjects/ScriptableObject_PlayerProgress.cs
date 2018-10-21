using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSave", menuName = "Player/SaveData", order = 1)]
public class ScriptableObject_PlayerProgress : ScriptableObject {
    public int LevelCompleted = 0;
}
