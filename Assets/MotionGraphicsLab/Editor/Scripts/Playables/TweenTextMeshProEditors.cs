using AnnulusGames.TweenPlayables.Editor;
using UnityEngine;
using UnityEditor;
using UnityEditor.Timeline;

namespace Redmond.MotionGraphicsLab.TweenPlayablesEx
{
    [CustomTimelineEditor(typeof(TweenTextMeshProTrack))]
    public class TweenTextMeshProUGUITrackEditor : TweenAnimationTrackEditor
    {
        public override Color trackColor => Styling.uguiColor;
        public override Texture2D trackIcon => Styling.textMeshProUGUIIcon;
        public override string defaultTrackName => "Tween TextMeshPro Track";
    }

    [CustomTimelineEditor(typeof(TweenTextMeshProClip))]
    public class TweenTextMeshProUGUIClipEditor : TweenAnimationClipEditor
    {
        public override string defaultClipName => "Tween TextMeshUGUI";
        public override Color clipColor => Styling.uguiColor;
        public override Texture2D clipIcon => Styling.textMeshProUGUIIcon;
    }

    [CustomPropertyDrawer(typeof(TweenTextMeshProBehaviour))]
    public class TweenTextMeshProUGUIBehaviourDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            position.y += 7f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("color"));
            position.y += 2f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("fontSize"));
            position.y += 2f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("characterSpacing"));
            position.y += 2f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("lineSpacing"));
            position.y += 2f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("wordSpacing"));
            position.y += 2f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("paragraphSpacing"));
            position.y += 2f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("colorGradient"));
            position.y += 2f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("text"));
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float height = 27f;
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("color"));
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("fontSize"));
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("characterSpacing"));
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("lineSpacing"));
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("wordSpacing"));
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("paragraphSpacing"));
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("colorGradient"));
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("text"));

            return height;
        }
    }
}