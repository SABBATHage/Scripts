using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missions : MonoBehaviour
{
    [SerializeField] private Image firstMissionDoneIm;
    [SerializeField] private Image secondMissionDoneIm;
    [SerializeField] private GameObject completeMission;

    private int item2Count = 0;
    private int item3Count = 0;
    private int mission1requirement = 4;
    private int mission2requirement = 2;
    private bool mis1chek = false;
    private bool mis2chek = false;

    private void MissionChek()
    {
        Debug.Log("Item2= " + item2Count + " Item3= " + item3Count + " Mission1- " + mis1chek + " Mission2- " + mis2chek);
        if (mis1chek == true && mis2chek == true)
        {
            completeMission.SetActive(true);
        }
    }

    private void FirstObjectivChek()
    {
        if (item2Count >= mission1requirement)
        {
            mis1chek = true;
            firstMissionDoneIm.enabled = true;
        }
        else
        {
            mis1chek = false;
            firstMissionDoneIm.enabled = false;
        }

        MissionChek();
    }

    private void SecondObjectivChek()
    {
        if (item3Count >= mission2requirement)
        {
            mis2chek = true;
            secondMissionDoneIm.enabled = true;
        }
        else
        {
            mis2chek = false;
            secondMissionDoneIm.enabled = false;
        }

        MissionChek();
    }

    public void Item2CountChange(int change)
    {
        item2Count += change;

        if (item2Count < 0)
            item2Count = 0;

        if (item2Count > 15)
            item2Count = 15;

        FirstObjectivChek();
    }

    public void Item3CountChange(int change)
    {
        item3Count += change;

        if (item3Count < 0)
            item3Count = 0;

        if (item3Count > 15)
            item3Count = 15;

        SecondObjectivChek();
    }
}
