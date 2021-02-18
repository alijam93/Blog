using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Blog.Shared.Extensions
{
    public static class FriendlyUrlExtension
    {
        /// <summary>
        /// Converts title to valid URL slug
        /// </summary>
        /// <param name="title"></param>
        /// <param name="maxlength"></param>
        /// <returns></returns>
        //public static string GetSlugTitle(string title, int maxlength = 80)
        //{
        //    if (title == null)
        //    {
        //        return string.Empty;
        //    }

        //    int length = title.Length;
        //    bool prevdash = false;
        //    StringBuilder stringBuilder = new StringBuilder(length);
        //    char c;

        //    for (int i = 0; i < length; ++i)
        //    {
        //        c = title[i];
        //        if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
        //        {
        //            stringBuilder.Append(c);
        //            prevdash = false;
        //        }
        //        else if (c >= 'A' && c <= 'Z')
        //        {
        //            // tricky way to convert to lower-case
        //            stringBuilder.Append((char)(c | 32));
        //            prevdash = false;
        //        }
        //        else if ((c == ' ') || (c == ',') || (c == '.') || (c == '/') ||
        //          (c == '\\') || (c == '-') || (c == '_') || (c == '='))
        //        {
        //            if (!prevdash && (stringBuilder.Length > 0))
        //            {
        //                stringBuilder.Append('-');
        //                prevdash = true;
        //            }
        //        }
        //        else if (c >= 128)
        //        {
        //            int previousLength = stringBuilder.Length;

        //            if (previousLength != stringBuilder.Length)
        //            {
        //                prevdash = false;
        //            }
        //            else
        //            {
        //                stringBuilder.Append(c);
        //            }


        //        }

        //        if (i == maxlength)
        //        {
        //            break;
        //        }
        //    }

        //    if (prevdash)
        //    {
        //        return stringBuilder.ToString().Substring(0, stringBuilder.Length - 1);
        //    }
        //    else
        //    {
        //        return stringBuilder.ToString();
        //    }
        //}
        public static string GetSlugTitle(string title, bool remapToAscii = false, int maxlength = 80)
        {
            if (title == null)
            {
                return string.Empty;
            }

            int length = title.Length;
            bool prevdash = false;
            StringBuilder stringBuilder = new StringBuilder(length);
            char c;

            for (int i = 0; i < length; ++i)
            {
                c = title[i];
                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
                {
                    stringBuilder.Append(c);
                    prevdash = false;
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    // tricky way to convert to lower-case
                    stringBuilder.Append((char)(c | 32));
                    prevdash = false;
                }
                else if ((c == ' ') || (c == ',') || (c == '.') || (c == '/') ||
                  (c == '\\') || (c == '-') || (c == '_') || (c == '='))
                {
                    if (!prevdash && (stringBuilder.Length > 0))
                    {
                        stringBuilder.Append('-');
                        prevdash = true;
                    }
                }
                else if (c >= 128)
                {
                    int previousLength = stringBuilder.Length;

                    if (remapToAscii)
                    {
                        stringBuilder.Append(RemapInternationalCharToAscii(c));
                    }
                    else
                    {
                        stringBuilder.Append(c);
                    }

                    if (previousLength != stringBuilder.Length)
                    {
                        prevdash = false;
                    }
                }

                if (i == maxlength)
                {
                    break;
                }
            }

            if (prevdash)
            {
                return stringBuilder.ToString().Substring(0, stringBuilder.Length - 1);
            }
            else
            {
                return stringBuilder.ToString();
            }
        }

        /// <summary>
        /// Remaps the international character to their equivalent ASCII characters. See
        /// http://meta.stackexchange.com/questions/7435/non-us-ascii-characters-dropped-from-full-profile-url/7696#7696
        /// </summary>
        /// <param name="character">The character to remap to its ASCII equivalent.</param>
        /// <returns>The remapped character</returns>
        private static string RemapInternationalCharToAscii(char character)
        {
            string s = character.ToString().ToLowerInvariant();
            if ("àåáâäãåąā".Contains(s))
            {
                return "a";
            }
            else if ("èéêëę".Contains(s))
            {
                return "e";
            }
            else if ("ìíîïı".Contains(s))
            {
                return "i";
            }
            else if ("òóôõöøő".Contains(s))
            {
                return "o";
            }
            else if ("ùúûüŭů".Contains(s))
            {
                return "u";
            }
            else if ("çćčĉ".Contains(s))
            {
                return "c";
            }
            else if ("żźž".Contains(s))
            {
                return "z";
            }
            else if ("śşšŝ".Contains(s))
            {
                return "s";
            }
            else if ("ñń".Contains(s))
            {
                return "n";
            }
            else if ("ýÿ".Contains(s))
            {
                return "y";
            }
            else if ("ğĝ".Contains(s))
            {
                return "g";
            }
            else if (character == 'ř')
            {
                return "r";
            }
            else if (character == 'ł')
            {
                return "l";
            }
            else if ("đð".Contains(s))
            {
                return "d";
            }
            else if (character == 'ß')
            {
                return "ss";
            }
            else if (character == 'Þ')
            {
                return "th";
            }
            else if (character == 'ĥ')
            {
                return "h";
            }
            else if (character == 'ĵ')
            {
                return "j";
            }
            else
            {
                return string.Empty;
            }
        }

    //public static readonly char[] SignsArray = new char[] { 'آ', 'ا', 'ب', 'چ', 'د', 'ف', 'غ', 'ق', 'گ', 'ح', 'ه', 'ج', 'خ',
    //                                                            'ك', 'ک','ل','م','ن','پ','ر','س','ش','ت','ط', 'و','ی','ژ','ذ','ز','ض',
    //                                                             'ظ','ع'};

    //    public static readonly string[] RepArray = new string[] { "a", "a", "b", "ch", "d", "f", "gh", "gh", "g", "h", "j", "kh",
    //                                                              "k", "k", "l", "m", "m","p","r","s","sh","t","t","v","y","zh","z",
    //                                                              "z","z","z","`"};


    //    //Extension on String
    //    public static string MultiReplace(this string stringValue)
    //    {
    //        HashSet<char> set = new HashSet<char>(SignsArray);

    //        for (int i = 0; i < stringValue.Length; ++i)
    //        {
    //            var currentCharacter = stringValue[i];
    //            string valueToReplace;
    //            string replaceValue;
    //            if (set.Contains(currentCharacter))
    //            {
    //                valueToReplace = Char.ToString(stringValue[i]);
    //                replaceValue = RepArray[Array.IndexOf(SignsArray, currentCharacter)];
    //                stringValue = stringValue.Replace(Convert.ToString(currentCharacter), replaceValue);
    //            }
    //        }

    //        return stringValue;
    //    } 
    }
}
