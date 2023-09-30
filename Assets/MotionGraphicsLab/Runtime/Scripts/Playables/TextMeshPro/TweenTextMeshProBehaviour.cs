using AnnulusGames.TweenPlayables;
using System;
using TMPro;

namespace Redmond.MotionGraphicsLab.TweenPlayablesEx
{
    [Serializable]
    public class TweenTextMeshProBehaviour : TweenAnimationBehaviour<TextMeshPro>
    {
        public ColorTweenParameter color;
        public FloatTweenParameter fontSize;
        public FloatTweenParameter characterSpacing;
        public FloatTweenParameter wordSpacing;
        public FloatTweenParameter lineSpacing;
        public FloatTweenParameter paragraphSpacing;
        public VertexGradientTweenParamterer colorGradient;
        public StringTweenParameter text;

        public override void OnTweenInitialize(TextMeshPro playerData)
        {
            color.SetInitialValue(playerData, playerData.color);
            fontSize.SetInitialValue(playerData, playerData.fontSize);
            wordSpacing.SetInitialValue(playerData, playerData.wordSpacing);
            lineSpacing.SetInitialValue(playerData, playerData.lineSpacing);
            characterSpacing.SetInitialValue(playerData, playerData.characterSpacing);
            paragraphSpacing.SetInitialValue(playerData, playerData.paragraphSpacing);
            colorGradient.SetInitialValue(playerData, playerData.colorGradient);
            text.SetInitialValue(playerData, playerData.text);
        }
    }

}