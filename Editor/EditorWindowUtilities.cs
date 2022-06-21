using System;
using UnityEditor;
using System.Text;

namespace HeartfieldEditor
{
    public static class EditorWindowUtilities
    {
        public static string AddSpacesToSentence(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            var newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);

            const char space = ' ';

            for (int i = 1; i < text.Length; i++)
            {
                if ((char.IsUpper(text[i]) && text[i - 1] != space) || (char.IsNumber(text[i]) && char.IsLetter(text[i - 1])))
                    newText.Append(space);

                newText.Append(text[i]);
            }

            return newText.ToString();
        }

        public static string AddSpacesToSentence(Enum text)
        {
            return AddSpacesToSentence(text.ToString());
        }
    }
}