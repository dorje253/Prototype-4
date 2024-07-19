using UnityEngine;

// creating the dropdwon for categories of power
public enum PowerUpType { None, Pushback, Rockets, Smash}

public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;
}
