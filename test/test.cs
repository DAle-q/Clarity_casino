using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSets : MonoBehaviour
{
    public Toggle m_mission;
    public GameObject openFilePanel;
    public MissionFilesUI fileTool;

    public Toggle m_map;
    public Transform mapView;

    public Toggle m_preparation;
    public Transform beforeDepartureTable;

    public ChangePanelsActivity workSpace;
    public AboveSpectatorController aboveSpectatorController;


    private bool is_mission;
    private bool is_map;
    private bool is_preparation;

    void Awake()
    {
        is_mission = m_mission.isOn;
        is_map = m_map.isOn;
        is_preparation = m_preparation.isOn;
    }

    public void MenuSelect()
    {
        if (m_mission.isOn == true && m_mission.isOn != is_mission)
        {
            m_preparation.isOn = false;
            m_map.isOn = false;

            /*openFilePanel.SetActive(true);
            fileTool.GetMissionFilesList();
            aboveSpectatorController.SetSpectatorActive(false);*/

            is_mission = true;
            is_map = false;
            is_preparation = false;
            Debug.Log("is_mission=" + is_mission + ", is_map=" + is_map + ", is_preparation=" + is_preparation);
        }
        else if (m_map.isOn == true && m_map.isOn != is_map)
        {
            m_mission.isOn = false;
            m_preparation.isOn = false;

            workSpace.SetActivePanel(mapView);
            aboveSpectatorController.SetSpectatorActive(true);

            is_mission = false;
            is_map = true;
            is_preparation = false;
            Debug.Log("is_mission=" + is_mission + ", is_map=" + is_map + ", is_preparation=" + is_preparation);
        }
        else if (m_preparation.isOn == true && m_preparation.isOn != is_preparation)
        {
            m_mission.isOn = false;
            m_map.isOn = false;

            workSpace.SetActivePanel(beforeDepartureTable);
            aboveSpectatorController.SetSpectatorActive(false);
            is_mission = false;
            is_map = false;
            is_preparation = true;
            Debug.Log("is_mission=" + is_mission + ", is_map=" + is_map + ", is_preparation=" + is_preparation);
        }
    }
}