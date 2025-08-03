using UnityEngine;

public enum CommandType
{
    EnterLeftDoor,             // 특정 문으로 들어가기
    EnterRightDoor,
    EnterFrontDoor,
    EnterBackDoor,
    ShredDocument,         // 문서를 파쇄
    CopyDocument,          // 문서를 복사
    PlaceDocumentsOnDesks, // 모든 책상에 문서를 올려놓기
    DieInShredder          // 파쇄기에 스스로 들어가기
}

public enum CommandDifficulty
{
    Easy,
    Medium,
    Hard
}
