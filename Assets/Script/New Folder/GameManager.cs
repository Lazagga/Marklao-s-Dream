using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isSuccess;

    [Header("Stage Settings")]
    public List<CommandData> easyCommands;
    public List<CommandData> mediumCommands;
    public List<CommandData> hardCommands;

    [Header("References")]
    public SignBoard signBoard;
    public Desk[] desks;
    public Door[] doors;

    private CommandData currentCommand;
    private int stageLevel = 1;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        GenerateNextCommand();
    }

    public void GenerateNextCommand()
    {
        stageLevel++;
        CommandDifficulty difficulty = GetDifficultyByStage(stageLevel);

        switch (difficulty)
        {
            case CommandDifficulty.Easy:
                currentCommand = easyCommands[Random.Range(0, easyCommands.Count)];
                break;
            case CommandDifficulty.Medium:
                currentCommand = mediumCommands[Random.Range(0, mediumCommands.Count)];
                break;
            case CommandDifficulty.Hard:
                currentCommand = hardCommands[Random.Range(0, hardCommands.Count)];
                break;
        }

        signBoard.UpdateSign(currentCommand.description);
        resetDesks();
        resetDoors();
        isSuccess = false;
    }

    public void resetDesks()
    {
        foreach(var desk in desks) desk.__init__();
    }

    public void resetDoors()
    {
        foreach(var door in doors) door.__init__();
    }

    private CommandDifficulty GetDifficultyByStage(int stage)
    {
        if (stage < 4) return CommandDifficulty.Easy;
        if (stage < 7) return CommandDifficulty.Medium;
        return CommandDifficulty.Hard;
    }

    public void CompleteCommand(CommandType type)
    {
        if (currentCommand != null && currentCommand.commandType == type)
        {
            isSuccess = true;
        }
    }

    public void LockOtherDoors(Door except)
    {
        foreach(var door in doors)
        {
            if(door != except) door.LockDoor();
        }
    }

    public void CloseDoor()
    {
        foreach (var door in doors)
        {
            if (door.isLock == false) door.doorBody.transform.Rotate(0, -90, 0);
        }    
    }

    public void CheckAllDesks()
    {
        if (currentCommand == null ||
            currentCommand.commandType != CommandType.PlaceDocumentsOnDesks)
            return;

        foreach (var desk in desks)
        {
            if (!desk.HasDocument)
                return;
        }

        CompleteCommand(CommandType.PlaceDocumentsOnDesks);

        foreach (var desk in desks)
        {
        }
    }
}
