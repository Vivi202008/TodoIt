using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Data
{
    class PersonSequencer
    {
        private static int personId;

        public static int NextPersonId()
        {
            int nextPersonId;
            nextPersonId = +personId;
            return nextPersonId;
        }

        public static int Reset()
        {
            personId = 0;
            return personId;
        }

    }
}
