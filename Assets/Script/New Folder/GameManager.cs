using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isSuccess = false;
    public enum Step
    {
        Room = 0,
        Corridor = 1,
        Teleport = 2
    }

    public Step currentStep;

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
    }

    private void Start()
    {
        GenerateNextCommand();

        currentStep = Step.Room;
    }

    public void GenerateNextCommand()
    {
        if(isSuccess) stageLevel++;
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
        Debug.Log("Stage : " + stageLevel + "\ncommand : " + currentCommand.description);
        
        resetRoom(); // Reset Room

        isSuccess = false;
    }

    public void resetRoom()
    {
        resetDesks();
    }
    public void resetDesks()
    {
        foreach(var desk in desks) desk.__init__();
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

    public void OpenDoor(Door door)
    {
        door.GetComponent<Animator>().SetBool("IsOpened", true);
        Debug.Log("Door Opened!");
    }
    public void CloseDoor()
    {
        foreach (var door in doors)
        {
            door.gameObject.GetComponent<Animator>().SetBool("IsOpened", false);
        }
        Debug.Log("Door Closed!");
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
    }
}
