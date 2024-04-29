using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common
{
    public static GameManager instance;

    public enum Characters
    {
        Subaru,
        Hokuto,
        Makoto,
        Mao,
        End,
    }
    public enum Day
    {
        Year,
        Month,
        Day,
        End,
    }
    public enum Time
    {
        Hour,
        Minute,
        Second,
    }
    public enum MainUI
    {
        NewGame,
        Load,
        End,
    }
}
