using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace lolcode_interpreter
{
    class DataType
    {
        private string type;

        public DataType()
        {
            type = "NO MATCH";
        }

        // updates lexemes table and symbol table then returns the data type of the passed variable
        public String get_type(int line_number, String val, String ident, int lex, int sym, Variable IT, LinkedList<Variable> variableList)
        {
            int counter = 0;
            Syntax lolcode = new Syntax();
            Concatenation c = new Concatenation();
            Regex checker = new Regex("((" + Syntax.stringSyntax + ")|(?<floatValue>" + Syntax.floatingPoint + ")|(?<intValue>" + Syntax.integer + ")|(?<troof>" + Syntax.troof + ")|(?<var>" + Syntax.var + "))");
            if (val.Equals("IT"))
            {
                if (lex != -1)
                {
                    Program.main.lexemes.Rows.Add("IT", "PROGRAM_ACCUMULATOR");
                }
                if (sym != -1)
                {
                    variableList.AddFirst(new Variable(ident, IT.gettype(), IT.getvalue()));
                    Program.main.symbol_table.Rows.Add(ident, IT.gettype(), IT.getvalue());
                }
                type = "NUMBAR";
            }
            else if (!checker.Match(val).Groups["floatValue"].Value.Equals(""))
            {
                if (lex != -1)
                {
                    Program.main.lexemes.Rows.Add(val, "FLOATING_POINT_LITERAL_VALUE");
                }
                if (sym != -1)
                {
                    variableList.AddFirst(new Variable(ident, "NUMBAR", val));
                    Program.main.symbol_table.Rows.Add(ident, "NUMBAR", val);
                }
                type = "NUMBAR";
            }
            else if (!checker.Match(val).Groups["stringValue"].Value.Equals(""))
            {
                if (lex != -1)
                {
                    Program.main.lexemes.Rows.Add("\"", "STRING_LITERAL_INDICATOR");
                    Program.main.lexemes.Rows.Add(checker.Match(val).Groups["stringValue"].Value, "STRING_LITERAL_VALUE");
                    Program.main.lexemes.Rows.Add("\"", "STRING_LITERAL_INDICATOR");
                }
                if (sym != -1)
                {
                    variableList.AddFirst(new Variable(ident, "YARN", checker.Match(val).Groups["stringValue"].Value));
                    Program.main.symbol_table.Rows.Add(ident, "YARN", checker.Match(val).Groups["stringValue"].Value);
                }
                type = "YARN";
            }
            else if (!checker.Match(val).Groups["intValue"].Value.Equals(""))
            {
                if (lex != -1)
                {
                    Program.main.lexemes.Rows.Add(val, "INTEGER_LITERAL_VALUE");
                }
                if (sym != -1)
                {
                    variableList.AddFirst(new Variable(ident, "NUMBR", val));
                    Program.main.symbol_table.Rows.Add(ident, "NUMBR", val);
                }
                type = "NUMBR";
            }
            else if (!checker.Match(val).Groups["troof"].Value.Equals(""))
            {
                if (lex != -1)
                {
                    Program.main.lexemes.Rows.Add(val, "BOOLEAN_LITERAL_VALUE");
                }
                if (sym != -1)
                {
                    variableList.AddFirst(new Variable(ident, "TROOF", val));
                    Program.main.symbol_table.Rows.Add(ident, "TROOF", val);
                }
                type = "TROOF";
            }
            else if (lolcode.r[4].Match(val).Success)
            {
                ArithmeticOperation aop = new ArithmeticOperation();
                aop.add_to_tables(line_number, val);
                float arith_val = aop.perform(line_number, val, variableList);
                String tp = get_type(line_number, Convert.ToString(arith_val), ident, -1, -1, IT, variableList);
                variableList.AddFirst(new Variable(ident, tp, Convert.ToString(arith_val)));
                Program.main.symbol_table.Rows.Add(ident, tp, Convert.ToString(arith_val));
            }
            else if (lolcode.r[1].Match(val).Success)
            {
                c.add_to_tables(val);
                
                String value = "((" + Syntax.stringSyntax + ")|(?<floatValue>" + Syntax.floatingPoint + ")|(?<intValue>" + Syntax.integer + ")|(?<troof>" + Syntax.troof + ")";
                String concatenated_value = c.concatenate(line_number, value, val, variableList);
                variableList.AddFirst(new Variable(ident, "YARN", concatenated_value));
                Program.main.symbol_table.Rows.Add(ident, "YARN", concatenated_value);
            }
            else if (!checker.Match(val).Groups["var"].Value.Equals(""))
            {
                if (lex != -1)
                {
                    Program.main.lexemes.Rows.Add(val, "VARIABLE_IDENTIFIER");
                }
                foreach (Variable v in variableList)
                {
                    // if a match is found, print the value of the variable
                    if (val.Equals(v.getIdent()))
                    {
                        variableList.AddFirst(new Variable(ident, v.gettype(), v.getvalue()));
                        if (sym != -1)
                        {
                            Program.main.symbol_table.Rows.Add(ident, v.gettype(), v.getvalue());
                        }
                        type = v.gettype();
                        break;
                    }
                    counter++;
                }
                // if the end of the linked list is reached yet none matched, then the variable is undeclared, hence produce an error
                if (counter >= variableList.Count)
                {
                    //variableList.AddFirst(new Variable(ident, "NOOB", ""));
                    Program.main.console_output.AppendText("Error at line " + (line_number + 1) + ": Variable " + val + " is undeclared.\n");
                    /*
                    if (sym != -1)
                    {
                        Program.main.symbol_table.Rows.Add(ident, "NOOB", "");
                    }*/
                }
            }
            return type;
        }

        public void cast(int line_number, String newtype, String varname, LinkedList<Variable> variableList)
        {
            int counter = 0;
            Syntax lolcode = new Syntax();

            foreach (Variable v in variableList)
            {
                if (varname.Equals(v.getIdent()))
                {
                    // drop decimal if casted from float to int
                    if (v.gettype() == "NUMBAR" && newtype == "NUMBR")
                    {
                        v.setvalue(Math.Truncate(float.Parse(v.getvalue())).ToString());
                    }
                    else if (newtype == "TROOF")
                    {
                        if (v.gettype() == "YARN" && v.getvalue() == "")
                        {
                            v.setvalue("FAIL");
                        }
                        else if (v.gettype() == "YARN" && v.getvalue() != "")
                        {
                            v.setvalue("WIN");
                        }
                        else if ((v.gettype() == "NUMBAR" | v.gettype() == "NUMBR") && float.Parse(v.getvalue()) == 0)
                        {
                            v.setvalue("FAIL");
                        }
                        else
                        {
                            v.setvalue("WIN");
                        }
                    }
                    else if (newtype == "NOOB")
                    {
                        v.setvalue("");
                    }
                    else if (v.gettype() == "NOOB")
                    {
                        if (newtype == "NUMBR" | newtype == "NUMBAR")
                        {
                            v.setvalue("0");
                        }
                        else if (newtype == "TROOF")
                        {
                            v.setvalue("FAIL");
                        }
                    }
                    else if (v.gettype() == "TROOF")
                    {
                        if (newtype == "NUMBAR" | newtype == "NUMBR")
                        {
                            if (v.getvalue() == "WIN")
                            {
                                v.setvalue("1");
                            }
                            else
                            {
                                v.setvalue("0");
                            }
                        }
                        else
                        {
                            newtype = v.gettype();
                            Program.main.console_output.AppendText("Error at line " + (line_number + 1) + ": Unsafe casting of value.\n");
                            break;
                        }
                    }
                    else if (v.gettype() == "YARN" && (newtype == "NUMBAR" | newtype == "NUMBR"))
                    {
                        if (!new Regex("((" + Syntax.integer + ")|(" + Syntax.floatingPoint + "))").Match(v.getvalue()).Success)
                        {
                            newtype = v.gettype();
                            Program.main.console_output.AppendText("Error at line " + (line_number + 1) + ": Unsafe casting of value.\n");
                            break;
                        }
                    }
                    v.settype(newtype);
                    Program.main.symbol_table.Rows.Add(v.getIdent(), newtype, v.getvalue());

                    break;
                }
                counter++;
            }
            if (counter >= variableList.Count)
            {
                Program.main.console_output.AppendText("Error at line " + (line_number + 1) + ": Variable undeclared.\n");
            }
        }

    }
}
