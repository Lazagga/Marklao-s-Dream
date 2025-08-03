using UnityEngine;

[CreateAssetMenu(fileName = "CommandData", menuName = "Game/CommandData")]
public class CommandData : ScriptableObject
{
    public CommandType commandType;
    public CommandDifficulty difficulty;
    [TextArea] public string description;
}
