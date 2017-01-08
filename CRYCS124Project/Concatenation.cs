using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace lolcode_interpreter
{
    class Concatenation
    {

        public Concatenation() { }

        public String concatenate(int line_number, String value, String line, LinkedList<Variable> variableList)
        {
            int counter;
            Syntax lolcode = new Syntax();
            String identifier1 = lolcode.r[1].Match(line).Groups["identifier1"].Value;
            String identifier2 = lolcode.r[1].Match(line).Groups["identifier2"].Value;
            String tempString = "";

            // if first argument of SMOOSH is a string
            if (new Regex(Syntax.stringSyntax).Match(identifier1).Success)
            {
                tempString = new Regex(Syntax.stringSyntax).Match(identifier1).Groups["stringValue"].Value;
            }
            // if first argument of SMOOSH is int, float, or boolean
            else if (new Regex(value + ")").Match(identifier1).Success)
            {
                tempString = identifier1;
            }
            // if first argument of SMOOSH is a variable
            else
            {
                counter = 0;
                // traverse the linked list of variables to find the first argument in the SMOOSH operator
                foreach (Variable v in variableList)
                {
                    // if a match is found, print its value in the console
                    if (identifier1.Equals(v.getIdent()))
                    {
                        tempString = v.getvalue();
                        break;
                    }
                    counter++;
                }
                // if the end of linked list is reached yet none matched the variable name, then it isn't declared, hence produce an error
                if (counter >= variableList.Count)
                {
                    Program.main.console_output.AppendText("Error at line " + (line_number + 1) + ": Variable used as first operand is undeclared.\n");
                }
            }
            // do the same for the second argument of the SMOOSH operator
            if (new Regex(Syntax.stringSyntax).Match(identifier2).Success)
            {
                tempString = tempString + new Regex(Syntax.stringSyntax).Match(identifier2).Groups["stringValue"].Value;
            }
            else if (new Regex(value + ")").Match(identifier2).Success)
            {
                tempString = tempString + identifier2;
            }
            else
            {
                counter = 0;
                foreach (Variable v in variableList)
                {
                    if (identifier2.Equals(v.getIdent()))
                    {
                        tempString = tempString + v.getvalue();
                        break;
                    }
                    counter++;
                }
                if (counter >= variableList.Count)
                {
                    Program.main.console_output.AppendText("Error at line " + (line_number + 1) + ": Variable used as second operand is undeclared.\n");
                }
            }
            return tempString;
        }

        // SMOOSH
        public void add_to_tables(String line)
        {
            Syntax lolcode = new Syntax();
            if (lolcode.r[1].Match(line).Success)
            {
                Program.main.lexemes.Rows.Add(lolcode.r[1].Match(line).Groups["conkey"].Value, "CONCATENATION_KEYWORD");
                Program.main.lexemes.Rows.Add(lolcode.r[1].Match(line).Groups["identifier1"].Value, "FIRST_CONCATENATION_OPERAND");
                Program.main.lexemes.Rows.Add("AN", "OPERAND_SEPARATOR_KEYWORD");
                Program.main.lexemes.Rows.Add(lolcode.r[1].Match(line).Groups["identifier2"].Value, "SECOND_CONCATENATION_OPERAND");
                if (!lolcode.r[1].Match(line).Groups["smooshend"].Value.Equals(""))
                {
                    Program.main.lexemes.Rows.Add(lolcode.r[1].Match(line).Groups["smooshend"].Value, "CONCATENATION_CLOSING_KEYWORD");
                }
            }
        }

    }
}
