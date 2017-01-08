using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace lolcode_interpreter
{
    class ArithmeticOperation
    {

        int counter;

        public ArithmeticOperation() { }

        public float perform(int line_number, String line, LinkedList<Variable> variableList)
        {
            Syntax lolcode = new Syntax();
            DataType t = new DataType();
            String arithop = new Regex("^" + Syntax.aop).Match(line).Groups["aop"].Value;
            String ident2 = lolcode.r[4].Match(line).Groups["identifier2"].Value;
            float ITfloat = 0;
            float ITfloat2 = 0;



            
            
            int index = 0, pos = -1;
            for (int a = 0; a < lolcode.r[4].Match(line).Groups["identifier1"].Captures.Count; a++)
            {
                if (pos == -1 || lolcode.r[4].Match(line).Groups["identifier1"].Captures[a].Index < pos)
                {
                    pos = lolcode.r[4].Match(line).Groups["identifier1"].Captures[a].Index;
                    index = a;
                }
            }
            String ident1 = lolcode.r[4].Match(line).Groups["identifier1"].Captures[index].Value;
            
            // first operand = arithmetic operation
            if (lolcode.r[4].Match(ident1).Success)
            {
                ArithmeticOperation aop = new ArithmeticOperation();
                ITfloat = aop.perform(line_number, ident1, variableList);
            }
            // if the first operand is a literal
            else if (new Regex("^(" + Syntax.literals + ")$").Match(ident1).Success)
            {
                ITfloat = float.Parse(ident1);
            }
            // if the first operand is a variable
            else
            {
                counter = 0;
                // traverse the linked list of declared variables to find the first operand's variable name
                foreach (Variable v in variableList)
                {
                    // if a match was found, get its value and store it in ITfloat
                    if (ident1.Equals(v.getIdent()))
                    {
                        if (v.gettype() == "NOOB")
                        {
                            ITfloat = 0;
                        }
                        else if (v.gettype() == "YARN")
                        {
                            t.cast(line_number, "NUMBAR", v.getIdent(), variableList);
                            if (v.gettype() == "YARN")
                            {
                                return 0;
                            }
                        }
                        else
                        {
                            ITfloat = float.Parse(v.getvalue());
                        }
                        break;
                    }
                    counter++;
                }
                // if the end of linked list is reached yet none matched the variable name, then it isn't declared, hence produce an error
                if (counter >= variableList.Count)
                {
                    Program.main.console_output.AppendText("Error at line " + (line_number + 1) + ": Variable used as first operand is undeclared.\n");
                    ITfloat = 0;
                }
            }

            // second operand = arithmetic operation
            if (lolcode.r[4].Match(ident2).Success)
            {
                ArithmeticOperation aop = new ArithmeticOperation();
                ITfloat2 = aop.perform(line_number, ident2, variableList);
            }
            // if the second operand is a literal
            else if (new Regex("^(" + Syntax.literals + ")$").Match(ident2).Success)
            {
                //Program.main.console_output.AppendText("ident2:" + ident2 + "\n");
                ITfloat2 = float.Parse(ident2);
            }
            // if the second operand is variable name
            else
            {
                counter = 0;
                // traverse the linked list of declared variables to find the second operand's variable name
                foreach (Variable v in variableList)
                {
                    // if a match was found, get its value and store it in ITfloat2
                    if (ident2.Equals(v.getIdent()))
                    {
                        if (v.gettype() == "NOOB")
                        {
                            ITfloat2 = 0;
                        }
                        else if (v.gettype() == "YARN")
                        {
                            t.cast(line_number, "NUMBAR", v.getIdent(), variableList);
                            if (v.gettype() == "YARN")
                            {
                                return 0;
                            }
                        }
                        else
                        {
                            ITfloat2 = float.Parse(v.getvalue());
                        }
                        break;
                    }
                    counter++;
                }
                // if the end of linked list is reached yet none matched the variable name, then it isn't declared, hence produce an error
                if (counter >= variableList.Count)
                {
                    Program.main.console_output.AppendText("Error at line " + (line_number + 1) + ": Variable used as second operand is undeclared.\n");
                    ITfloat2 = 0;
                }
            }
            // after storing the value of first operand to ITfloat and the second operand to ITfloat2, process the operation
            if (new Regex(@"SUM\s+OF").Match(arithop).Success)
            {
                return ITfloat + ITfloat2;
            }
            else if (new Regex(@"DIFF\s+OF").Match(arithop).Success)
            {
                return ITfloat - ITfloat2;
            }
            else if (new Regex(@"PRODUKT\s+OF").Match(arithop).Success)
            {
                return ITfloat * ITfloat2;
            }
            else if (new Regex(@"QUOSHUNT\s+OF").Match(arithop).Success)
            {
                if (ITfloat2 != 0)
                {
                    return ITfloat / ITfloat2;
                }
                else {
                    Program.main.console_output.AppendText("Error at line " + (line_number + 1) + ": Math error due to division by 0.\n");
                    return 0;
                }
            }
            else if (new Regex(@"MOD\s+OF").Match(arithop).Success)
            {
                return ITfloat % ITfloat2;
            }
            else if (new Regex(@"BIGGR\s+OF").Match(arithop).Success)
            {
                if (ITfloat >= ITfloat2)
                {
                    return ITfloat;
                }
                else
                {
                    return ITfloat2;
                }
            }
            else if (new Regex(@"SMALLR\s+OF").Match(arithop).Success)
            {
                if (ITfloat <= ITfloat2)
                {
                    return ITfloat;
                }
                else
                {
                    return ITfloat2;
                }
            }
            else
            {
                return 0;
            }
        }

        // Arithmetic Operations (ex: SUM OF)
        /*public void add_to_tables(int line_number, String line)
        {
            Stack<String> op = new Stack<String>();
            Stack<String> ident1 = new Stack<String>();
            Stack<String> ident2 = new Stack<String>();
            add_to_lex(line_number, line, op, ident1, ident2);
        }
        */
        //public void add_to_lex(int line_number, String line, Stack<String> op, Stack<String> ident1, Stack<String> ident2)
        public void add_to_tables(int line_number, String line)
        {
            Syntax lolcode = new Syntax();
            
            String arithop = new Regex("^" + Syntax.aop).Match(line).Groups["aop"].Value;
            String identifier2 = lolcode.r[4].Match(line).Groups["identifier2"].Value;
            
            int index = 0, pos = -1;
            for (int a = 0; a < lolcode.r[4].Match(line).Groups["identifier1"].Captures.Count; a++)
            {
                if (pos == -1 || lolcode.r[4].Match(line).Groups["identifier1"].Captures[a].Index < pos)
                {
                    pos = lolcode.r[4].Match(line).Groups["identifier1"].Captures[a].Index;
                    index = a;
                }
            }
            String identifier1 = lolcode.r[4].Match(line).Groups["identifier1"].Captures[index].Value;
            
            Program.main.lexemes.Rows.Add(arithop, "ARITHMETIC_OPERATOR_KEYWORD");

            if (lolcode.r[4].Match(identifier1).Success)
            {
                ArithmeticOperation aop = new ArithmeticOperation();
                aop.add_to_tables(line_number, identifier1);
            }
            else
            {
                Program.main.lexemes.Rows.Add(identifier1, "FIRST_ARITHMETIC_OPERAND");
            }

            Program.main.lexemes.Rows.Add("AN", "OPERAND_SEPARATOR_KEYWORD");
            
            if (lolcode.r[4].Match(identifier2).Success)
            {
                ArithmeticOperation aop = new ArithmeticOperation();
                aop.add_to_tables(line_number, identifier2);
            }
            else
            {
                Program.main.lexemes.Rows.Add(identifier2, "SECOND_ARITHMETIC_OPERAND");
            }
            /*
            Regex r1 = new Regex(@"(?<aop>(SUM\s+OF)|(DIFF\s+OF)|(QUOSHUNT\s+OF)|(MOD\s+OF)|(PRODUKT\s+OF)|(BIGGR\s+OF)|(SMALLR\s+OF))\s+((?<identifier1>"".*""))?.*\s+(?<bop>AN)\s+((?<identifier2>"".*""))?");
            
            if (!r1.Match(line).Groups["identifier1"].Value.Equals(""))
            {
                Program.main.console_output.AppendText("Warning at line " + (line_number + 1) + ": First arithmetic operand " + identifier1 + " was interpreted as either Numbar or Numbr to perform operation.\n");
            }
            if (!r1.Match(line).Groups["identifier2"].Value.Equals(""))
            {
                Program.main.console_output.AppendText("Warning at line " + (line_number + 1) + ": Second arithmetic operand " + identifier2 + " was interpreted as either Numbar or Numbr to perform operation.\n");
            }
            */
        }

    }
}
