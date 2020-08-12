using System.Collections.Generic;
using UnityEngine;

public class CharacterThinker : MonoBehaviour
{
    public CharacterBrain brain;

    private Dictionary<string, object> memory;
    // [NonSerialized] public

    public T Remember<T>(string key)
    {
        object result;
        if (!memory.TryGetValue(key, out result))
            return default(T);
        return (T)result;
    }

    public void Remember<T>(string key, T value)
    {
        memory[key] = value;
    }

    private void Awake()
    {
        //enabled = false;
    }

    void OnEnable()
    {
        if (!brain)
        {
            enabled = false;
            return;
        }

        memory = new Dictionary<string, object>();
        brain.Initialize(this);
    }

    private void Update()
    {
        brain.Think(this);
    }

    /*
    public void Setup(GameState.PlayerState playerState, Transform spawnPoint)
    {
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;

        brain = playerState.PlayerInfo.Brain;
        SetColor(playerState.PlayerInfo.Color);

        player = playerState;
        playerState.Tank = this;

        enabled = true;
    }
    */
}
