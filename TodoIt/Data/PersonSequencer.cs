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
            return ++personId;
        }

        public static void Reset()
        {
            personId = 0;

        }

    }
}
