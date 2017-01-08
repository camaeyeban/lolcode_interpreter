using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace lolcode_interpreter
{
    class ComparisonOperation
    {
        DataType t = new DataType();
        Variable temp, temp2;

        public ComparisonOperation() {}

        public String compare(int line_number, String line, LinkedList<Variable> variableList, Variable IT)
        {
            int counter = 0;
            Syntax lolcode = new Syntax();

            String op1 = lolcode.r[11].Match(line).Groups["op1"].Value;
            String op2 = lolcode.r[11].Match(line).Groups["op2"].Value;

            // first operand = IT
            if (op1.Equals("IT"))
            {
                temp = new Variable(IT.getIdent(), IT.gettype(), IT.getvalue());
            }
            // first operand = variable
            if (new Regex("^(" + Syntax.var + ")$").Match(op1).Success)
            {
                // traverse the linked list of declared variables to find the variable name of the first operand
                foreach (Variable v in variableList)
                {
                    // if the first operand's variable name is found
                    if (op1.Equals(v.getIdent()))
                    {
                        temp = new Variable(v.getIdent(), v.gettype(), v.getvalue());
                        break;
                    }
                    counter++;
                }
                if (counter >= variableList.Count)
                {
                    Program.main.console_output.AppendText("Error at line " + (line_number + 1) + ": Variable used as first operand is undeclared.\n");
                }
            }
            // first operand = string
            else if (new Regex("^(" + Syntax.stringSyntax + ")$").Match(op1).Success)
            {
                temp = new Variable("", "YARN", new Regex("^(" + Syntax.stringSyntax + ")$").Match(op1).Groups["stringValue"].Value);
            }
            // first operand = literal
            else
            {
                temp = new Variable("", t.get_type(line_number, op1, "", -1, -1, IT, variableList), op1);
            }

            // second operand = IT
            if (op2.Equals("IT"))
            {
                temp2 = new Variable(IT.getIdent(), IT.gettype(), IT.getvalue());
            }
            // second operand = variable
            if (new Regex("^(" + Syntax.var + ")$").Match(op2).Success)
            {
                counter = 0;
                // traverse the linked list of declared variables to find the variable name of the second operand
                foreach (Variable v in variableList)
                {
                    // if the second operand's variable name is found
                    if (op2.Equals(v.getIdent()))
                    {
                        temp2 = new Variable(v.getIdent(), v.gettype(), v.getvalue());
                        break;
                    }
                    counter++;
                }
                if (counter >= variableList.Count)
                {
                    Program.main.console_output.AppendText("Error at line " + (line_number + 1) + ": Variable used as second operand is undeclared.\n");
                }
            }
            // second operand = string
            else if (new Regex("^(" + Syntax.stringSyntax + ")$").Match(op2).Success)
            {
                temp2 = new Variable("", "YARN", new Regex(Syntax.stringSyntax).Match(op2).Groups["stringValue"].Value);
            }
            // second operand = literal
            else
            {
                temp2 = new Variable("", t.get_type(line_number, op2, "", -1, -1, IT, variableList), op2);
            }

            if (temp.gettype().Equals(temp2.gettype()) && temp.getvalue().Equals(temp2.getvalue()))
            {
                return "WIN";
            }
            else
            {
                return "FAIL";
            }
        }

        public int add_to_tables(int line_number, String[] lines)
        {
            Syntax lolcode = new Syntax();

            Program.main.lexemes.Rows.Add(lolcode.r[11].Match(lines[line_number]).Groups["cop"].Value, "COMPARISON_OPERATOR_KEYWORD");
            Program.main.lexemes.Rows.Add(lolcode.r[11].Match(lines[line_number]).Groups["op1"].Value, "FIRST_COMPARISON_OPERAND");
            Program.main.lexemes.Rows.Add("AN", "BOOLEAN_OPERATOR_KEYWORD");
            Program.main.lexemes.Rows.Add(lolcode.r[11].Match(lines[line_number]).Groups["op2"].Value, "SECOND_COMPARISON_OPERAND");
            
            // O RLY?
            if ((line_number+1 < lines.Length) && lolcode.r[12].Match(lines[line_number + 1]).Success)
            {
                line_number++;
                Program.main.lexemes.Rows.Add(lolcode.r[12].Match(lines[line_number]).Groups["condstart"].Value, "CONDITIONAL_STATEMENT_START_KEYWORD");

                // pass through whitespaces and comments until YA RLY is found
                while (lolcode.r[9].Match(lines[line_number]).Success || lolcode.r[18].Match(lines[line_number]).Success)
                {
                    if (lolcode.r[18].Match(lines[line_number]).Success)
                    {
                        Program.main.lexemes.Rows.Add(lolcode.r[18].Match(lines[line_number]).Groups["commentkey"].Value, "COMMENT_KEYWORD");
                        Program.main.lexemes.Rows.Add(lolcode.r[18].Match(lines[line_number]).Groups["comment"].Value, "COMMENT_VALUE");
                    }
                    line_number++;
                }

                // YA RLY
                if ((line_number+1 < lines.Length) && lolcode.r[13].Match(lines[line_number+1]).Success)
                {
                    Program.main.lexemes.Rows.Add("YA RLY", "TRUE_CONDITIONAL_STATEMENT_KEYWORD");
                    line_number++;
                }
                else
                {
                    Program.main.console_output.AppendText("Error at line " + (line_number + 1) + ": YA RLY statement not found.\n");
                }
            }
            return line_number;
        }

    }
}
