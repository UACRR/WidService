using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingLib
{
    public class TransLiterator
    {
        class Mapping
        {
            public int native;
            public List<string> translations = new List<string>();
        }

        private static Mapping[] mappings;

        private const int firstCode = 0x0400;
        private const int lastCode = 0x04FF;

        private const string mapString =
@"А,A
Б,B
В,V
Г,G
Д,D
Е,E
Ё,YO
Ж,ZH
З,Z
И,I,Y
І,I
Ї,YI
Й,Y,J
К,K,C
Л,L
М,M
Н,N
О,O
П,P
Р,R
С,S
Т,T
У,U
Ф,F
Х,H,KH
Ц,C
Ч,CH
Ш,SH
Щ,SHCH
Ъ,'
Ы,Y
Ь,',
Э,E
Є,IE
Ю,YU
Я,YA,JA
а,A
б,B
в,V
г,G
д,D
е,E
ё,YO
ж,ZH
з,Z
и,I,Y
і,I
ї,YI
й,Y,J
к,K,C
л,L
м,M
н,N
о,O
п,P
р,R
с,S
т,T
у,U
ф,F
х,H,KH
ц,C
ч,CH
ш,SH
щ,SHCH,SHC
ъ,'
ы,Y
ь,',
э,E
є,IE
ю,YU
я,YA,JA";

        private static void Init()
        {
            if (mappings != null)
                return;
            mappings = new Mapping[lastCode - firstCode + 1];
            for (int i = firstCode; i <= lastCode; i++)
            {
                Mapping mapping = new Mapping();
                mapping.native = i;
                mapping.translations.Add(char.ConvertFromUtf32(i));
                mappings[i - firstCode] = mapping;
            }

            string[] mapArray = mapString.Split('\n');
            foreach (var line in mapArray)
            {
                string[] fields = line.TrimEnd('\r').Split(',');
                Mapping mapping = mappings[fields[0][0] - firstCode];
                mapping.translations.Clear();
                for (int i = 1; i < fields.Length; i++)
                    mapping.translations.Add(fields[i]);
            }

        }

        private static string TransLitChar(int character, int variantIndex)
        {
            if (character < firstCode/* || character > lastCode*/)
                return char.ConvertFromUtf32(character);
            else if (character > lastCode)
                return "";
            else
                return mappings[character - firstCode].translations[variantIndex];
        }

        private static int CntOfVariants(int character)
        {
            if (character < firstCode || character > lastCode)
                return 1;
            return mappings[character - firstCode].translations.Count;
        }

        private static bool TailCanBeEmpty(string source, int sPos)
        {
            for (int i = sPos; i < source.Length; i++)
            {
                if (source[sPos] < firstCode || source[sPos] > lastCode)
                    return false;
                Mapping mapping = mappings[source[sPos] - firstCode];
                bool hasEmpty = false;
                foreach (var c in mapping.translations)
                {
                    if (string.IsNullOrEmpty(c))
                    {
                        hasEmpty = true;
                        break;

                    }
                }
                if (!hasEmpty)
                    return false;
            }
            return true;
        }

        private static bool FindMatch(string source, string target, int sPos, int tPos, int variantIndex)
        {
            string transl = TransLitChar(source[sPos], variantIndex);
            if (!string.IsNullOrEmpty(transl) && target.IndexOf(transl, tPos, StringComparison.OrdinalIgnoreCase) != tPos)
                return false;
            tPos += transl.Length;
            sPos++;
            if (sPos == source.Length)
                return true;
            if (tPos >= target.Length)
            {
                return TailCanBeEmpty(source, sPos);
            }
            for (variantIndex = 0; variantIndex < CntOfVariants(source[sPos]); variantIndex++)
            {
                if (FindMatch(source, target, sPos, tPos, variantIndex))
                    return true;
            }
            return false;
        }

        public static SqlInt32 Contains(string source, string target)
        {
            Init();
            if (source == null || target == null)
                return 0;
            int sPos = 0;
            int tPos = 0;
            int nextTPos = -1;
            int variantIndex;
            while (nextTPos < target.Length)
            {
                tPos = nextTPos;
                nextTPos = target.Length;
                for (variantIndex = 0; variantIndex < CntOfVariants(source[0]); variantIndex++)
                {
                    string transl = TransLitChar(source[0], variantIndex);
                    int newTPos = target.IndexOf(transl, tPos + 1);
                    if (newTPos == -1)
                        continue;
                    nextTPos = newTPos < nextTPos ? newTPos : nextTPos;
                    tPos = newTPos;
                    if (FindMatch(source, target, sPos, tPos, variantIndex))
                        return 1;
                }
            }
            return 0;
        }

        private static void AppendChar(string source, int sPos, VariantHolder vh)
        {
            if (sPos >= source.Length)
                return;
            char curChar = source[sPos];
            List<string> newVariants = new List<string>();
            for (int variantIndex = 0; variantIndex < CntOfVariants(curChar); variantIndex++)
            {
                string transl = TransLitChar(curChar, variantIndex);
                foreach (var variant in vh.variants)
                {
                    newVariants.Add(variant + transl);
                    if (newVariants.Count > 20)
                        break;
                }
            }
            vh.variants = newVariants;
            AppendChar(source, ++sPos, vh);
        }

        public static List<string> BuildVariants(string source)
        {
            Init();
            VariantHolder vh = new VariantHolder();
            if (source == null)
                return vh.variants;
            AppendChar(source, 0, vh);
            return vh.variants;
        }
    }

    public class VariantHolder
    {
        public List<string> variants = new List<string>() { "" };
    }
}
