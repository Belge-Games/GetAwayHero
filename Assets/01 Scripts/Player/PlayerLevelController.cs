using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelController : MonoBehaviour
{
    [SerializeField] private PlayerStatusBar playerStatusBar;
    private int level = 1;
    private int experience = 0;

    private int GetLevelUpExperince(int level)
    {
        return level * level * 1000;
    }

    private void Start()
    {
        SetLevelState();
    }

    public void AddExperience(int experiencePoint)
    {
        experience += experiencePoint;
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        if(experience >= GetLevelUpExperince(this.level))
        {
            level++;
        }
        SetLevelState();
        Debug.Log("Level: "+ level + " - Exp: "+ experience);
    }

    private void SetLevelState()
    {
        if(playerStatusBar != null)
        {
            playerStatusBar.SetState(experience - GetLevelUpExperince(level-1), GetLevelUpExperince(level) - GetLevelUpExperince(level-1));
            playerStatusBar.SetText("Level: " + level);
        }
    }
}
