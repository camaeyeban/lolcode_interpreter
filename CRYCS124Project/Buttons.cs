using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace lolcode_interpreter
{
    public partial class Buttons : UserControl
    {

        // Allocate Console
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();

        public Buttons()
        {
            InitializeComponent();
        }

        // Clear button = clear Code panel
        private void clear_Click(object sender, EventArgs e)
        {
            Program.main.code.Clear();
        }
        
        // Reset button = clear Code panel, Lexemes Table, Symbol Table, and Console Output
        private void reset_Click(object sender, EventArgs e)
        {
            Program.main.code.Clear();
            Program.main.console_output.Clear();
            Program.main.lexemes.Rows.Clear();
            Program.main.symbol_table.Rows.Clear();
            //Console.Clear();
        }

        // Analyze button = interpret code, list errors in the Console Output, display Console (black window)
        private void analyze_Click(object sender, EventArgs e)
        {
            DataType t = new DataType();
            Syntax lolcode = new Syntax();
            Concatenation c = new Concatenation();
            ArithmeticOperation aop = new ArithmeticOperation();
            ComparisonOperation cop = new ComparisonOperation();
            LinkedList<Variable> variableList = new LinkedList<Variable>();     // linked list for declared variables
            LinkedList<Variable> IT = new LinkedList<Variable>();

            IT.AddFirst(new Variable("IT", "NOOB", ""));

            String value = "((" + Syntax.stringSyntax + ")|(?<floatValue>" + Syntax.floatingPoint + ")|(?<intValue>" + Syntax.integer + ")|(?<troof>" + Syntax.troof + ")";
            String[] lines = Program.main.code.Text.Split(new Char[] { '\n' }, StringSplitOptions.None);
            String retType = "";

            float ITfloat;
            int counter = 0;
            int i = 0;                              // current line number
            int start = -1;                         // line number of HAI keyword
            int end = -1;                           // line number of KTHXBYE keyword
            int matched = -1;                       // 1 = line matched a regex; -1 = otherwise
            int cstart = -1;                        // conditional statement line number
            int cmatched = -1;                      // 1 = one of the conditions in if-else/case statements was already executed; -1 = otherwise
            int performCond = 1;                    // 1 = line inside if-else or case statements; -1 = otherwise
            int casestart = -1;                     // case statement line number

            Program.main.lexemes.Rows.Clear();
            Program.main.symbol_table.Rows.Clear();
            Program.main.console_output.Text = "";

            AllocConsole();                             // Opens a console with the given dimensions
            Console.SetWindowSize(90, 50);
            Console.Clear();

            for (i = 0, matched = 0; i < lines.Count(); counter = 0, ITfloat = 0, retType = "", i++, matched = 0)
            {

        // HAI and KTHXBYE
                if (lolcode.r[0].Match(lines[i]).Success)
                {
                    matched = 1;
                    // if HAI is found for the first time
                    if (start == -1 && lolcode.r[0].Match(lines[i]).Groups["delimeter"].Value.Equals("HAI"))
                    {
                        Program.main.lexemes.Rows.Add("HAI", "PROGRAM_DELIMITER");
                        start = i;
                    }
                    // if KTHXBYE is found for the first time
                    else if (end == -1 && lolcode.r[0].Match(lines[i]).Groups["delimeter"].Value.Equals("KTHXBYE"))
                    {
                        Program.main.lexemes.Rows.Add("KTHXBYE", "PROGRAM_DELIMITER");
                        end = i;
                    }
                    // if HAI is found again, produce an error
                    else if (start != -1 && lolcode.r[0].Match(lines[i]).Groups["delimeter"].Value.Equals("HAI"))
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": HAI already found at line " + (start + 1) + ".\n");
                    }
                    // if KTHXBYE is found again, produce an error
                    else
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": KTHXBYE already found at line " + (end + 1) + ".\n");
                    }
                }

        // I HAS A <VARIABLENAME> ?(ITZ <VALUE>)
                else if (lolcode.r[2].Match(lines[i]).Success)
                {
                    matched = 1;
                    String varname = lolcode.r[2].Match(lines[i]).Groups["variableName"].Value;
                    Program.main.lexemes.Rows.Add("I HAS A", "VARIABLE_DECLARATION_KEYWORD");
                    Program.main.lexemes.Rows.Add(varname, "VARIABLE_IDENTIFIER");

                    // value = invalid
                    if (!lolcode.r[2].Match(lines[i]).Groups["invalid"].Value.Equals(""))
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Value assigned to " + varname + " is invalid.\n");
                        continue;
                    }

                    // value = int / float / boolean / string / variable / arithmetic operation
                    else if (!lolcode.r[2].Match(lines[i]).Groups["assop"].Value.Equals(""))
                    {
                        Program.main.lexemes.Rows.Add("ITZ", "ASSIGNMENT_OPERATOR");
                        if (performCond == 1)
                        {
                            retType = t.get_type(i, lolcode.r[2].Match(lines[i]).Groups["val"].Value, varname, 1, 1, IT.First(), variableList);
                        }
                        else
                        {
                            retType = t.get_type(i, lolcode.r[2].Match(lines[i]).Groups["val"].Value, varname, 1, -1, IT.First(), variableList);
                        }
                    }

                    // no value assigned
                    else
                    {
                        if (performCond == 1)
                        {
                            Program.main.symbol_table.Rows.Add(varname, "NOOB", "");
                            variableList.AddFirst(new Variable(varname, "NOOB", ""));
                        }
                        continue;
                    }

                    // if code is before HAI keyword or after KTHXBYE keyword
                    if (start == -1 || end != -1)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Code not within program bounds.\n");
                    }
                }

        // <VARIABLENAME> R <VALUE>
                else if (lolcode.r[3].Match(lines[i]).Success)
                {
                    matched = 1;
                    String varname = lolcode.r[3].Match(lines[i]).Groups["variableName"].Value;
                    if (!lolcode.r[3].Match(lines[i]).Groups["invalid"].Value.Equals(""))
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Value assigned to " + varname + " is invalid.\n");
                        continue;
                    }
                    Program.main.lexemes.Rows.Add(varname, "VARIABLE_IDENTIFIER");
                    Program.main.lexemes.Rows.Add("R", "ASSIGNMENT_OPERATOR_KEYWORD");

                    foreach (Variable v in variableList)
                    {
                        // if a match is found, print the value of the variable
                        if (varname.Equals(v.getIdent()))
                        {
                            // value = arithmetic operation
                            if (lolcode.r[4].Match(lolcode.r[3].Match(lines[i]).Groups["val"].Value).Success)
                            {
                                aop.add_to_tables(i, lolcode.r[3].Match(lines[i]).Groups["val"].Value);
                                ITfloat = aop.perform(i, lolcode.r[3].Match(lines[i]).Groups["val"].Value, variableList);
                                if (performCond == 1)
                                {
                                    retType = t.get_type(i, Convert.ToString(ITfloat), varname, -1, 1, IT.First(), variableList);
                                }
                                else
                                {
                                    retType = t.get_type(i, Convert.ToString(ITfloat), varname, -1, -1, IT.First(), variableList);
                                }
                            }
                            else
                            {
                                if (performCond == 1)
                                {
                                    retType = t.get_type(i, lolcode.r[3].Match(lines[i]).Groups["val"].Value, varname, 1, 1, IT.First(), variableList);
                                }
                                else
                                {
                                    retType = t.get_type(i, lolcode.r[3].Match(lines[i]).Groups["val"].Value, varname, 1, -1, IT.First(), variableList);
                                }
                            }
                            break;
                        }
                        counter++;
                    }
                    // if the end of the linked list is reached yet none matched, then the variable is undeclared, hence produce an error
                    if (counter >= variableList.Count)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Variable undeclared.\n");
                    }
                    // if code is before HAI keyword or after KTHXBYE keyword
                    if (start == -1 || end != -1)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Code not within program bounds.\n");
                    }
                }

        // VISIBLE
                else if (lolcode.r[5].Match(lines[i]).Success)
                {
                    matched = 1;
                    Program.main.lexemes.Rows.Add("VISIBLE", "OUTPUT_OPERATOR_KEYWORD");

                    String temp = lolcode.r[5].Match(lines[i]).Groups["args"].Value;
                    String[] args = Regex.Matches(temp, Syntax.visible_arg).Cast<Match>().Select(m => m.Value).ToArray();

                    foreach (string arg in args)
                    {
                        if (arg.Equals("IT"))
                        {
                            if (IT.Count != 0)
                            {
                                if (performCond == 1)
                                {
                                    Console.Write(IT.First().getvalue());
                                }
                                Program.main.lexemes.Rows.Add("IT", "PROGRAM_ACCUMUlATOR");
                            }
                            else
                            {
                                Program.main.console_output.AppendText("Error at line " + (i + 1) + ": IT is null.\n");
                            }
                        }

                        // if VISIBLE's argument is an arithmetic operation (ex: SUM OF), perform the operation the print the result
                        else if (!lolcode.r[5].Match(lines[i]).Groups["aop"].Value.Equals(""))
                        {
                            aop.add_to_tables(i, lines[i]);
                            if (performCond == 1)
                            {
                                Console.Write(aop.perform(i, lines[i], variableList));
                            }
                        }

                        // if VISIBLE's argument is SMOOSH
                        else if (lolcode.r[1].Match(arg).Success)
                        {
                            c.add_to_tables(lines[i]);

                            if (performCond == 1)
                            {
                                Console.Write(c.concatenate(i, value, lines[i], variableList));
                            }
                        }

                        // VISIBLE's argument is a comparison statement(BOTH SAEM||DIFFRINT)
                        else if (lolcode.r[11].Match(arg).Success)
                        {
                            cop.add_to_tables(i, lines);
                            if (performCond == 1)
                            {
                                Console.Write(cop.compare(i, lines[i], variableList, IT.First()));
                            }
                        }

                        // if the VISIBLE's argument is a string
                        else if (new Regex(Syntax.stringSyntax).Match(arg).Success)
                        {
                            t.get_type(i, arg, "", 1, -1, IT.First(), variableList);
                            if (performCond == 1)
                            {
                                Console.Write(new Regex(Syntax.stringSyntax).Match(arg).Groups["stringValue"].Value);
                            }
                        }
                        // if the VISIBLE's argument is an int, float, or boolean
                        else if (new Regex("^" + value + ")$").Match(arg).Success)
                        {
                            if (performCond == 1 && !t.get_type(i, arg, "", 1, -1, IT.First(), variableList).Equals("NO MATCH"))
                            {
                                Console.Write(arg);
                            }
                        }
                        else
                        {
                            // if the VISIBLE's argument is a variable
                            if (new Regex(Syntax.var).Match(arg).Success)
                            {
                                Program.main.lexemes.Rows.Add(arg, "VARIABLE_IDENTIFIER");
                                // traverse each element of the variable linked list to find VISIBLE's argument
                                foreach (Variable v in variableList)
                                {
                                    // if a match is found, print the value of the variable
                                    if (arg.Equals(v.getIdent()))
                                    {
                                        if (performCond == 1)
                                        {
                                            Console.Write(v.getvalue());
                                        }
                                        break;
                                    }
                                    counter++;
                                }
                                // if the end of the linked list is reached yet none matched, then the variable is undeclared, hence produce an error
                                if (counter >= variableList.Count)
                                {
                                    Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Variable undeclared.\n");
                                }
                            }
                            // if none of the above syntax' matched the VISIBLE's argument, produce an error
                            else
                            {
                                Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Invalid VISIBLE argument.\n");
                            }
                        }
                    }
                    if (lolcode.r[5].Match(lines[i]).Groups["removenewline"].Value.Equals(""))
                    {
                        Console.Write("\n");
                    }
                    // if code is before HAI keyword or after KTHXBYE keyword
                    if (start == -1 || end != -1)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Code not within program bounds.\n");
                    }
                }

        // GIMMEH
                else if (lolcode.r[6].Match(lines[i]).Success)
                {
                    matched = 1;
                    String varname = lolcode.r[6].Match(lines[i]).Groups["dest"].Value;

                    Program.main.lexemes.Rows.Add("GIMMEH", "INPUT_GETTER_KEYWORD");
                    Program.main.lexemes.Rows.Add(varname, "DESTINATION_STORAGE_VARIABLE");

                    if (performCond == 1)
                    {
                        String temp = Console.ReadLine();

                        counter = 0;
                        foreach (Variable v in variableList)
                        {
                            if (v.getIdent().Equals(varname))
                            {
                                retType = t.get_type(i, temp, varname, -1, 1, IT.First(), variableList);
                                break;
                            }
                            counter++;
                        }
                        if (counter >= variableList.Count)
                        {
                            Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Variable undeclared.\n");
                            continue;
                        }
                    }
                    // if code is before HAI keyword or after KTHXBYE keyword
                    if (start == -1 || end != -1)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Code not within program bounds.\n");
                    }
                }

        // IS NOW A
                else if (lolcode.r[7].Match(lines[i]).Success)
                {
                    matched = 1;

                    String newtype = lolcode.r[7].Match(lines[i]).Groups["tp"].Value;
                    String varname = lolcode.r[7].Match(lines[i]).Groups["variableName"].Value;

                    Program.main.lexemes.Rows.Add(varname, "VARIABLE_IDENTIFIER");
                    Program.main.lexemes.Rows.Add("IS NOW A", "TYPE_CASTING_KEYWORD");
                    Program.main.lexemes.Rows.Add(newtype, "DATA_TYPE");

                    if (performCond == 1)
                    {
                        t.cast(i, newtype, varname, variableList);
                    }
                    // if code is before HAI keyword or after KTHXBYE keyword
                    if (start == -1 || end != -1)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Code not within program bounds.\n");
                    }
                }

        // WHITESPACE
                else if (lolcode.r[9].Match(lines[i]).Success)
                {
                    matched = 1;
                }

        // MEBBE
                else if (lolcode.r[17].Match(lines[i]).Success)
                {
                    matched = 1;
                    
                    Program.main.lexemes.Rows.Add("MEBBE", "IN_BETWEEN_CONDITIONAL_STATEMENT_KEYWORD");

                    if (cmatched == -1)
                    {
                        String cop_val = cop.compare(i, lines[i], variableList, IT.First());
                        if (cop_val == "WIN")
                        {
                            performCond = 1;
                            cmatched = 1;
                        }
                        else
                        {
                            performCond = -1;
                        }
                    }

                    if (cstart == -1)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": MEBBE operator not in between the labels YA RLY and OIC.\n");
                        continue;
                    }
                    // if code is before HAI keyword or after KTHXBYE keyword
                    if (start == -1 || end != -1)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Code not within program bounds.\n");
                    }
                }

        // NO WAI
                else if (lolcode.r[14].Match(lines[i]).Success)
                {
                    matched = 1;

                    Program.main.lexemes.Rows.Add("NO WAI", "FALSE_CONDITIONAL_STATEMENT_KEYWORD");
                    if (cmatched == -1)
                    {
                        performCond = 1;
                        cmatched = 1;
                    }
                    else
                    {
                        performCond = -1;
                    }

                    if (cstart == -1)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": No O RLY? and/or YA RLY label/s found before NO WAI label.\n");
                        continue;
                    }
                    // if code is before HAI keyword or after KTHXBYE keyword
                    if (start == -1 || end != -1)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Code not within program bounds.\n");
                    }
                }

        // OIC
                else if (lolcode.r[16].Match(lines[i]).Success)
                {
                    matched = 1;

                    Program.main.lexemes.Rows.Add("OIC", "CONDITIONAL_STATEMENT_END_KEYWORD");
                    cmatched = -1;
                    performCond = 1;

                    if (cstart == -1 && casestart == -1)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": No O RLY? or WTF? label found before OIC label.\n");
                        continue;
                    }
                    cstart = -1;
                    // if code is before HAI keyword or after KTHXBYE keyword
                    if (start == -1 || end != -1)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Code not within program bounds.\n");
                    }
                }

        // WTF?
                else if (lolcode.r[19].Match(lines[i]).Success)
                {
                    matched = 1;
                    casestart = i;
                    performCond = -1;

                    Program.main.lexemes.Rows.Add("WTF?", "CASE_BLOCK_START_KEYWORD");
                    
                    // if code is before HAI keyword or after KTHXBYE keyword
                    if (start == -1 || end != -1)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Code not within program bounds.\n");
                    }
                }

        // OMG
                else if (lolcode.r[20].Match(lines[i]).Success)
                {
                    matched = 1;
                    String val = lolcode.r[20].Match(lines[i]).Groups["lit"].Value;

                    Program.main.lexemes.Rows.Add("OMG", "CASE_KEYWORD");
                    Program.main.lexemes.Rows.Add(val, "CASE_STATEMENT_MATCHING_VALUE");

                    if (new Regex(Syntax.stringSyntax).Match(val).Success)
                    {
                        val = new Regex(Syntax.stringSyntax).Match(val).Groups["stringValue"].Value;
                    }
                    if ((cmatched == -1  && val.Equals(IT.First().getvalue())) | (cmatched == -1 && performCond == 1))
                    {
                        performCond = 1;
                    }
                    else
                    {
                        performCond = -1;
                    }

                    // if code is before HAI keyword or after KTHXBYE keyword
                    if (start == -1 || end != -1)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Code not within program bounds.\n");
                    }
                }

        // GTFO
                else if (lolcode.r[21].Match(lines[i]).Success)
                {
                    matched = 1;

                    Program.main.lexemes.Rows.Add("GTFO", "CASE_BREAK_KEYWORD");
                    if (performCond == 1)
                    {
                        cmatched = 1;
                    }

                    // if code is before HAI keyword or after KTHXBYE keyword
                    if (start == -1 || end != -1)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Code not within program bounds.\n");
                    }
                }

        // OMGWTF
                else if (lolcode.r[22].Match(lines[i]).Success)
                {
                    matched = 1;

                    Program.main.lexemes.Rows.Add("OMGWTF", "CASE_DEFAULT_KEYWORD");

                    if (cmatched == -1 || (cmatched == -1 && performCond == 1))
                    {
                        performCond = 1;
                    }
                    else
                    {
                        performCond = -1;
                    }

                    // if code is before HAI keyword or after KTHXBYE rd
                    if (start == -1 || end != -1)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Code not within program bounds.\n");
                    }
                }

        // Comparison Operations (BOTH SAEM|DIFFRINT)
                else if (lolcode.r[11].Match(lines[i]).Success)
                {
                    matched = 1;

                    int temp = cop.add_to_tables(i, lines);

                    if (performCond == 1)
                    {
                        String cop_val = cop.compare(i, lines[i], variableList, IT.First());
                        IT.AddFirst(new Variable("IT", "TROOF", Convert.ToString(cop_val)));
                        Program.main.symbol_table.Rows.Add(IT.First().getIdent(), IT.First().gettype(), IT.First().getvalue());
                    }

                    // if code is before HAI keyword or after KTHXBYE keyword
                    if (start == -1 || end != -1)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Code not within program bounds.\n");
                    }
                    if (i != temp)
                    {
                        cstart = i;
                        i = temp;
                        performCond = -1;

                        if (IT.First().getvalue().Equals("WIN"))
                        {
                            performCond = 1;
                            cmatched = 1;
                        }
                    }

                    // if code is before HAI keyword or after KTHXBYE keyword
                    if (start == -1 || end != -1)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Code not within program bounds.\n");
                    }
                }

        // Boolean Operations (ex: BOTH OF)
                else if (lolcode.r[8].Match(lines[i]).Success)
                {
                    matched = 1;

                    Program.main.lexemes.Rows.Add(lolcode.r[8].Match(lines[i]).Groups["bop"].Value, "BOOLEAN_OPERATOR_KEYWORD");
                    Program.main.lexemes.Rows.Add(lolcode.r[8].Match(lines[i]).Groups["identifier1"].Value, "FIRST_ARITHMETIC_OPERAND");
                    Program.main.lexemes.Rows.Add("AN", "OPERAND_SEPARATOR_KEYWORD");
                    Program.main.lexemes.Rows.Add(lolcode.r[8].Match(lines[i]).Groups["identifier2"].Value, "SECOND_ARITHMETIC_OPERAND");

                    // if code is before HAI keyword or after KTHXBYE keyword
                    if (start == -1 || end != -1)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Code not within program bounds.\n");
                    }
                }

        // Arithmetic Operations (ex: SUM OF)
                else if (lolcode.r[4].Match(lines[i]).Success)
                {
                    matched = 1;

                    aop.add_to_tables(i, lines[i]);
                    
                    if (performCond == 1)
                    {
                        float arith_val = aop.perform(i, lines[i], variableList);
                        IT.AddFirst(new Variable("IT", t.get_type(i, Convert.ToString(arith_val), "", -1, -1, IT.First(), variableList), Convert.ToString(arith_val)));
                        Program.main.symbol_table.Rows.Add(IT.First().getIdent(), IT.First().gettype(), IT.First().getvalue());
                    }
                    
                    // if code is before HAI keyword or after KTHXBYE keyword
                    if (start == -1 || end != -1)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Code not within program bounds.\n");
                    }
                }

        // SMOOSH
                else if (lolcode.r[1].Match(lines[i]).Success)
                {
                    matched = 1;

                    c.add_to_tables(lines[i]);

                    if (performCond == 1)
                    {
                        String concatenated_value = c.concatenate(i, value, lines[i], variableList);
                        IT.AddFirst(new Variable("IT", "YARN", concatenated_value));
                        Program.main.symbol_table.Rows.Add("IT", "YARN", concatenated_value);
                    }

                    // if code is before HAI keyword or after KTHXBYE keyword
                    if (start == -1 || end != -1)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Code not within program bounds.\n");
                    }
                }
        // OBTW
                else if (lolcode.r[10].Match(lines[i]).Success)
                {
                    matched = 1;

                    Program.main.lexemes.Rows.Add("OBTW", "MULTIPLE_LINE_COMMENT_START_KEYWORD");
                    Program.main.lexemes.Rows.Add(lolcode.r[10].Match(lines[i]).Groups["comment"].Value, "COMMENT_VALUE");
                    
                    while (i+1 < lines.Count() && !lolcode.r[23].Match(lines[i+1]).Success)
                    {
                        i++;
                        Program.main.lexemes.Rows.Add(lines[i], "COMMENT_VALUE");
                    }
                }
        // TLDR
                else if (lolcode.r[23].Match(lines[i]).Success)
                {
                    matched = 1;

                    Program.main.lexemes.Rows.Add("TLDR", "MULTIPLE_LINE_COMMENT_END_KEYWORD");

                    // if code is before HAI keyword or after KTHXBYE keyword
                    if (start == -1 || end != -1)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Code not within program bounds.\n");
                    }
                }
        // BTW
                else if (lolcode.r[18].Match(lines[i]).Success)
                {
                    matched = 1;

                    Program.main.lexemes.Rows.Add("BTW", "SINGLE_COMMENT_KEYWORD");
                    Program.main.lexemes.Rows.Add(lolcode.r[18].Match(lines[i]).Groups["comment"].Value, "COMMENT_VALUE");
                }

        // Literal or Variable (for case statement)
                else if (lolcode.r[24].Match(lines[i]).Success)
                {
                    matched = 1;
                    counter = 0;

                    String val = lolcode.r[24].Match(lines[i]).Groups["litorvar"].Value;
                    String tp = t.get_type(i, val, "", 1, -1, IT.First(), variableList);
                    if (new Regex("^" + Syntax.var + "$").Match(val).Success)
                    {
                        // traverse the linked list of declared variables to find the second operand's variable name
                        foreach (Variable v in variableList)
                        {
                            if (val.Equals(v.getIdent()))
                            {
                                IT.AddFirst(new Variable("IT", tp, v.getvalue()));
                                Program.main.symbol_table.Rows.Add("IT", tp, v.getvalue());
                                break;
                            }
                            counter++;
                        }
                        if (counter >= variableList.Count)
                        {
                            Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Variable " + val + " is undeclared.\n");
                        }
                    }
                    else
                    {
                        IT.AddFirst(new Variable("IT", tp, val));
                        Program.main.symbol_table.Rows.Add("IT", tp, val);
                    }

                    // if code is before HAI keyword or after KTHXBYE keyword
                    if (start == -1 || end != -1)
                    {
                        Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Code not within program bounds.\n");
                    }
                }

        // Unrecognized Syntax
                if (matched == 0)
                {
                    Program.main.console_output.AppendText("Error at line " + (i + 1) + ": Unrecognized Syntax.\n");
                }

            }

            // errors on occurance of HAI and KTHXBYE
            if (start != -1 && end != -1 && start >= end)
            {
                Program.main.console_output.AppendText("Error at lines " + (end + 1) + " and " + (start + 1) + ": KTHXBYE keyword occured before HAI keyword.\n");
            }
            if (start == -1)
            {
                Program.main.console_output.AppendText("Error at line 1: HAI keyword not found.\n");
            }
            if (end == -1)
            {
                Program.main.console_output.AppendText("Error at line " + (i + 1) + ": KTHXBYE keyword not found.\n");
            }

        }

    }
}
