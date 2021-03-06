﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LimEditorManager : MonoBehaviour
{
    public static LimEditorManager Instance { get; set; }
    public LimMediaPlayerManager MusicPlayerWindow;
    public LimInspectorManager InspectorWindow;
    public LimTunerWindowManager TunerWindow;
    public LimTimeLineManager TimeLineWindow;
    public LimCreatorManager CreatorWindow;
    public LimSpectrumManager SpectrumWindow;
    public LimPreferencesManager PreferencesWindow;
    public LimGizmoMotionManager GizmoMotionWindow;
    public LimCloudManager CloudManager;
    public LimTopMenuManager TopMenu;
    public LimStatusManager StatusManager;
    public LimSubmitManager SubmitManager;
    
    public void ResetEditorLayout()
    {
        MusicPlayerWindow.BaseWindow.WindowRectTransform.anchoredPosition = new Vector2(1420, -890);
        InspectorWindow.BaseWindow.WindowRectTransform.anchoredPosition = new Vector2(1420, -60);
        TunerWindow.BaseWindow.WindowRectTransform.anchoredPosition = new Vector2(0, -60);
        TimeLineWindow.BaseWindow.WindowRectTransform.anchoredPosition = new Vector2(0, -860);
        CreatorWindow.BaseWindow.WindowRectTransform.anchoredPosition = new Vector2(1000, -60);
        SpectrumWindow.BaseWindow.WindowRectTransform.anchoredPosition = new Vector2(0, -655);
        StatusManager.BaseWindow.WindowRectTransform.anchoredPosition = new Vector2(1000, -655);

        MusicPlayerWindow.BaseWindow.WindowRectTransform.sizeDelta = new Vector2(500, 190);
        InspectorWindow.BaseWindow.WindowRectTransform.sizeDelta = new Vector2(500, 800);
        TunerWindow.BaseWindow.WindowRectTransform.sizeDelta = new Vector2(1000, 562.5f);
        TimeLineWindow.BaseWindow.WindowRectTransform.sizeDelta = new Vector2(1000, 220);
        CreatorWindow.BaseWindow.WindowRectTransform.sizeDelta = new Vector2(420, 562.5f);
        SpectrumWindow.BaseWindow.WindowRectTransform.sizeDelta = new Vector2(420, 175);
        StatusManager.BaseWindow.WindowRectTransform.sizeDelta = new Vector2(420, 425);
    }
    public void RestoreEditorLayout()
    {
        if (!LimSystem.EditorLayout.IsLayoutValid()) return;
        MusicPlayerWindow.BaseWindow.WindowRectTransform.anchoredPosition = LimSystem.EditorLayout.MusicPlayerPos.ToVector2();
        InspectorWindow.BaseWindow.WindowRectTransform.anchoredPosition = LimSystem.EditorLayout.InspectorPos.ToVector2();
        TunerWindow.BaseWindow.WindowRectTransform.anchoredPosition = LimSystem.EditorLayout.TunerWindowPos.ToVector2();
        TimeLineWindow.BaseWindow.WindowRectTransform.anchoredPosition = LimSystem.EditorLayout.TimelinePos.ToVector2();
        CreatorWindow.BaseWindow.WindowRectTransform.anchoredPosition = LimSystem.EditorLayout.CreatorPos.ToVector2();
        SpectrumWindow.BaseWindow.WindowRectTransform.anchoredPosition = LimSystem.EditorLayout.SpectrumPos.ToVector2();
        MusicPlayerWindow.BaseWindow.WindowRectTransform.sizeDelta = LimSystem.EditorLayout.MusicPlayerSize.ToVector2();
        InspectorWindow.BaseWindow.WindowRectTransform.sizeDelta = LimSystem.EditorLayout.InspectorSize.ToVector2();
        TunerWindow.BaseWindow.WindowRectTransform.sizeDelta = LimSystem.EditorLayout.TunerWindowSize.ToVector2();
        TimeLineWindow.BaseWindow.WindowRectTransform.sizeDelta = LimSystem.EditorLayout.TimelineSize.ToVector2();
        CreatorWindow.BaseWindow.WindowRectTransform.sizeDelta = LimSystem.EditorLayout.CreatorSize.ToVector2();
        SpectrumWindow.BaseWindow.WindowRectTransform.sizeDelta = LimSystem.EditorLayout.SpectrumSize.ToVector2();
    }
    public void SaveEditorLayout()
    {
        LimSystem.EditorLayout.MusicPlayerPos = new Lanotalium.Editor.Vector2Save(MusicPlayerWindow.BaseWindow.WindowRectTransform.anchoredPosition);
        LimSystem.EditorLayout.InspectorPos = new Lanotalium.Editor.Vector2Save(InspectorWindow.BaseWindow.WindowRectTransform.anchoredPosition);
        LimSystem.EditorLayout.TunerWindowPos = new Lanotalium.Editor.Vector2Save(TunerWindow.BaseWindow.WindowRectTransform.anchoredPosition);
        LimSystem.EditorLayout.TimelinePos = new Lanotalium.Editor.Vector2Save(TimeLineWindow.BaseWindow.WindowRectTransform.anchoredPosition);
        LimSystem.EditorLayout.CreatorPos = new Lanotalium.Editor.Vector2Save(CreatorWindow.BaseWindow.WindowRectTransform.anchoredPosition);
        LimSystem.EditorLayout.SpectrumPos = new Lanotalium.Editor.Vector2Save(SpectrumWindow.BaseWindow.WindowRectTransform.anchoredPosition);
        LimSystem.EditorLayout.MusicPlayerSize = new Lanotalium.Editor.Vector2Save(MusicPlayerWindow.BaseWindow.WindowRectTransform.sizeDelta);
        LimSystem.EditorLayout.InspectorSize = new Lanotalium.Editor.Vector2Save(InspectorWindow.BaseWindow.WindowRectTransform.sizeDelta);
        LimSystem.EditorLayout.TunerWindowSize = new Lanotalium.Editor.Vector2Save(TunerWindow.BaseWindow.WindowRectTransform.sizeDelta);
        LimSystem.EditorLayout.TimelineSize = new Lanotalium.Editor.Vector2Save(TimeLineWindow.BaseWindow.WindowRectTransform.sizeDelta);
        LimSystem.EditorLayout.CreatorSize = new Lanotalium.Editor.Vector2Save(CreatorWindow.BaseWindow.WindowRectTransform.sizeDelta);
        LimSystem.EditorLayout.SpectrumSize = new Lanotalium.Editor.Vector2Save(SpectrumWindow.BaseWindow.WindowRectTransform.sizeDelta);
    }

    private void Start()
    {
        Instance = this;
        if (LimSystem.Preferences.HideWhatsNew) return;
    }
    public void SetTexts()
    {

    }
}
