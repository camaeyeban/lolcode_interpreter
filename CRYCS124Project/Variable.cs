using System;
using System.Collections.Generic;

namespace lolcode_interpreter
{
    class Variable
    {
        private String identifier;
        private String type;
        private String value;

        public Variable(String identifier, String type, String value)
        {
            this.identifier = identifier;
            this.type = type;
            this.value = value;
        }

        public String getIdent(){
            return this.identifier;
        }

        public String gettype()
        {
            return this.type;
        }

        public String getvalue()
        {
            return this.value;
        }

        public void setIdent(String identifier)
        {
            this.identifier = identifier;
        }

        public void settype(String type)
        {
            this.type = type;
        }

        public void setvalue(String value)
        {
            this.value = value;
        }
    }
}
