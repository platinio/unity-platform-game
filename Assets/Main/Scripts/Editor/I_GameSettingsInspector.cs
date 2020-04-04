﻿using UnityEngine;
using UnityEditor;
using Gamaga.CharacterSystem;

namespace Gamaga.EditorCode
{
    [CustomEditor( (typeof(GameSettings)) )]
    public class I_GameSettingsInspector : Editor
    {
        private GameSettings settings = null;

        private void OnEnable()
        {
            settings = (GameSettings)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.LabelField("Player Settings", EditorStyles.boldLabel);
            DrawCharacterStats(settings.PlayerStats, "Player");
            EditorGUILayout.LabelField("Enemy Settings", EditorStyles.boldLabel);
            DrawCharacterStats(settings.EnemyStats , "Skeleton");            

        }

        private void DrawCharacterStats(CharacterStats stats , string name)
        {
            if (stats == null)
            {
                EditorGUILayout.HelpBox("You need to assign the "+ name + " ScritableObject", MessageType.Error);
                return;
            }

            stats.HP = EditorGUILayout.IntField("HP", stats.HP);
            stats.Speed = EditorGUILayout.FloatField("Speed", stats.Speed);
            stats.DMG = EditorGUILayout.IntField("Damage", stats.DMG);
            stats.JumpForce = EditorGUILayout.FloatField("Jump Force", stats.JumpForce);
            stats.MaxNumberOfJumps = EditorGUILayout.IntField("Max Number Of Jumps", stats.MaxNumberOfJumps);
        }

    }

}
