using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace lolcode_interpreter
{
    class Syntax
    {
        public static String integer = @"\-?[0-9]+";
        public static String floatingPoint = @"\-?[0-9]+\.[0-9]+";
        public static String troof = "(WIN|FAIL)";
        public static String stringSyntaxWoName = @""".*""";
        public static String stringSyntax = @"""(?<stringValue>.*)""";
        public static String var = "[A-Za-z][A-Za-z0-9_]*";
        public static String type = "(?<tp>(TROOF|NUMBR|NUMBAR|YARN|NOOB))";
        public static String literals = "(" + stringSyntaxWoName + ")|(" + floatingPoint + ")|(" + integer + ")|(" + troof + ")";
        public static String identifier = literals + "|(" + var + ")";
        public static String visible_arg;
        public static String aop;
        public Regex[] r = new Regex[100];

        public Syntax()
        {
            // 0. HAI / KTHXBYE
            r[0] = new Regex(@"^\s*(?<delimeter>(HAI|KTHXBYE))\s*$");
            // 1. SMOOSH
            r[1] = new Regex(@"(?<conkey>SMOOSH)\s+(?<identifier1>" + identifier + @")\s+(?<bop>AN)?\s+(?<identifier2>" + identifier + @")(\s+(?<smooshend>MKAY))?");
            // 4. SUM OF ...(ARITHMETIC OPERATIONS)
            aop = @"(?<aop>(SUM\s+OF)|(DIFF\s+OF)|(QUOSHUNT\s+OF)|(MOD\s+OF)|(PRODUKT\s+OF)|(BIGGR\s+OF)|(SMALLR\s+OF))";
            Regex aopbasecase = new Regex(@"(" + aop + @"\s+(?<identifier1>" + identifier + @")\s+AN\s+(?<identifier2>" + identifier + "))");
            Regex aopbasecasewithaop = new Regex(@"(" + aop + @"\s+(?<identifier1>" + aopbasecase + "|" + identifier + @")\s+AN\s+(?<identifier2>" + aopbasecase + "|" + identifier + "))");
            r[4] = new Regex(@"(" + aop + @"\s+(?<identifier1>" + aopbasecasewithaop + "|" + identifier + @")\s+AN\s+(?<identifier2>" + aopbasecasewithaop + "|" + identifier + "))");
            r[4] = new Regex(@"(" + aop + @"\s+(?<identifier1>" + r[4] + "|" + identifier + @")\s+AN\s+(?<identifier2>" + r[4] + "|" + identifier + "))");
            //r[4] = new Regex(@"(" + aop + @"\s+(?<identifier1>" + aopbasecase + "|" + identifier + @")\s+(?<bop>AN)\s+(?<identifier2>" + aopbasecase + "|" + identifier + "))");
            //r[4] = new Regex(@"(" + aop + @"\s+(?<identifier1>(" + r[4] + "|" + aopbasecase + "|" + identifier + @"))\s+(?<bop>AN)\s+(?<identifier2>(" + r[4] + "|" + aopbasecase + "|" + identifier + ")))");
            // 2. I HAS A
            String extended_value = "(" + stringSyntaxWoName + ")|(" + floatingPoint + ")|(" + integer + ")|(" + troof + ")|(" + r[4] + ")|(" + var + ")";
            r[2] = new Regex(@"^\s*(?<vardec>I\s+HAS\s+A)\s+(?<variableName>" + var + @")(\s+(?<assop>ITZ)\s+(?<val>(" + r[1] + ")|" + extended_value + @"|(?<invalid>(.+))))?\s*$");
            // 3. R
            r[3] = new Regex(@"^\s*(?<variableName>" + var + @")\s+(?<assop>R)\s+(?<val>(" + r[1] + ")|" + extended_value + @")\s*$");
            // 11. BOTH SAEM / DIFFRINT
            r[11] = new Regex(@"(?<cop>(BOTH\s+SAEM)|(DIFFRINT))\s+(?<op1>" + extended_value + @")\s+(?<bop>AN)\s+(?<op2>" + extended_value + @")");
            // 5. VISIBLE
            visible_arg = "(?<val>(" + r[1] + ")|(" + r[11] + ")|" + extended_value + ")";
            r[5] = new Regex(@"^\s*(?<showop>VISIBLE)(?<args>(\s+" + visible_arg + @")+)(?<removenewline>\!)?\s*$");
            // 6. GIMMEH
            r[6] = new Regex(@"^\s*(?<input>GIMMEH)\s+(?<dest>" + var + @")\s*$");
            // 7. IS NOW A
            r[7] = new Regex(@"^\s*(?<variableName>" + var + @")\s+(?<tpcast>IS\s+NOW\s+A)\s+" + type + @"\s*$");
            // 8. BOTH OF / EITHER OF / WON OF
            r[8] = new Regex(@"(?<bop>(BOTH\s+OF)|(EITHER\s+OF)|(WON\s+OF))\s+(?<identifier1>("".*"")|([a-zA-Z][a-zA-Z0-9_]*)|([0-9]+(\.[0-9]+)?)|" + r[4] + @"|([0-9]+)|((WIN|FAIL)))\s+((?<bop2>AN)\s+)?(?<identifier2>("".*"")|([a-zA-Z][a-zA-Z0-9_]*)|([0-9]+(\.[0-9]+)?)|" + r[4] + @"|([0-9]+)|((WIN|FAIL)))");
            // 9. BLANK LINE
            r[9] = new Regex(@"^(\s*)$");
            // 10. OBTW
            r[10] = new Regex(@"^\s*OBTW(\s+(?<comment>.*))?");
            // 12. O RLY?
            r[12] = new Regex(@"^\s*(?<condstart>(O\s+RLY\?))\s*$");
            // 13. YA RLY
            r[13] = new Regex(@"^\s*(?<if>(YA\s+RLY))\s*$");
            // 14. NO WAI
            r[14] = new Regex(@"^\s*(?<else>(NO\sWAI))\s*$");
            // 16. OIC
            r[16] = new Regex(@"^\s*(OIC)\s*$");
            // 17. MEBBE
            r[17] = new Regex(@"^\s*(MEBBE)\s+(?<arg>(" + troof+ "|(" + r[11] + @")))\s*$");
            // 18. BTW
            r[18] = new Regex(@"BTW(\s+(?<comment>.*))?");
            // 19. WTF?
            r[19] = new Regex(@"^\s*WTF\?\s*$");
            // 20. OMG
            r[20] = new Regex(@"^\s*OMG\s+(?<lit>" + literals + @")\s*$");
            // 21. GTFO
            r[21] = new Regex(@"^\s*GTFO\s*$");
            // 22. OMGWTF
            r[22] = new Regex(@"^\s*OMGWTF\s*$");
            // 23. TLDR
            r[23] = new Regex(@"^\s*TLDR\s*$");
            // 24. literal or variable
            r[24] = new Regex(@"^\s*(?<litorvar>(" + identifier + @"))\s*$");
        }
    }
}
