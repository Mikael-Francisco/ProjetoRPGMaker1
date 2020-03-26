using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    [Serializable]
    public class RPGException:Exception
    {
        public List<Error> Errors { get; private set; }

        public RPGException(List<Error> errors)
        {
            this.Errors = errors;
        }

        //Daqui pra baixo é apenas código que o proprio VS gera 
        //pra gente poder utilizar esta exceção 
        public RPGException(string message) : base(message) { }
        public RPGException(string message, Exception inner) : base(message, inner) { }
        protected RPGException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
